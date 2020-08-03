import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MunicipalidadService, ComboService, OperadorEsService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';

declare var $: any;
@Component({
  selector: 'app-formulario-ogtu',
  templateUrl: './formulario-ogtu.component.html',
  styles: []
})
export class FormularioOgtuComponent implements OnInit {
  sTitlePage: string = 'Formulario';
  // INI - CONSTANTE
  DNI_VALUE = 1;
  CE_VALUE = 2;
  //
  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  // COMBOS
  lstTipoDocumentoOGTU: any[] = [];
  lstTipoDocumentoOEMP: any[] = [];
  lstHoras: any[] = [];
  lstMinutos: any[] = [];
  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';
  // FORMULARIO
  nIdEntidad: number = 0;
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
  sRepresentante: string = '';
  // VEHICULO
  nIdSucursalxES: number = 0;
  // OPERADOR OGTU
  sApellidoPaternoOGTU: string = '';
  sApellidoMaternoOGTU: string = '';
  sNombresOGTU: string = '';

  nIdRepresentanteLegal: number = 0;
  nTipDocRepresentanteLegal: number = 0;
  sNroDocRepresentanteLegal: string = '';
  sNombresRepresentanteLegal: string = '';
  sApePaternoRepresentanteLegal: string = '';
  sApeMaternoRepresentanteLegal: string = '';
  nCargoRepresentanteLegal: number = 0;

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oMunicipalidadService: MunicipalidadService,
    private oOperadorEsService: OperadorEsService,
    private oComboService: ComboService,
    private oMessageService: MessageService,
    ) {
    this.CargarFormularios();
    this.CargarHoras();
    this.CargarMinutos();
    this.CargarTipoDocOperadorEmp();
    this.CargarTipoDocOperadorOGTU();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Formularios');
  }

  fnChangeTipoBusqueda(nOption: number) {
    this.nTipoFiltro = nOption;
    this.sFilter = '';
    setTimeout(() => {
      document.getElementById(`sFilter${nOption}`).focus();
    }, 0);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarFormularios();
  }

  // INI - FUNCIONES / TABLE
  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarFormularios();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.nCurrentSectionModal = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }
  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.nCurrentSectionModal = 1;
    this.LimpiarCampos();
    this.nIdEntidad = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarFormularioXId();
  }
  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar el formulario?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando formulario.');
        this.oMunicipalidadService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarFormularios();
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
    this.CargarFormularios();
  }
  // INI - EVENTOS DE CAMBIOS
  onChangePlaca() {
    this.LimpiarDatosVehiculo();
  }
  onChangeTipoDocOEMP() {
    this.LimpiarOperadorEmpresa();
  }
  onChangeNroDocOEMP() {
    this.LimpiarOperadorEmpresa();
  }
  onChangeTipoDocOGTU() {
    this.LimpiarOperadorOgtu();
  }
  onChangeNroDocOGTU() {
    this.LimpiarOperadorOgtu();
  }
  // INI - Funciones modal
  fnBuscarVehiculo() {
  }
  fnBuscarOperadorEmpresa() {
  }
  fnBuscarOperadorGTU() {
    this.oBlockUI.start('Buscando operador...');
    this.LimpiarOperadorOgtu();
    this.oOperadorEsService.GetXDoc(this.nIdSucursalxES, 2, '32')
    .then((response: ResponseModel<any>) => {
      this.oBlockUI.stop();
      if (!response.IsSuccess) {
        if (response.Message.startsWith('ERR-')) {
          this.oMessageService.error(this.sTitlePage, response.Message);
        } else {
          this.oMessageService.warning(this.sTitlePage, response.Message);
        }
        return;
      }
      this.sApellidoPaternoOGTU = '';
      this.sApellidoMaternoOGTU = '';
      this.sNombresOGTU = '';
    });
  }
  fnSiguienteModal() {
    const warningFormulario = this.ValidarFormulario();
    if (warningFormulario !== null) {
      this.oMessageService.warning(this.sTitlePage, warningFormulario);
      return;
    }
    this.nCurrentSectionModal = 2;
  }
  fnGuardar() {
    const warningFormulario = this.ValidarFormulario();
    if (warningFormulario !== null) {
      this.oMessageService.warning(this.sTitlePage, warningFormulario);
      return;
    }
    const warningArchivo = this.ValidarCargaArchivo();
    if (warningArchivo !== null) {
      this.oMessageService.warning(this.sTitlePage, warningArchivo);
      return;
    }
    this.Guardar();
  }
  // END - Funciones modal

  CargarFormularioXId() {
    this.oBlockUI.start('Cargando Formulario...');
    this.oMunicipalidadService.Get(this.nIdEntidad).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.nIdEntidad = response.Data.nIdEntidad;
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
        this.sRepresentante = response.Data.sRepresentante;
      } else {

      }
      this.oBlockUI.stop();
    });
  }
  CargarFormularios() {
    this.oBlockUI.start('Cargando Formularios...');
    this.oMunicipalidadService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
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
    this.oBlockUI.start('Guardando Formulario...');
    if (this.nCurrentOption === 1) {
      this.oMunicipalidadService.Insert(
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
        this.sRepresentante
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.nCurrentSectionModal = 1;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarFormularios();
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
      this.oMunicipalidadService.Update(
        this.nIdEntidad,
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
        this.sRepresentante
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarFormularios();
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
  // INI - METODOS DE LLENADO DE COMBOS
  CargarHoras() {
    this.lstHoras = [];
    for (let iHoras = 0; iHoras < 24; iHoras++) {
      if (iHoras >= 10) {
        this.lstHoras.push( {sCodigo: `${iHoras}`, sDescription: `${iHoras}`});
      } else {
        this.lstHoras.push( {sCodigo: `0${iHoras}`, sDescription: `0${iHoras}`});
      }
    }
  }
  CargarMinutos() {
    this.lstMinutos = [];
    for (let iMinutos = 0; iMinutos < 60; iMinutos++) {
      if (iMinutos >= 10) {
        this.lstMinutos.push( {sCodigo: `${iMinutos}`, sDescription: `${iMinutos}`});
      } else {
        this.lstMinutos.push( {sCodigo: `0${iMinutos}`, sDescription: `0${iMinutos}`});
      }
    }
  }
  CargarTipoDocOperadorEmp() {
    this.lstTipoDocumentoOEMP = [];
    this.oComboService.GetTipoDoc('OPEEMP').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoDocumentoOEMP = response.Data;
      }
    });
  }
  CargarTipoDocOperadorOGTU() {
    this.lstTipoDocumentoOGTU =  [];
    this.oComboService.GetTipoDoc('OPESUC').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoDocumentoOGTU = response.Data;
      }
    });
  }
  // INI - METODOS DE LIMPIEZA
  LimpiarCampos() {
    this.nIdEntidad = 0;
  }
  LimpiarDatosVehiculo() {

  }
  LimpiarOperadorOgtu() {

  }
  LimpiarOperadorEmpresa() {

  }
  ValidarFormulario() {
    return null;
  }
  ValidarCargaArchivo() {
    return null;
  }
}
