import { RutaEmpresaModel } from './../../models/ruta-empresa.model';
import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { ContratoEsModel } from 'src/app/models/contrato-es.model';
import { ActivatedRoute, Router } from '@angular/router';
import { RutaEmpresaService } from '../../services/ruta-empresa.service';

declare var $: any;

@Component({
  selector: 'app-rutas-empresa',
  templateUrl: './rutas-empresa.component.html',
  styleUrls: ['./rutas-empresa.component.css']
})
export class RutasEmpresaComponent implements OnInit {

  // =============================
  // GLOBALES DEL COMPONENTE

  public FILTRO_X_NOMBRE_RUTA = 1;
  public FILTRO_X_ITINERARIO = 2;

  public OPTION_NUEVO = 1;
  public OPTION_EDITAR = 2;

  public MODAL_PAGINA_01 = 1;

  // =============================

  // PRINCIPALES
  sTitlePage: string = 'Rutas de Empresa';
  sDependencyName: string = '';

  oModel: RutaEmpresaModel = new RutaEmpresaModel();
  nIdEmpresa: number = 0;

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  // COMBOS
  lstRutas: any[] = [];

  // BUSQUEDA
  nTipoFiltro: number = this.FILTRO_X_NOMBRE_RUTA;
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private activatedRoute: ActivatedRoute,
    private oRutaEmpresaService: RutaEmpresaService,
    private oComboService: ComboService,
    private oMessageService: MessageService,
    private oRouter: Router
    ) {
      this.nIdEmpresa = Number(this.activatedRoute.snapshot.params.nIdEmpresa);
      this.sDependencyName = this.activatedRoute.snapshot.params.sEmpresa;
      this.CargarRutas();
      this.CargarRutasEmpresa();
      this.LimpiarCampos();
  }

  ngOnInit() {
    $(document).prop('title', `SIROS - ${this.sTitlePage}`);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarRutasEmpresa();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutasEmpresa();
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRutasEmpresa();
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
    this.oModel.nIdRutaXEmp = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarRutaEmpresaXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar esta Ruta de Empresa?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Ruta de Empresa.');
        this.oRutaEmpresaService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarRutasEmpresa();
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

  CargarRutasEmpresa() {
    this.oBlockUI.start('Cargando Rutas de Empresa...');
    console.log(this.sFilter);
    this.oRutaEmpresaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}@${this.nIdEmpresa}`)
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

  CargarRutaEmpresaXId() {
    this.oBlockUI.start('Cargando Ruta de Empresa...');
    this.oRutaEmpresaService.Get(this.oModel.nIdRutaXEmp)
    .then((oResponse: ResponseModel<RutaEmpresaModel>) => {
      if (oResponse.IsSuccess) {
        this.oModel = oResponse.Data;
      } else {

      }
      this.oBlockUI.stop();
    });
  }

  Guardar() {
    this.oBlockUI.start('Guardando Ruta de Empresa...');

    this.oModel.nIdRutaXEmp = Number(this.oModel.nIdRutaXEmp);
    this.oModel.nIdEmpresa = Number(this.nIdEmpresa);
    this.oModel.nIdRuta = Number(this.oModel.nIdRuta);

    if (this.nCurrentOption === this.OPTION_NUEVO) {
      this.oRutaEmpresaService.Insert(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.nCurrentSectionModal = this.MODAL_PAGINA_01;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarRutasEmpresa();
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
      this.oRutaEmpresaService.Update(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarRutasEmpresa();
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

  CargarRutas() {
    this.lstRutas = [];
    this.oComboService.GetRutas().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstRutas = response.Data;
      }
    });
  }

  LimpiarCampos() {
    this.oModel = new RutaEmpresaModel();
    this.oModel.nIdRutaXEmp = 0;
    this.oModel.nIdEmpresa = 0;
    this.oModel.nIdRuta = -1;
    this.oModel.sNumDocAuto = '';
    this.oModel.sFecIniVig = '';
    this.oModel.sFecVenVig = '';
  }

  ValidarDatosFormulario(): string {
    if (Number(this.oModel.nIdRuta) === -1) {
      return 'Debe seleccionar una Ruta.';
    }

    if (
      this.oModel.sNumDocAuto.length === 0 ||
      this.oModel.sFecIniVig.length === 0 ||
      this.oModel.sFecVenVig.length === 0
    ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }

    const dFecIniVigencia = new Date(this.oModel.sFecIniVig);
    const sFecFinVigencia = new Date(this.oModel.sFecVenVig);

    if (!(sFecFinVigencia > dFecIniVigencia)) {
      return 'La Fecha Fin debe ser mayor que la Fecha de Inicio.';
    }

    return null;
  }

  fnVehiculos(nIdRutaXEmp: number) {
    const oData = this.oIndexData.Items.find(x => Number(x.Id) === Number(nIdRutaXEmp));
    this.oRouter.navigate(['/OGTU/vehiculoRutaEmpresa/', this.nIdEmpresa, this.sDependencyName, nIdRutaXEmp, oData.Column3]);
  }
}
