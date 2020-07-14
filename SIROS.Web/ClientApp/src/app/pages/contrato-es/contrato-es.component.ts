import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { EstacionServicioService, ComboService, SunatService, MessageService, ReniecService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { ContratoEsRequestModel } from 'src/app/models/contrato-es.model';

declare var $: any;
@Component({
  selector: 'app-contrato-es',
  templateUrl: './contrato-es.component.html',
  styleUrls: ['./contrato-es.component.css']
})
export class ContratoESComponent implements OnInit {

  sTitlePage: string = 'Contrato de Estación de Servicios';
  oRequestModel: ContratoEsRequestModel = new ContratoEsRequestModel();

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

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

  lstResponsablesLegales: any[] = [];

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';
  // FORMULARIO
  nIdEstServicio: number = 0;
  sRuc: string = '';
  sRazonSocial: string = '';
  nTipoVia: number = -1;
  sVia: string = '';
  nCentroPoblado: number = -1;
  sCentroPoblado: string = '';
  nIdNumeroManzana: number = -1;
  sNumeroManzana: string = '';
  nIdLoteInterior: number = -1;
  sLoteInterior: string = '';
  sReferencia: string = '';
  sCodDepartamento: string = '00';
  sCodProvincia: string = '00';
  sCodDistrito: string = '00';
  sNroSucursales: string = '';
  sRepresentante: string = '';

  nIdRepresentanteLegal: number = 0;
  nTipDocRepresentanteLegal: number = 0;
  sNroDocRepresentanteLegal: string = '';
  sNombresRepresentanteLegal: string = '';
  sApePaternoRepresentanteLegal: string = '';
  sApeMaternoRepresentanteLegal: string = '';
  nCargoRepresentanteLegal: number = 0;

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oEstacionServicioService: EstacionServicioService,
    private oComboService: ComboService,
    private oSunatService: SunatService,
    private oMessageService: MessageService,
    private oReniecService: ReniecService
    ) {
    this.CargarEstaciones();
    this.CargarTipoVia();
    this.CargarCentroPoblado();
    this.CargarNumeroManzana();
    this.CargarLoteInterior();
    this.CargarDepartamento();
    this.CargarTipoDocReprLegal();
    this.CargarTipoCargoReprLegal();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Estación de Servicio');
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarEstaciones();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarEstaciones();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.nCurrentSectionModal = 1;
    this.LimpiarCampos();
    this.LimpiarRepresentanteLegal();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }
  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.nCurrentSectionModal = 1;
    this.LimpiarCampos();
    this.LimpiarRepresentanteLegal();
    this.nIdEstServicio = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarEstacionXId();
  }
  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar la estación de servicio?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando estación de servicio.');
        this.oEstacionServicioService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarEstaciones();
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

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarEstaciones();
  }
  onChangeSinDato() {
    if ( Number(this.nTipoVia) === 0) {
      this.sVia = '';
    }
    if ( Number(this.nCentroPoblado) === 0) {
      this.sCentroPoblado = '';
    }
    if ( Number(this.nIdNumeroManzana) === 0) {
      this.sNumeroManzana = '';
    }
    if ( Number(this.nIdLoteInterior) === 0) {
      this.sLoteInterior = '';
    }
  }
  onChangeDepartamento() {
    this.sCodProvincia = '00';
    this.sCodDistrito = '00';
    this.lstProvincia = [];
    this.lstDistrito = [];
    if (this.sCodDepartamento === '00') {
      return;
    }
    this.CargarProvincia();
  }
  onChangeProvincia() {
    this.sCodDistrito = '00';
    this.lstDistrito = [];
    if (this.sCodProvincia === '00') {
      return;
    }
    this.CargarDistrito();
  }
  // INI - Funciones modal
  fnBuscarRuc() {
    this.ConsultarRuc();
  }
  fnSiguienteModal() {
    const warningDatosEmpresa = this.ValidarDatosEmpresa();
    if (warningDatosEmpresa !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatosEmpresa);
      return;
    }
    this.nCurrentSectionModal = 2;
  }
  fnBuscarPersonaxDNI() {
    if ( Number(this.nTipDocRepresentanteLegal) === 1) {
      this.ConsultarDni();
    }
  }
  fnAgregarRepresentanteLegal() {
    const warningRepresentanteLegal = this.ValidarRepresentanteLegal();
    if (warningRepresentanteLegal !== null) {
      this.oMessageService.warning(this.sTitlePage, warningRepresentanteLegal);
      return;
    }
    // tslint:disable-next-line: triple-equals
    const documentoRepresentante = this.lstTipoDocReprLegal.find(doc => doc.nId == this.nTipDocRepresentanteLegal);
    // tslint:disable-next-line: triple-equals
    const cargoRepresentante = this.lstTipoCargoReprLegal.find(cargo => cargo.nId == this.nCargoRepresentanteLegal);
    this.lstResponsablesLegales.push(
      {
        nIdTipoDocumento: documentoRepresentante.nId,
        sTipoDocumento: documentoRepresentante.sDescription,
        sNroDocumento: this.sNroDocRepresentanteLegal,
        sNombres: this.sNombresRepresentanteLegal,
        sApePaterno: this.sApePaternoRepresentanteLegal,
        sApeMaterno: this.sApeMaternoRepresentanteLegal,
        nIdCargo: cargoRepresentante.nId,
        sCargo: cargoRepresentante.sDescription
      });
    this.LimpiarRepresentanteLegal();
  }
  fnEditarRepresentanteLegal() {
    let count: number = 0;
    for (let index = 0; index < this.lstResponsablesLegales.length; index++) {
      if (this.lstResponsablesLegales[index].sNroDocumento === this.sNroDocRepresentanteLegal) {
        if (index !== this.nIdRepresentanteLegal - 1) {
          count++;
        }
      }
    }
    if ( count > 0) {
      this.oMessageService.warning(this.sTitlePage, 'Representante legal ya se encuentra agregado en la lista inferior.');
      return;
    }

    // tslint:disable-next-line: triple-equals
    const documentoRepresentante = this.lstTipoDocReprLegal.find(doc => doc.nId == this.nTipDocRepresentanteLegal);
    // tslint:disable-next-line: triple-equals
    const cargoRepresentante = this.lstTipoCargoReprLegal.find(cargo => cargo.nId == this.nCargoRepresentanteLegal);
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].nIdTipoDocumento = documentoRepresentante.nId;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sTipoDocumento = documentoRepresentante.sDescription;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sNroDocumento = this.sNroDocRepresentanteLegal;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sNombres = this.sNombresRepresentanteLegal;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sApePaterno = this.sApePaternoRepresentanteLegal;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sApeMaterno = this.sApeMaternoRepresentanteLegal;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].nIdCargo = cargoRepresentante.nId;
    this.lstResponsablesLegales[this.nIdRepresentanteLegal - 1].sCargo = cargoRepresentante.sDescription;
    this.LimpiarRepresentanteLegal();
  }
  fnCancelarRepresentanteLegal() {
    this.LimpiarRepresentanteLegal();
  }
  fnGuardar() {
    const warningDatosEmpresa = this.ValidarDatosEmpresa();
    if (warningDatosEmpresa !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatosEmpresa);
      return;
    }
    if (this.lstResponsablesLegales.length === 0) {
      this.oMessageService.warning(this.sTitlePage, 'Agrege un representante legal.');
      return;
    }
    this.Guardar();
  }
  fnDeleteRepresentante(id: number) {
    this.lstResponsablesLegales.splice(id - 1, 1);
  }
  fnUpdateRepresentante(id: number) {
    this.nIdRepresentanteLegal = id;
    const datos = this.lstResponsablesLegales[id - 1];
    this.nTipDocRepresentanteLegal = Number(datos.nIdTipoDocumento);
    this.sNroDocRepresentanteLegal = datos.sNroDocumento;
    this.sNombresRepresentanteLegal = datos.sNombres;
    this.sApePaternoRepresentanteLegal = datos.sApePaterno;
    this.sApeMaternoRepresentanteLegal = datos.sApeMaterno;
    this.nCargoRepresentanteLegal = Number(datos.nIdCargo);
  }
  // END - Funciones modal

  CargarEstacionXId() {
    this.oBlockUI.start('Cargando estación de servicio...');
    this.oEstacionServicioService.Get(this.nIdEstServicio).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.nIdEstServicio = response.Data.nIdEstServicio;
        this.sRuc = response.Data.sRuc;
        this.sRazonSocial = response.Data.sRazonSocial;
        this.nTipoVia = Number(response.Data.nTipoVia);
        this.sVia = response.Data.sVia === null ? '' : response.Data.sVia;
        this.nCentroPoblado = Number(response.Data.nCentroPoblado);
        this.sCentroPoblado = response.Data.sCentroPoblado === null ? '' : response.Data.sCentroPoblado;
        this.nIdNumeroManzana = Number(response.Data.nIdNumeroManzana);
        this.sNumeroManzana = response.Data.sNumeroManzana === null ? '' : response.Data.sNumeroManzana;
        this.nIdLoteInterior = Number(response.Data.nIdLoteInterior);
        this.sLoteInterior = response.Data.sLoteInterior === null ? '' : response.Data.sLoteInterior;
        this.sReferencia = response.Data.sReferencia;
        this.sCodDepartamento = response.Data.sCodDepartamento;
        this.sCodProvincia = response.Data.sCodProvincia;
        this.sCodDistrito = response.Data.sCodDistrito;
        this.sNroSucursales = response.Data.sNroSucursales;
        this.sRepresentante = response.Data.sRepresentante;
        this.CargarProvincia();
        this.CargarDistrito();
      } else {

      }
      this.oBlockUI.stop();
    });
  }
  CargarEstaciones() {
    this.oBlockUI.start('Cargando Estaciones de servicios...');
    console.log(this.sFilter);
    this.oEstacionServicioService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
    .then((response: ResponseModel<any>) => {

      if (response.IsSuccess) {
        this.oIndexData = response.Data;
      } else {
        this.oIndexData = new IndexModel();
      }
      this.oBlockUI.stop();
    });
  }
  Guardar() {
    this.ParseListResponsablesToString();
    this.oBlockUI.start('Guardando Estación...');
    if (this.nCurrentOption === 1) {
      this.oEstacionServicioService.Insert(
        this.sRuc,
        this.sRazonSocial,
        Number(this.nTipoVia),
        this.sVia,
        Number(this.nCentroPoblado),
        this.sCentroPoblado,
        Number(this.nIdNumeroManzana),
        this.sNumeroManzana,
        Number(this.nIdLoteInterior),
        this.sLoteInterior,
        this.sReferencia,
        this.sCodDepartamento,
        this.sCodProvincia,
        this.sCodDistrito,
        this.sNroSucursales,
        this.sRepresentante
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.LimpiarRepresentanteLegal();
          this.nCurrentSectionModal = 1;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarEstaciones();
        } else {
          if (response.Message.startsWith('ERR-')) {
            this.oMessageService.error(this.sTitlePage, response.Message);
          } else {
            this.oMessageService.warning(this.sTitlePage, response.Message);
          }
          this.oBlockUI.stop();
        }
      });
    } else if (this.nCurrentOption === 2) {
      this.oEstacionServicioService.Update(
        this.nIdEstServicio,
        this.sRuc,
        this.sRazonSocial,
        Number(this.nTipoVia),
        this.sVia,
        Number(this.nCentroPoblado),
        this.sCentroPoblado,
        Number(this.nIdNumeroManzana),
        this.sNumeroManzana,
        Number(this.nIdLoteInterior),
        this.sLoteInterior,
        this.sReferencia,
        this.sCodDepartamento,
        this.sCodProvincia,
        this.sCodDistrito,
        this.sNroSucursales,
        this.sRepresentante
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarEstaciones();
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
    this.oComboService.GetTipoDocRepresentanteLegal().then((response: ResponseModel<any>) => {
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
    this.oComboService.GetProvincia(this.sCodDepartamento).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstProvincia = response.Data;
      }
    });
  }
  CargarDistrito() {
    this.lstDistrito = [];
    this.oComboService.GetDistrito(this.sCodDepartamento, this.sCodProvincia).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstDistrito = response.Data;
      }
    });
  }
  ConsultarRuc() {
    if (this.sRuc.length !== 11) {
      this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de Ruc de 11 dígitos');
      return;
    }
    this.oBlockUI.start('Consultando Ruc...');
    this.sRazonSocial = '';
    this.sCodDepartamento = '00';
    this.oSunatService.ConsultaRuc(this.sRuc).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.sRazonSocial = response.Data.sNombre;
        const ubigeo = response.Data.sUbigeo;
        if (ubigeo !== null) {
          this.sCodDepartamento = ubigeo.substr(0, 2);
          this.sCodProvincia = ubigeo.substr(2, 2);
          this.sCodDistrito = ubigeo.substr(4, 2);
          this.CargarProvincia();
          this.CargarDistrito();
        }
        this.sReferencia = response.Data.sReferencia;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }
  ConsultarDni() {
    if (this.sNroDocRepresentanteLegal.length !== 8) {
      this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de DNI de 8 dígitos');
      return;
    }
    this.oBlockUI.start('Consultando DNI...');
    this.sNombresRepresentanteLegal = '';
    this.sApePaternoRepresentanteLegal = '';
    this.sApeMaternoRepresentanteLegal = '';
    this.oReniecService.ConsultaNumDoc(this.sNroDocRepresentanteLegal).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.sNombresRepresentanteLegal = response.Data.sNombres;
        this.sApePaternoRepresentanteLegal = response.Data.sApellidoPaterno;
        this.sApeMaternoRepresentanteLegal = response.Data.sApellidoMaterno;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }
  ParseListResponsablesToString() {
    let sTramaRepresentante = '';
    this.lstResponsablesLegales.forEach(iResponsable => {
      // tslint:disable-next-line: max-line-length
      sTramaRepresentante = `${sTramaRepresentante}¢${iResponsable.nIdTipoDocumento}@${iResponsable.sNroDocumento}@${iResponsable.sNombres}@${iResponsable.sApePaterno}@${iResponsable.sApeMaterno}@${iResponsable.nIdCargo}`;
    });
    // '1@43171962@Francis arthur poldark@Palomino@Marino@2¢1@43171967@juan jose@condori@pumacahua@8';
    this.sRepresentante = sTramaRepresentante.substr(1, sTramaRepresentante.length - 1);
  }

  LimpiarCampos() {
    this.nIdEstServicio = 0;
    this.sRuc = '';
    this.sRazonSocial = '';
    this.nTipoVia = -1;
    this.sVia = '';
    this.nCentroPoblado = -1;
    this.sCentroPoblado = '';
    this.nIdNumeroManzana = -1;
    this.sNumeroManzana = '';
    this.nIdLoteInterior = -1;
    this.sLoteInterior = '';
    this.sReferencia = '';
    this.sCodDepartamento = '00';
    this.sCodProvincia = '00';
    this.sCodDistrito = '00';
    this.sNroSucursales = '';
    this.sRepresentante = '';
    this.lstProvincia = [];
    this.lstDistrito = [];
    this.LimpiarRepresentanteLegal();
  }
  LimpiarRepresentanteLegal() {
    this.nIdRepresentanteLegal = 0;
    this.nTipDocRepresentanteLegal = 0;
    this.sNroDocRepresentanteLegal = '';
    this.sNombresRepresentanteLegal = '';
    this.sApePaternoRepresentanteLegal = '';
    this.sApeMaternoRepresentanteLegal = '';
    this.nCargoRepresentanteLegal = 0;
  }
  ValidarDatosEmpresa(): any {
    if (this.sRuc.length !== 11) {
      return 'Ingrese el Número de RUC correctamente';
    }
    if (this.sRazonSocial.length === 0) {
      return 'Realice la búsqueda del Ruc para completar el campo Razón Social';
    }
    if (
      Number(this.nTipoVia) === -1 ||
      Number(this.nCentroPoblado) === -1 ||
      Number(this.nIdNumeroManzana) === -1 ||
      Number(this.nIdLoteInterior) === -1 ||
      this.sCodDepartamento === '00' ||
      this.sCodProvincia === '00' ||
      this.sCodDistrito === '00'
      ) {
      return 'Seleccione los campos con (*), son obligatorios';
    }
    if (
      (this.sVia === null && Number(this.nTipoVia) !== 0) ||
      (this.sCentroPoblado === null && Number(this.nCentroPoblado) !== 0) ||
      (this.sNumeroManzana === null && Number(this.nIdNumeroManzana) !== 0) ||
      (this.sLoteInterior === null && Number(this.nIdLoteInterior) !== 0) ||
      this.sReferencia === null ||
      this.sNroSucursales === null
    ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    if (
        (this.sVia.length === 0 && Number(this.nTipoVia) !== 0) ||
        (this.sCentroPoblado.length === 0 && Number(this.nCentroPoblado) !== 0) ||
        (this.sNumeroManzana.length === 0 && Number(this.nIdNumeroManzana) !== 0) ||
        (this.sLoteInterior.length === 0 && Number(this.nIdLoteInterior) !== 0) ||
        this.sReferencia.length === 0 ||
        this.sNroSucursales.length === 0
      ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }
  ValidarRepresentanteLegal() {
    if ( Number(this.nTipDocRepresentanteLegal) === 0) {
      return 'Seleccione Tipo de documento.';
    }
    if (this.sNroDocRepresentanteLegal.length === 0) {
      return 'Ingrese número de documento del representante.';
    }
    if (this.sNombresRepresentanteLegal.length === 0) {
      return 'Ingrese nombre del representante.';
    }
    if (this.sApePaternoRepresentanteLegal.length === 0) {
      return 'Ingrese apellido paterno del representante.';
    }
    if (this.sApePaternoRepresentanteLegal.length === 0) {
      return 'Ingrese apellido materno del representante.';
    }
    if ( this.nCargoRepresentanteLegal === 0) {
      return 'Seleccione cargo del representante legal.';
    }
    if ( this.lstResponsablesLegales.length > 0) {
      // tslint:disable-next-line: triple-equals
      const existe: any = this.lstResponsablesLegales.find(representante => representante.sNroDocumento == this.sNroDocRepresentanteLegal );
      if (existe !== undefined) {
        return 'Representante legal ya se encuentra agregado en la lista inferior.';
      }
    }
    return null;
  }

}
