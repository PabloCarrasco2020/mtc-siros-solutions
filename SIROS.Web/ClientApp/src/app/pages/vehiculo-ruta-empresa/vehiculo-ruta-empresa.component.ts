import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService, VehiculoRutaEmpresaService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { ActivatedRoute, Router } from '@angular/router';
import { VehiculoRutaEmpresaModel } from 'src/app/models/vehiculo-ruta-empresa.model';
import { SunarpService } from '../../services/sunarp.service';

declare var $: any;

@Component({
  selector: 'app-vehiculo-ruta-empresa',
  templateUrl: './vehiculo-ruta-empresa.component.html',
  styleUrls: ['./vehiculo-ruta-empresa.component.css']
})
export class VehiculoRutaEmpresaComponent implements OnInit {

  // =============================
  // GLOBALES DEL COMPONENTE

  public FILTRO_X_PLACA = 1;

  public OPTION_NUEVO = 1;
  public OPTION_EDITAR = 2;

  public MODAL_PAGINA_01 = 1;

  // =============================

  // PRINCIPALES
  sTitlePage: string = 'Vehiculos de Ruta de Empresa';
  sDependencyName: string = '';

  oModel: VehiculoRutaEmpresaModel = new VehiculoRutaEmpresaModel();
  nIdEmpresa: number = 0;
  sEmpresa: string = '';
  nIdRutaXEmp: number = 0;
  sRutaXEmp: string = '';

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  // COMBOS
  lstEstacionesServicio: any[] = [];
  lstSucursales: any[] = [];
  lstCombustibles: any[] = [];

  // BUSQUEDA
  nTipoFiltro: number = this.FILTRO_X_PLACA;
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private activatedRoute: ActivatedRoute,
    private oVehiculoRutaEmpresaService: VehiculoRutaEmpresaService,
    private oSunarpService: SunarpService,
    private oComboService: ComboService,
    private oMessageService: MessageService
    ) {
      this.nIdEmpresa = Number(this.activatedRoute.snapshot.params.nIdEmpresa);
      this.sEmpresa = this.activatedRoute.snapshot.params.sEmpresa;
      this.nIdRutaXEmp = Number(this.activatedRoute.snapshot.params.nIdRutaXEmp);
      this.sRutaXEmp = this.activatedRoute.snapshot.params.sRutaXEmp;
      this.sDependencyName = `${this.sEmpresa} | ${this.sRutaXEmp}`;
      this.CargarEstacionesServicio();
      this.CargarSucursales();
      this.CargarCombustibles();
      this.CargarVehiculosRutaEmpresa();
      this.LimpiarCampos();
  }

  ngOnInit() {
    $(document).prop('title', `SIROS - ${this.sTitlePage}`);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarVehiculosRutaEmpresa();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarVehiculosRutaEmpresa();
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarVehiculosRutaEmpresa();
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
    this.oModel.nIdVehXEmp = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarVehiculoRutaEmpresaXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar este Vehiculo de la Ruta de Empresa?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Vehiculo de la Ruta de Empresa.');
        this.oVehiculoRutaEmpresaService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarVehiculosRutaEmpresa();
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

  CargarVehiculosRutaEmpresa() {
    this.oBlockUI.start('Cargando Vehiculos de la Ruta de Empresa...');
    console.log(this.sFilter);
    // tslint:disable-next-line: max-line-length
    this.oVehiculoRutaEmpresaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}@${this.nIdEmpresa}@${this.nIdRutaXEmp}`)
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

  CargarVehiculoRutaEmpresaXId() {
    this.oBlockUI.start('Cargando Ruta de Empresa...');
    this.oVehiculoRutaEmpresaService.Get(this.oModel.nIdVehXEmp)
    .then((oResponse: ResponseModel<VehiculoRutaEmpresaModel>) => {
      if (oResponse.IsSuccess) {
        this.oModel = oResponse.Data;
        this.CargarSucursales();
      } else {

      }
      this.oBlockUI.stop();
    });
  }

  Guardar() {
    this.oBlockUI.start('Guardando Vehiculo de la Ruta de Empresa...');

    this.oModel.nIdVehXEmp = Number(this.oModel.nIdVehXEmp);
    this.oModel.nIdEmpresa = Number(this.nIdEmpresa);
    this.oModel.nIdRutaXEmp = Number(this.nIdRutaXEmp);
    this.oModel.nIdEstServicio = Number(this.oModel.nIdEstServicio);
    this.oModel.nIdSucursalXEs = Number(this.oModel.nIdSucursalXEs);
    this.oModel.nIdCombustible = Number(this.oModel.nIdCombustible);
    this.oModel.nAsientos = Number(this.oModel.nAsientos);

    if (this.nCurrentOption === this.OPTION_NUEVO) {
      this.oVehiculoRutaEmpresaService.Insert(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.nCurrentSectionModal = this.MODAL_PAGINA_01;
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarVehiculosRutaEmpresa();
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
      this.oVehiculoRutaEmpresaService.Update(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarVehiculosRutaEmpresa();
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

  ConsultarPlaca() {
    this.oBlockUI.start('Consultando Placa...');
    this.oModel.sAnioFab = '';
    this.oModel.sAnioModelo = '';
    this.oModel.sMarca = '';
    this.oModel.nAsientos = 0;

    this.oSunarpService.ConsultaPlaca(this.oModel.sPlaca).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        if (response.Data.Vehiculo) {
          this.oModel.sAnioFab = response.Data.Vehiculo.ano_fabricacion;
          this.oModel.sAnioModelo = response.Data.Vehiculo.an_titu;
          this.oModel.sMarca = response.Data.Vehiculo.marca;
          this.oModel.nAsientos = Number(response.Data.Vehiculo.asientos);
        }
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }

  OnEstacionServicioChange() {
    this.CargarSucursales();
    this.oModel.nIdSucursalXEs = -1;
  }

  OnPlacaChange() {
    this.oModel.sAnioFab = '';
    this.oModel.sAnioModelo = '';
    this.oModel.sMarca = '';
    this.oModel.nAsientos = 0;
  }

  /***** CARGAR COMBOS *****/

  CargarEstacionesServicio() {
    this.lstEstacionesServicio = [];
    this.oComboService.GetEstacionServicioXEntidad().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstEstacionesServicio = response.Data;
      }
    });
  }

  CargarSucursales() {
    this.lstSucursales = [];
    this.oComboService.GetSucursalesXEst(this.oModel.nIdEstServicio).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstSucursales = response.Data;
      }
    });
  }

  CargarCombustibles() {
    this.lstCombustibles = [];
    this.oComboService.GetCombustibles().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstCombustibles = response.Data;
      }
    });
  }

  LimpiarCampos() {
    this.oModel = new VehiculoRutaEmpresaModel();
    this.oModel.nIdVehXEmp = 0;
    this.oModel.nIdEmpresa = 0;
    this.oModel.nIdRutaXEmp = 0;
    this.oModel.nIdEstServicio = -1;
    this.oModel.nIdSucursalXEs = -1;
    this.oModel.nIdCombustible = -1;
    this.oModel.sPlaca = '';
    this.oModel.sAnioFab = '';
    this.oModel.sAnioModelo = '';
    this.oModel.sMarca = '';
    this.oModel.nAsientos = 0;
  }

  ValidarDatosFormulario(): string {
    if (Number(this.oModel.nIdEstServicio) === -1) {
      return 'Debe seleccionar una Estacion de Servicio.';
    }
    if (Number(this.oModel.nIdSucursalXEs) === -1) {
      return 'Debe seleccionar una Sucursal.';
    }
    if (Number(this.oModel.nIdCombustible) === -1) {
      return 'Debe seleccionar un Combustible.';
    }

    if (this.oModel.sPlaca.length === 0) {
      return 'Debe ingresar una Placa';
    }

    if (this.oModel.sAnioFab.length === 0 ||
       this.oModel.sAnioModelo.length === 0 ||
       this.oModel.sMarca.length === 0 ||
       this.oModel.nAsientos <= 0) {
      return 'Debe consultar la información de la Placa.';
    }

    return null;
  }
}
