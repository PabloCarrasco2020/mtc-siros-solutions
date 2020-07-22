import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService, ContratoEsService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { ContratoEsModel } from 'src/app/models/contrato-es.model';

declare var $: any;

@Component({
  selector: 'app-contrato-es',
  templateUrl: './contrato-es.component.html',
  styleUrls: ['./contrato-es.component.css']
})
export class ContratoESComponent implements OnInit {

  // =============================
  // GLOBALES DEL COMPONENTE

  public FILTRO_X_RUC = 1;
  public FILTRO_X_RAZON_SOCIAL = 2;

  public OPTION_NUEVO = 1;
  public OPTION_EDITAR = 2;

  public MODAL_PAGINA_01 = 1;

  // =============================

  // PRINCIPALES
  sTitlePage: string = 'Contrato de Estación de Servicios';
  oModel: ContratoEsModel = new ContratoEsModel();

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  // COMBOS
  lstEstacionesServicio: any[] = [];

  // BUSQUEDA
  nTipoFiltro: number = this.FILTRO_X_RUC;
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oContratoEsService: ContratoEsService,
    private oComboService: ComboService,
    private oMessageService: MessageService
    ) {
    this.CargarEstacionesServicio();
    this.CargarContratos();
    this.LimpiarCampos();
  }

  ngOnInit() {
    $(document).prop('title', `SIROS - ${this.sTitlePage}`);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarContratos();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarContratos();
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarContratos();
  }

  fnNew() {
    this.nCurrentOption = this.OPTION_NUEVO;
    this.nCurrentSectionModal = this.MODAL_PAGINA_01;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnEdit(nId: number) {
    this.nCurrentOption = this.OPTION_EDITAR;
    this.nCurrentSectionModal = this.MODAL_PAGINA_01;
    this.LimpiarCampos();
    this.oModel.nIdEstServicioEnt = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarContratoXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar el Contrato de Estación de Servicio?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Contrato de Estación de Servicio.');
        this.oContratoEsService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarContratos();
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

  CargarContratos() {
    this.oBlockUI.start('Cargando Contratos de Estaciones de Servicios...');
    console.log(this.sFilter);
    this.oContratoEsService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
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
    const warningDatosFormulario = this.ValidarDatosFormulario();
    if (warningDatosFormulario) {
      this.oMessageService.warning(this.sTitlePage, warningDatosFormulario);
      return;
    }
    this.Guardar();
  }

  CargarContratoXId() {
    this.oBlockUI.start('Cargando Contrato de Estación de Servicio...');
    this.oContratoEsService.Get(this.oModel.nIdEstServicioEnt)
    .then((oResponse: ResponseModel<ContratoEsModel>) => {
      if (oResponse.IsSuccess) {
        this.oModel = oResponse.Data;
      } else {

      }
      this.oBlockUI.stop();
    });
  }

  Guardar() {
    this.oBlockUI.start('Guardando Contrato...');
    this.oModel.nIdEstServicio = Number(this.oModel.nIdEstServicio);
    if (this.nCurrentOption === this.OPTION_NUEVO) {
      this.oContratoEsService.Insert(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.nCurrentSectionModal = this.MODAL_PAGINA_01;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarContratos();
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
      this.oContratoEsService.Update(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarContratos();
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

  CargarEstacionesServicio() {
    this.lstEstacionesServicio = [];
    this.oComboService.GetEstacionServicio().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstEstacionesServicio = response.Data;
      }
    });
  }

  LimpiarCampos() {
    this.oModel = new ContratoEsModel();
    this.oModel.nIdEstServicioEnt = 0;
    this.oModel.nIdEstServicio = -1;
    this.oModel.sNumContrato = '';
    this.oModel.sFecContrato = '';
    this.oModel.sFecIniVigencia = '';
    this.oModel.sFecFinVigencia = '';
  }

  ValidarDatosFormulario(): string {
    if (Number(this.oModel.nIdEstServicio) === -1) {
      return 'Debe seleccionar una Estacion de Servicio.';
    }

    if (
      this.oModel.sNumContrato.length === 0 ||
      this.oModel.sFecContrato.length === 0 ||
      this.oModel.sFecIniVigencia.length === 0 ||
      this.oModel.sFecFinVigencia.length === 0
    ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }

    const dFecContrato = new Date(this.oModel.sFecContrato);
    const dFecIniVigencia = new Date(this.oModel.sFecIniVigencia);
    const sFecFinVigencia = new Date(this.oModel.sFecFinVigencia);

    if (!(dFecIniVigencia >= dFecContrato)) {
      return 'La Fecha de Inicio debe ser mayor o igual a la Fecha de Contrato.';
    }
    if (!(sFecFinVigencia > dFecIniVigencia)) {
      return 'La Fecha Fin debe ser mayor que la Fecha de Inicio.';
    }

    return null;
  }

}
