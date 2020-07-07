import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MunicipalidadService, ComboService, SunatService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
declare var $: any;

@Component({
  selector: 'app-municipalidad',
  templateUrl: './municipalidad.component.html',
  styleUrls: ['./municipalidad.component.css']
})
export class MunicipalidadComponent implements OnInit {
  sTitlePage: string = 'Municipalidades';

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  sFilter: string = '';

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
  // FORMULARIO
  sRuc: string = '';
  sRazonSocial: string = '';
  nTipoVia: number = 0;
  sVia: string = '';
  nCentroPoblado: number = 0;
  sCentroPoblado: string = '';
  nIdNumeroManzana: number = 0;
  sNumeroManzana: string = '';
  nIdLoteInterior: number = 0;
  sLoteInterior: string = '';
  sReferencia: string = '';
  sCodDepartamento: string = '00';
  sCodProvincia: string = '00';
  sCodDistrito: string = '00';
  sRepresentante: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oMunicipalidadService: MunicipalidadService,
    private oComboService: ComboService,
    private oSunatService: SunatService,
    private oMessageService: MessageService
    ) {
    this.CargarMunicipalidades();
    this.CargarTipoVia();
    this.CargarCentroPoblado();
    this.CargarNumeroManzana();
    this.CargarLoteInterior();
    this.CargarDepartamento();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Municipalidad');
  }

  fnBuscar(sFilter: string) {
    this.nCurrentPage = 1;
    this.sFilter = sFilter;
    this.CargarMunicipalidades();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarMunicipalidades();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.nCurrentSectionModal = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarMunicipalidades();
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
  fnGuardar() {
    // const warningDatosEmpresa = this.ValidarDatosEmpresa();
    // if (warningDatosEmpresa !== null) {
    //   this.oMessageService.warning(this.sTitlePage, warningDatosEmpresa);
    //   return;
    // }
    this.Guardar();
  }
  // END - Funciones modal

  CargarMunicipalidades() {
    this.oBlockUI.start('Cargando Municipalidades...');
    this.oMunicipalidadService.GetAllByFilter(this.nCurrentPage, this.sFilter)
    .then((response: ResponseModel) => {

      if (response.IsSuccess) {
        this.oIndexData = response.Data;
      } else {
        this.oIndexData = new IndexModel();
        console.log('>>> Error en el servicio');
      }

      this.oBlockUI.stop();
    });
  }
  Guardar() {
    this.ParseListResponsablesToString();
    this.oBlockUI.start('Guardando Municipalidad...');
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
      ).then((response: ResponseModel) => {
        console.log(response);
        this.oBlockUI.stop();
        this.LimpiarCampos();
        this.oMessageService.success(this.sTitlePage, 'Se registró municipalidad correctamente');
      });
    } else if (this.nCurrentOption === 2) {

    }
  }
  CargarTipoVia() {
    this.lstTipoVia = [];
    this.oComboService.GetTipoVia().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstTipoVia = response.Data;
      }
    });
  }
  CargarCentroPoblado() {
    this.lstCentroPoblado = [];
    this.oComboService.GetCentroPoblado().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstCentroPoblado = response.Data;
      }
    });
  }
  CargarNumeroManzana() {
    this.lstNumeroManzana = [];
    this.oComboService.GetNumeroManzana().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstNumeroManzana = response.Data;
      }
    });
  }
  CargarLoteInterior() {
    this.lstLoteInterior = [];
    this.oComboService.GetLoteInterior().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstLoteInterior = response.Data;
      }
    });
  }
  CargarTipoDocReprLegal() {
    this.lstTipoDocReprLegal = [];
    this.oComboService.GetTipoDocRepresentanteLegal().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstTipoDocReprLegal = response.Data;
      }
    });
  }
  CargarTipoCargoReprLegal() {
    this.lstTipoCargoReprLegal = [];
    this.oComboService.GetCargoRepresentanteLegal().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstTipoCargoReprLegal = response.Data;
      }
    });
  }
  CargarDepartamento() {
    this.lstDepartamento = [];
    this.oComboService.GetDepartamento().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstDepartamento = response.Data;
      }
    });
  }
  CargarProvincia() {
    this.lstProvincia = [];
    this.oComboService.GetProvincia(this.sCodDepartamento).then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstProvincia = response.Data;
      }
    });
  }
  CargarDistrito() {
    this.lstDistrito = [];
    this.oComboService.GetDistrito(this.sCodDepartamento, this.sCodProvincia).then((response: ResponseModel) => {
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
    this.oSunatService.ConsultaRuc(this.sRuc).then((response: ResponseModel) => {
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
      }
      this.oBlockUI.stop();
    });
  }
  ParseListResponsablesToString() {
    this.sRepresentante = '1@43171962@Francis arthur poldark@Palomino@Marino@2¢1@43171967@juan jose@condori@pumacahua@8';
  }
  LimpiarCampos() {
    this.sRuc = '';
    this.sRazonSocial = '';
    this.nTipoVia = 0;
    this.sVia = '';
    this.nCentroPoblado = 0;
    this.sCentroPoblado = '';
    this.nIdNumeroManzana = 0;
    this.sNumeroManzana = '';
    this.nIdLoteInterior = 0;
    this.sLoteInterior = '';
    this.sReferencia = '';
    this.sCodDepartamento = '00';
    this.sCodProvincia = '00';
    this.sCodDistrito = '00';
    this.sRepresentante = '';
    this.lstProvincia = [];
    this.lstDistrito = [];
  }
  ValidarDatosEmpresa(): any {
    if (this.sRuc.length !== 11) {
      return 'Ingrese el Número de RUC correctamente';
    }
    if (this.sRazonSocial.length === 0) {
      return 'Ingrese el Ruc válido';
    }
    if (
      this.nTipoVia === 0 ||
      this.nCentroPoblado === 0 ||
      this.nIdNumeroManzana === 0 ||
      this.nIdLoteInterior === 0 ||
      this.sCodDepartamento === '00' ||
      this.sCodProvincia === '00' ||
      this.sCodDistrito === '00'
      ) {
      return 'Seleccione los campos con (*), son obligatorios';
    }
    if (
        this.sVia.length === 0 ||
        this.sCentroPoblado.length === 0 ||
        this.sNumeroManzana.length === 0 ||
        this.sLoteInterior.length === 0 ||
        this.sReferencia.length === 0
      ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }
}
