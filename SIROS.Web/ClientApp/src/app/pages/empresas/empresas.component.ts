import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService, ContratoEsService, SunatService, ReniecService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { EmpresaService } from '../../services/empresa.service';
import { EmpresaModel } from '../../models/empresa.model';
import { RepresentanteLegalModel } from 'src/app/models/representante-legal.model';
import { Router } from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-empresas',
  templateUrl: './empresas.component.html',
  styleUrls: ['./empresas.component.css']
})
export class EmpresasComponent implements OnInit {

  // =============================
  // GLOBALES DEL COMPONENTE

  public FILTRO_X_RUC = 1;
  public FILTRO_X_RAZON_SOCIAL = 2;

  public OPTION_NUEVO = 1;
  public OPTION_EDITAR = 2;

  public MODAL_PAGINA_01 = 1;
  public MODAL_PAGINA_02 = 2;

  public COMBO_SIN_DATO = 0;
  public COMBO_SIN_SELECCIONAR = -1;

  // =============================

  // PRINCIPALES
  sTitlePage: string = 'Empresa';
  oModel: EmpresaModel = new EmpresaModel();
  oModelRepLegal: RepresentanteLegalModel = new RepresentanteLegalModel();

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  oIndexDataRepresentanteLegal: IndexModel = new IndexModel();

  // COMBOS
  lstTipoVia: any[] = [];
  lstCentroPoblado: any[] = [];
  lstNumeroManzana: any[] = [];
  lstLoteInterior: any[] = [];
  lstTipoDocReprLegal: any[] = [];
  lstTipoCargoReprLegal: any[] = [];
  lstDepartamento: any[] = [];
  lstProvincia: any[] = [];
  lstDistrito: any[] = [];
  lstEstacionesServicio: any[] = [];

  lstResponsablesLegales: any[] = [];

  // BUSQUEDA
  nTipoFiltro: number = this.FILTRO_X_RUC;
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oEmpresaService: EmpresaService,
    private oComboService: ComboService,
    private oMessageService: MessageService,
    private oSunatService: SunatService,
    private oReniecService: ReniecService,
    private oRouter: Router
    ) {
      this.CargarEmpresas();
      this.CargarTipoVia();
      this.CargarCentroPoblado();
      this.CargarNumeroManzana();
      this.CargarLoteInterior();
      this.CargarDepartamento();
      this.CargarTipoDocReprLegal();
      this.CargarTipoCargoReprLegal();
      this.LimpiarCampos();
  }

  ngOnInit() {
    $(document).prop('title', `SIROS - ${this.sTitlePage}`);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarEmpresas();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarEmpresas();
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarEmpresas();
  }

  fnNew() {
    this.nCurrentOption = this.OPTION_NUEVO;
    this.nCurrentSectionModal = this.MODAL_PAGINA_01;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnSiguienteModal() {
    const warningDatosEmpresa = this.ValidarDatosEmpresa();
    if (warningDatosEmpresa) {
      this.oMessageService.warning(this.sTitlePage, warningDatosEmpresa);
      return;
    }
    this.nCurrentSectionModal = this.MODAL_PAGINA_02;
  }

  fnEdit(nId: number) {
    this.nCurrentOption = this.OPTION_EDITAR;
    this.nCurrentSectionModal = this.MODAL_PAGINA_01;
    this.LimpiarCampos();
    this.oModel.nIdEmpresa = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarEmpresaXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar esta Empresa?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Empresa.');
        this.oEmpresaService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarEmpresas();
          } else {
            if (response.Message.startsWith('ERR-')) {
              this.oMessageService.error(this.sTitlePage, response.Message);
            } else {
              this.oMessageService.warning(this.sTitlePage, response.Message);
            }
            this.oBlockUI.stop();
          }
        });
      }
    });
  }

  CargarEmpresas() {
    this.oBlockUI.start('Cargando Empresas...');
    this.oEmpresaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
    .then((response: ResponseModel<any>) => {

      if (response.IsSuccess) {
        this.oIndexData = response.Data;
      } else {
        this.oIndexData = new IndexModel();
      }
      this.oBlockUI.stop();
    });
  }

  fnGuardar() {
    const warningDatosFormulario = this.ValidarDatosEmpresa();
    if (warningDatosFormulario) {
      this.oMessageService.warning(this.sTitlePage, warningDatosFormulario);
      return;
    }
    if (this.lstResponsablesLegales.length === 0) {
      this.oMessageService.warning(this.sTitlePage, 'Agrege un representante legal.');
      return;
    }
    this.Guardar();
  }

  CargarEmpresaXId() {
    this.oBlockUI.start('Cargando Empresa...');
    this.oEmpresaService.Get(this.oModel.nIdEmpresa)
    .then((oResponse: ResponseModel<EmpresaModel>) => {
      if ( oResponse.IsSuccess) {
        this.oModel = oResponse.Data;
        this.CargarProvincia();
        this.CargarDistrito();
        this.ParseStringResponsablesToList();
      } else {

      }
      this.oBlockUI.stop();
    });
  }

  Guardar() {
    this.oBlockUI.start('Guardando Empresa...');

    this.oModel.nIdCcpp = Number(this.oModel.nIdCcpp);
    this.oModel.nIdLoteIntDpto = Number(this.oModel.nIdLoteIntDpto);
    this.oModel.nIdNroMzKm = Number(this.oModel.nIdNroMzKm);
    this.oModel.nIdTipoVia = Number(this.oModel.nIdTipoVia);
    this.ParseListResponsablesToString();

    if (this.nCurrentOption === this.OPTION_NUEVO) {
      this.oEmpresaService.Insert(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.nCurrentSectionModal = this.MODAL_PAGINA_01;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarEmpresas();
        } else {
          if (response.Message.startsWith('ERR-')) {
            this.oMessageService.error(this.sTitlePage, response.Message);
          } else {
            this.oMessageService.warning(this.sTitlePage, response.Message);
          }
          this.oBlockUI.stop();
        }
      });
    } else if (this.nCurrentOption === this.OPTION_EDITAR) {
      this.oEmpresaService.Update(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarEmpresas();
        } else {
          if (response.Message.startsWith('ERR-')) {
            this.oMessageService.error(this.sTitlePage, response.Message);
          } else {
            this.oMessageService.warning(this.sTitlePage, response.Message);
          }
          this.oBlockUI.stop();
        }
      });
    }
  }

  fnBuscarRuc() {
    this.ConsultarRuc();
  }

  fnBuscarPersonaxDNI() {
    if ( Number(this.oModelRepLegal.nIdTipDoc) === 1) {
      this.ConsultarDni();
    }
  }

  ConsultarRuc() {
    if (this.oModel.sRuc.length !== 11) {
      this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de Ruc de 11 dígitos');
      return;
    }

    this.oBlockUI.start('Consultando Ruc...');
    this.oModel.sRazonSocial = '';
    this.oModel.sCodDepartamento = '00';
    this.oSunatService.ConsultaRuc(this.oModel.sRuc).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        if (response.Data) {
          const oUbigeo = response.Data.sUbigeo;
          this.oModel.sRazonSocial = response.Data.sNombre;
          this.oModel.sReferencia = response.Data.sReferencia;
          this.oModel.sCodDepartamento = oUbigeo.substr(0, 2);
          this.oModel.sCodProvincia = oUbigeo.substr(2, 2);
          this.oModel.sCodDistrito = oUbigeo.substr(4, 2);
          this.CargarProvincia();
          this.CargarDistrito();
        }
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }

  ConsultarDni() {
    if (this.oModelRepLegal.sNroDoc.length !== 8) {
      this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de DNI de 8 dígitos');
      return;
    }
    this.oBlockUI.start('Consultando DNI...');
    this.oModelRepLegal.sNombres = '';
    this.oModelRepLegal.sApePaterno = '';
    this.oModelRepLegal.sApeMaterno = '';
    this.oReniecService.ConsultaNumDoc(this.oModelRepLegal.sNroDoc).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        if (response.Data) {
          this.oModelRepLegal.sNombres = response.Data.sNombres;
          this.oModelRepLegal.sApePaterno = response.Data.sApellidoPaterno;
          this.oModelRepLegal.sApeMaterno = response.Data.sApellidoMaterno;
        }
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }

  onChangeSinDato() {
    if ( Number(this.oModel.nIdTipoVia) === 0) {
      this.oModel.sNombreVia = '';
    }
    if ( Number(this.oModel.nIdCcpp) === 0) {
      this.oModel.sNombreCcpp = '';
    }
    if ( Number(this.oModel.nIdNroMzKm) === 0) {
      this.oModel.sNroMzKm = '';
    }
    if ( Number(this.oModel.nIdLoteIntDpto) === 0) {
      this.oModel.sLoteIntDpto = '';
    }
  }

  onChangeDepartamento() {
    this.oModel.sCodProvincia = '00';
    this.oModel.sCodDistrito = '00';
    this.lstProvincia = [];
    this.lstDistrito = [];
    if (this.oModel.sCodDepartamento === '00') {
      return;
    }
    this.CargarProvincia();
  }

  onChangeProvincia() {
    this.oModel.sCodDistrito = '00';
    this.lstDistrito = [];
    if (this.oModel.sCodProvincia === '00') {
      return;
    }
    this.CargarDistrito();
  }

  /******* CARGAR COMBOS ********/

  CargarTipoVia() {
    this.lstTipoVia = [];
    this.oComboService.GetTipoVia().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoVia = response.Data;
      }
    });
  }

  CargarCentroPoblado() {
    this.lstCentroPoblado = [];
    this.oComboService.GetCentroPoblado().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstCentroPoblado = response.Data;
      }
    });
  }

  CargarNumeroManzana() {
    this.lstNumeroManzana = [];
    this.oComboService.GetNumeroManzana().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstNumeroManzana = response.Data;
      }
    });
  }

  CargarLoteInterior() {
    this.lstLoteInterior = [];
    this.oComboService.GetLoteInterior().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstLoteInterior = response.Data;
      }
    });
  }

  CargarTipoDocReprLegal() {
    this.lstTipoDocReprLegal = [];
    this.oComboService.GetTipoDoc('EMP').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoDocReprLegal = response.Data;
      }
    });
  }

  CargarTipoCargoReprLegal() {
    this.lstTipoCargoReprLegal = [];
    this.oComboService.GetCargoRepresentanteLegal().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoCargoReprLegal = response.Data;
      }
    });
  }

  CargarDepartamento() {
    this.lstDepartamento = [];
    this.oComboService.GetDepartamento().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstDepartamento = response.Data;
      }
    });
  }

  CargarProvincia() {
    this.lstProvincia = [];
    this.oComboService.GetProvincia(this.oModel.sCodDepartamento).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstProvincia = response.Data;
      }
    });
  }

  CargarDistrito() {
    this.lstDistrito = [];
    this.oComboService.GetDistrito(this.oModel.sCodDepartamento, this.oModel.sCodProvincia).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstDistrito = response.Data;
      }
    });
  }

  LimpiarCampos() {
    this.oModel = new EmpresaModel();
    this.oModel.nIdEmpresa = 0;
    this.oModel.sRuc = '';
    this.oModel.sRazonSocial = '';
    this.oModel.nIdTipoVia = -1;
    this.oModel.sNombreVia = '';
    this.oModel.nIdCcpp = -1;
    this.oModel.sNombreCcpp = '';
    this.oModel.nIdNroMzKm = -1;
    this.oModel.sNroMzKm = '';
    this.oModel.nIdLoteIntDpto = -1;
    this.oModel.sLoteIntDpto = '';
    this.oModel.sReferencia = '';
    this.oModel.sTelefono = '';
    this.oModel.sRepresentante = '';
    this.oModel.sCodDepartamento = '00';
    this.oModel.sCodProvincia = '00';
    this.oModel.sCodDistrito = '00';

    this.oIndexDataRepresentanteLegal = new IndexModel();
    this.lstResponsablesLegales = [];

    this.LimpiarCamposRepLegal();
  }

  /******* REPRESENTANTE LEGAL ******/

  LimpiarCamposRepLegal() {
    this.oModelRepLegal = new RepresentanteLegalModel();
    this.oModelRepLegal.nId = 0;
    this.oModelRepLegal.nIdTipDoc = -1;
    this.oModelRepLegal.sNroDoc = '';
    this.oModelRepLegal.sNombres = '';
    this.oModelRepLegal.sApePaterno = '';
    this.oModelRepLegal.sApeMaterno = '';
    this.oModelRepLegal.nCargo = -1;
  }

  fnAgregarRepresentanteLegal() {
    const warningRepresentanteLegal = this.ValidarDatosRepLegal();
    if (warningRepresentanteLegal) {
      this.oMessageService.warning(this.sTitlePage, warningRepresentanteLegal);
      return;
    }
    const oDocumentoRepresentante = this.lstTipoDocReprLegal.find(doc => doc.nId === Number(this.oModelRepLegal.nIdTipDoc));
    const oCargoRepresentante = this.lstTipoCargoReprLegal.find(cargo => cargo.nId === Number(this.oModelRepLegal.nCargo));
    this.lstResponsablesLegales.push(
      {
        nIdTipDoc: oDocumentoRepresentante.nId,
        sTipDoc: oDocumentoRepresentante.sDescription,
        sNroDoc: this.oModelRepLegal.sNroDoc,
        sNombres: this.oModelRepLegal.sNombres,
        sApePaterno: this.oModelRepLegal.sApePaterno,
        sApeMaterno: this.oModelRepLegal.sApeMaterno,
        nIdCargo: oCargoRepresentante.nId,
        sCargo: oCargoRepresentante.sDescription
      });
    this.LimpiarCamposRepLegal();
    this.ParseListToIndexRepresentante();
  }

  fnEditarRepresentanteLegal() {
    const nIndex = this.lstResponsablesLegales.findIndex(x => x.sNroDoc === this.oModelRepLegal.sNroDoc);
    if (nIndex === -1) {
      this.oMessageService.warning(this.sTitlePage, 'No se pudo editar al representante legal seleccionado.');
      return;
    }

    const oDocumentoRepresentante = this.lstTipoDocReprLegal.find(doc => doc.nId === Number(this.oModelRepLegal.nIdTipDoc));
    const oCargoRepresentante = this.lstTipoCargoReprLegal.find(cargo => cargo.nId === Number(this.oModelRepLegal.nCargo));

    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].nIdTipDoc = oDocumentoRepresentante.nId;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sTipDoc = oDocumentoRepresentante.sDescription;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sNroDoc = this.oModelRepLegal.sNroDoc;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sNombres = this.oModelRepLegal.sNombres;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sApePaterno = this.oModelRepLegal.sApePaterno;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sApeMaterno = this.oModelRepLegal.sApeMaterno;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].nIdCargo = oCargoRepresentante.nId;
    this.lstResponsablesLegales[this.oModelRepLegal.nId - 1].sCargo = oCargoRepresentante.sDescription;
    this.LimpiarCamposRepLegal();
    this.ParseListToIndexRepresentante();
  }

  fnCancelarRepresentanteLegal() {
    this.LimpiarCamposRepLegal();
  }

  fnDeleteRepresentante(nId: number) {
    this.lstResponsablesLegales.splice(nId - 1, 1);
    if (this.oModelRepLegal.nId === nId) {
      this.oModelRepLegal.nId = 0;
    }
    this.ParseListToIndexRepresentante();
  }

  fnUpdateRepresentante(nId: number) {
    this.oModelRepLegal.nId = nId;
    const oData = this.lstResponsablesLegales[nId - 1];
    if (oData) {
      this.oModelRepLegal.nIdTipDoc = Number(oData.nIdTipDoc);
      this.oModelRepLegal.sNroDoc = oData.sNroDoc;
      this.oModelRepLegal.sNombres = oData.sNombres;
      this.oModelRepLegal.sApePaterno = oData.sApePaterno;
      this.oModelRepLegal.sApeMaterno = oData.sApeMaterno;
      this.oModelRepLegal.nCargo = Number(oData.nIdCargo);
    }
  }

  ParseListToIndexRepresentante() {
    this.oIndexDataRepresentanteLegal = new IndexModel();
    this.oIndexDataRepresentanteLegal.NroItems = this.lstResponsablesLegales.length;
    this.oIndexDataRepresentanteLegal.TotalPage = 1;
    this.oIndexDataRepresentanteLegal.ActualPage = 1;
    this.oIndexDataRepresentanteLegal.Items = [];
    let nCount = 0;
    this.lstResponsablesLegales.forEach(x => {
      this.oIndexDataRepresentanteLegal.Items.push(
        {
          Id: ++nCount,
          Column1: x.sNroDoc,
          Column2: x.sTipDoc,
          Column3: `${x.sNombres} ${x.sApePaterno} ${x.sApeMaterno}`,
          Column4: x.sCargo});
    });
  }

  ParseListResponsablesToString() {
    let sRepresentante = '';
    this.lstResponsablesLegales.forEach(x => {
      sRepresentante = `${sRepresentante}¢${x.nIdTipDoc}@${x.sNroDoc}@${x.sNombres}@${x.sApePaterno}@${x.sApeMaterno}@${x.nIdCargo}`;
    });
    // '1@43171962@Francis arthur poldark@Palomino@Marino@2¢1@43171967@juan jose@condori@pumacahua@8';
    this.oModel.sRepresentante = sRepresentante.substr(1, sRepresentante.length - 1);
  }

  ParseStringResponsablesToList() {
    const lstResult = this.oModel.sRepresentante.split('¢');
    lstResult.forEach(x => {
      const oRepresentante = x.split('@');
      this.oModelRepLegal.nIdTipDoc = Number(oRepresentante[0]);
      this.oModelRepLegal.sNroDoc = oRepresentante[1];
      this.oModelRepLegal.sNombres = oRepresentante[2];
      this.oModelRepLegal.sApePaterno = oRepresentante[3];
      this.oModelRepLegal.sApeMaterno = oRepresentante[4];
      this.oModelRepLegal.nCargo = Number(oRepresentante[5]);
      this.fnAgregarRepresentanteLegal();
    });
  }

  ValidarDatosRepLegal(): string {
    if ( this.oModelRepLegal.nIdTipDoc === -1) {
      return 'Seleccione Tipo de documento.';
    }
    if (this.oModelRepLegal.sNroDoc.length === 0) {
      return 'Ingrese número de documento del representante.';
    }
    if (this.oModelRepLegal.sNombres.length === 0) {
      return 'Ingrese nombre del representante.';
    }
    if (this.oModelRepLegal.sApePaterno.length === 0) {
      return 'Ingrese apellido paterno del representante.';
    }
    if (this.oModelRepLegal.sApePaterno.length === 0) {
      return 'Ingrese apellido materno del representante.';
    }
    if (this.oModelRepLegal.nCargo === -1) {
      return 'Seleccione cargo del representante legal.';
    }
    if (this.lstResponsablesLegales.length > 0) {
      const oExiste = this.lstResponsablesLegales.find(x => x.sNroDoc === this.oModelRepLegal.sNroDoc);
      if (oExiste) {
        return 'Representante legal ya se encuentra agregado en la lista inferior.';
      }
    }
    return null;
  }

  ValidarDatosEmpresa(): string {
    if (this.oModel.sRuc.length !== 11) {
      return 'Ingrese el Número de RUC correctamente';
    }
    if (this.oModel.sRazonSocial.length === 0) {
      return 'Realice la búsqueda del Ruc para completar el campo Razón Social';
    }
    if (this.oModel.nIdTipoVia === -1) {
      return 'Seleccione Tipo de Via';
    }
    if (this.oModel.nIdCcpp === -1) {
      return 'Seleccione Tipo de CCPP';
    }
    if (this.oModel.nIdNroMzKm === -1) {
      return 'Seleccione Nro/Mzn/Km';
    }
    if (this.oModel.nIdLoteIntDpto === -1) {
      return 'Seleccione Lote/Int/Dpto';
    }
    if (
      this.oModel.sCodDepartamento === '00' ||
      this.oModel.sCodProvincia === '00' ||
      this.oModel.sCodDistrito === '00'
      ) {
      return 'Seleccione Departamento,Provincia y Distrito';
    }

    if (
      (this.oModel.sNombreVia.length === 0 && Number(this.oModel.nIdTipoVia) !== this.COMBO_SIN_DATO) ||
      (this.oModel.sNombreCcpp.length === 0 && Number(this.oModel.nIdCcpp) !== this.COMBO_SIN_DATO) ||
      (this.oModel.sNroMzKm.length === 0 && Number(this.oModel.nIdNroMzKm) !== this.COMBO_SIN_DATO) ||
      (this.oModel.sLoteIntDpto.length === 0 && Number(this.oModel.nIdLoteIntDpto) !== this.COMBO_SIN_DATO) ||
      this.oModel.sReferencia.length === 0
    ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }

    return null;
  }

  fnRutas(nIdEmpresa: number) {
    const oData = this.oIndexData.Items.find(x => Number(x.Id) === Number(nIdEmpresa));
    this.oRouter.navigate(['/OGTU/rutasEmpresa/', nIdEmpresa, `${oData.Column2} — ${oData.Column3}`]);
  }

  fnOperadorEmpresa(nIdEmpresa: number) {
    const oData = this.oIndexData.Items.find(x => Number(x.Id) === Number(nIdEmpresa));
    this.oRouter.navigate(['/OGTU/operadorEmpresa/', nIdEmpresa, `${oData.Column2} — ${oData.Column3}`]);
  }

}
