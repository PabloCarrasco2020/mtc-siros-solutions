import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MunicipalidadService, ComboService, SunatService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
declare var $: any;

@Component({
  selector: 'app-municipalidad',
  templateUrl: './municipalidad.component.html',
  styleUrls: ['./municipalidad.component.css']
})
export class MunicipalidadComponent implements OnInit {


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
  sVia: string = '';
  nCentroPoblado: number = 0;
  sCentroPoblado: string = '';
  nIdNumeroManzana: number = 0;
  sNumeroManzana: string = '';
  nIdLoteInterior: number = 0;
  sLoteInterior: string = '';
  sReferencia: string = '';
  sCodDepartamento: string = '';
  sCodProvincia: string = '';
  sCodDistrito: string = '';
  sRepresentante: string = '';
  nTipoVia: number = 0;

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oMunicipalidadService: MunicipalidadService,
    private oComboService: ComboService,
    private oSunatService: SunatService
    ) {
    this.CargarMunicipalidades();
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
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarMunicipalidades();
  }
  // INI - Funciones modal
  fnBuscarRuc() {
    this.ConsultarRuc();
  }
  fnSiguienteModal() {
    this.nCurrentSectionModal = 2;
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
    this.oComboService.GetTipoVia().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstTipoVia = response.Data;
      }
    });
  }
  CargarProvincia() {
    this.lstProvincia = [];
    this.oComboService.GetTipoVia().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstProvincia = response.Data;
      }
    });
  }
  CargarDistrito() {
    this.lstDistrito = [];
    this.oComboService.GetTipoVia().then((response: ResponseModel) => {
      if ( response.IsSuccess) {
        this.lstDistrito = response.Data;
      }
    });
  }
  ConsultarRuc() {
    if (this.sRuc.length !== 12) {
      return;
    }
    this.sRazonSocial = '';
    this.sCodDepartamento = '0';
    this.oSunatService.ConsultaRuc(this.sRuc).then((response: ResponseModel) => {
      if (response.IsSuccess) {
        this.sRazonSocial = response.Data.sNombre;
        this.sCodDepartamento = response.Data.sCodDepartamento;
        this.sReferencia = response.Data.sReferencia;
      }
    });
  }
  LimpiarCampos() {
  }
}
