import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService, ReniecService, ONGEIService, OperadorEmpresaService} from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { OperadorEmpresaModel } from 'src/app/models/operador-empresa.model';

declare var $: any;

@Component({
  selector: 'app-operador-empresa',
  templateUrl: './operador-empresa.component.html',
  styleUrls: ['./operador-empresa.component.css']
})
export class OperadorEmpresaComponent implements OnInit {

  // =============================
  // GLOBALES DEL COMPONENTE

  public FILTRO_X_NRO_DOCUMENTO = 1;
  public FILTRO_X_NOMBRE = 2;

  public OPTION_NUEVO = 1;
  public OPTION_EDITAR = 2;

  public MODAL_PAGINA_01 = 1;
  public MODAL_PAGINA_02 = 2;

  public COMBO_SIN_DATO = 0;

  public TIPO_DOCUMENTO_INVALIDO = -1;
  public TIPO_DOCUMENTO_DNI = 1;
  public TIPO_DOCUMENTO_CE = 2;

  // PRINCIPALES
  sTitlePage: string = 'Operador de Empresa';
  sDependencyName: string = '';

  oModel: OperadorEmpresaModel = new OperadorEmpresaModel();
  nIdEmpresa: number = 0;

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  // BUSQUEDA
  nTipoFiltro: number = this.FILTRO_X_NRO_DOCUMENTO;
  sFilter: string = '';

  // COMBOS
  lstTipoDocumento: any[] = [];
  lstTipoOperador: any[] = [];

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private activatedRoute: ActivatedRoute,
    private oOperadorEmpresaService: OperadorEmpresaService,
    private oComboService: ComboService,
    private oMessageService: MessageService,
    private oReniecService: ReniecService,
    private oONGEIService: ONGEIService
    ) {
      this.nIdEmpresa = Number(this.activatedRoute.snapshot.params.nIdEmpresa);
      this.sDependencyName = this.activatedRoute.snapshot.params.sEmpresa;
      this.CargarOperadores();
      this.CargarTipoDocumento();
      this.CargarTipoOperador();
    }

  ngOnInit() {
    $(document).prop('title', `SIROS - ${this.sTitlePage}`);
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarOperadores();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarOperadores();
  }

  fnNew() {
    this.nCurrentOption = this.OPTION_NUEVO;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnEdit(nId: number) {
    this.nCurrentOption = this.OPTION_EDITAR;
    this.LimpiarCampos();
    this.oModel.nIdNominaXEmpresa = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarOperadorXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar este Operador de Empresa?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Operador de Empresa.');
        this.oOperadorEmpresaService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarOperadores();
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
    this.CargarOperadores();
  }

  // INI - Funciones modal
  fnGuardar() {
    const warningDatos = this.ValidarDatos();
    if (warningDatos) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }
  // END - Funciones modal

  OnChangeTipoDocumento() {
    this.oModel.sNroDocumento = '';
    this.oModel.sApePaterno = '';
    this.oModel.sApeMaterno = '';
    this.oModel.sNombre = '';
    this.oModel.nIdTipoOper = -1;
    this.oModel.sFecNacimiento = '';
    this.oModel.sFoto = '';
  }

  CargarOperadorXId() {
    this.oBlockUI.start('Cargando Operador de Empresa...');
    this.oOperadorEmpresaService.Get(this.oModel.nIdNominaXEmpresa)
    .then((response: ResponseModel<OperadorEmpresaModel>) => {
      if (response.IsSuccess) {
        this.oModel = response.Data;
      } else {

      }
      this.oBlockUI.stop();
    });
  }

  CargarOperadores() {
    this.oBlockUI.start('Cargando Operadores de Empresa...');
    this.oOperadorEmpresaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}@${this.nIdEmpresa}`)
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
    this.oBlockUI.start('Guardando Operador de Empresa...');

    this.oModel.nIdEmpresa = this.nIdEmpresa;
    this.oModel.nIdNominaXEmpresa = Number(this.oModel.nIdNominaXEmpresa);
    this.oModel.nIdTpDocumento = Number(this.oModel.nIdTpDocumento);
    this.oModel.nIdTipoOper = Number(this.oModel.nIdTipoOper);

    if (this.nCurrentOption === this.OPTION_NUEVO) {
      this.oOperadorEmpresaService.Insert(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarOperadores();
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
      this.oOperadorEmpresaService.Update(this.oModel).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarOperadores();
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

  CargarTipoDocumento() {
    this.lstTipoDocumento = [];
    this.oComboService.GetTipoDoc('OPEEMP').then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.lstTipoDocumento = response.Data;
      }
    });
  }

  CargarTipoOperador() {
    this.lstTipoOperador = [];
    this.oComboService.GetTipoOperador('OPEEMP').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoOperador = response.Data;
      }
    });
  }

  ConsultarNroDocumento() {
    if (Number(this.oModel.nIdTpDocumento) === this.TIPO_DOCUMENTO_DNI) {

      if (this.oModel.sNroDocumento.length !== 8) {
        this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de DNI de 8 dígitos');
        return;
      }
      this.ConsultarDni();

    } else if (Number(this.oModel.nIdTpDocumento) === this.TIPO_DOCUMENTO_CE) {

      if (this.oModel.sNroDocumento.length !== 9) {
        this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de CE de 9 dígitos');
        return;
      }
      this.ConsultarCE();

    }
  }

  ConsultarDni() {
    this.oBlockUI.start('Consultando DNI...');
    this.oModel.sNombre = '';
    this.oModel.sApeMaterno = '';
    this.oModel.sApePaterno = '';
    this.oModel.sFoto = '';
    this.oModel.sFecNacimiento = '';

    this.oReniecService.ConsultaNumDoc(this.oModel.sNroDocumento).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.oModel.sNombre = response.Data.sNombres;
        this.oModel.sApePaterno = response.Data.sApellidoPaterno;
        this.oModel.sApeMaterno = response.Data.sApellidoMaterno;
        this.oModel.sFoto = `${response.Data.sFoto}`;
        this.oModel.sFecNacimiento = response.Data.sFechaNacimiento;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }

  ConsultarCE() {
    this.oBlockUI.start('Consultando CE...');
    this.oModel.sNombre = '';
    this.oModel.sApeMaterno = '';
    this.oModel.sApePaterno = '';
    this.oModel.sFoto = '';
    this.oModel.sFecNacimiento = '';

    this.oONGEIService.ConsultaCarnetExt(this.oModel.sNroDocumento).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.oModel.sNombre = response.Data.sNombres;
        this.oModel.sApePaterno = response.Data.sPrimerApellido;
        this.oModel.sApeMaterno = response.Data.sSegundoApellido;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }

  LimpiarCampos() {
    this.oModel.nIdNominaXEmpresa = 0;
    this.oModel.nIdEmpresa = 0;
    this.oModel.nIdTpDocumento = -1;
    this.oModel.sNroDocumento = '';
    this.oModel.sApePaterno = '';
    this.oModel.sApeMaterno = '';
    this.oModel.sNombre = '';
    this.oModel.nIdTipoOper = -1;
    this.oModel.sFecNacimiento = '';
    this.oModel.sFoto = '';
  }

  ValidarDatos(): any {
    if (
      Number(this.oModel.nIdTipoOper) === -1 ||
      Number(this.oModel.nIdTpDocumento) === -1
      ) {
      return 'Seleccione los campos con (*), son obligatorios';
    }
    if (
        this.oModel.sNombre.length === 0 ||
        this.oModel.sApePaterno.length === 0 ||
        // this.oModel.sApeMaterno.length === 0 ||
        this.oModel.sFecNacimiento.length === 0
      ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }

}
