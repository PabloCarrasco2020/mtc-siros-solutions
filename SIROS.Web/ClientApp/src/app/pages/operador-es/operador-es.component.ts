import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, MessageService, ReniecService, SucursalEsService, ONGEIService } from 'src/app/services/services.index';
import { OperadorEsService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';

declare var $: any;
@Component({
  selector: 'app-operador-es',
  templateUrl: './operador-es.component.html',
  styles: []
})
export class OperadorEsComponent implements OnInit {

  sTitlePage: string = 'Sucursal de estación de servicio';
  sSucursalName: string = '';
  dNow: Date = new Date();

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;

  DNI_VALUE = 1;
  CE_VALUE = 2;
  // COMBOS
  lstTipoDocumento: any[] = [];
  lstTipoOperador: any[] = [];

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';

  nIdSucursalxES: number = 0;
  // FORMULARIO
  nIdNominaXSucursal: number = 0;
  nIdTpDocumento: number = -1;
  sNroDocumento: string = '';
  sApePaterno: string = '';
  sApeMaterno: string = '';
  sNombre: string = '';
  nIdTipoOper: number = -1;
  sFecNacimiento: string = '';
  sFoto: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private activatedRoute: ActivatedRoute,
    private oOperadorEsService: OperadorEsService,
    private oONGEIService: ONGEIService,
    private oSucursalEsService: SucursalEsService,
    private oComboService: ComboService,
    private oMessageService: MessageService,
    private oReniecService: ReniecService
    ) {
      this.nIdSucursalxES = Number(this.activatedRoute.snapshot.params.id);
      this.sSucursalName = this.activatedRoute.snapshot.params.sucursal;
      this.CargarOperadores();
      this.CargarTipoDocumento();
      this.CargarTipoOperador();
    }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Operador de sucursal de estación de servicio');
  }
  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarOperadores();
  }
  fnBuscarDocumento() {
    if (Number(this.nIdTpDocumento) === this.DNI_VALUE) {
      if (this.sNroDocumento.length !== 8 ) {
        this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de DNI de 8 dígitos');
        return;
      }
      this.ConsultarDni();
    } else if (Number(this.nIdTpDocumento) === this.CE_VALUE) {
      if (this.sNroDocumento.length !== 9 ) {
        this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de CE de 9 dígitos');
        return;
      }
      this.ConsultarCE();
    }
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarOperadores();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }
  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.LimpiarCampos();
    this.nIdNominaXSucursal = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarOperadorXId();
  }
  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar operador de estación de servicio?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando operador de estación de servicio.');
        this.oOperadorEsService.Delete(nId).then((response: ResponseModel<any>) => {
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
    if (warningDatos !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }
  // END - Funciones modal

  OnChangeTipoDocumento() {
    this.sNroDocumento = '';
    this.sApePaterno = '';
    this.sApeMaterno = '';
    this.sNombre = '';
    this.nIdTipoOper = -1;
    this.sFecNacimiento = '';
    this.sFoto = '';
  }
  CargarOperadorXId() {
    this.oBlockUI.start('Cargando operador...');
    this.oOperadorEsService.Get(this.nIdNominaXSucursal).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.nIdNominaXSucursal = response.Data.nIdNominaXSucursal;
        this.nIdTpDocumento = Number(response.Data.nIdTpDocumento);
        this.sNroDocumento = response.Data.sNroDocumento;
        this.sNombre = response.Data.sNombre;
        this.sApePaterno = response.Data.sApePaterno;
        this.sApeMaterno = response.Data.sApeMaterno;
        this.nIdTipoOper = Number(response.Data.nIdTipoOper);
        this.sFoto = response.Data.sFoto;
        this.sFecNacimiento = response.Data.sFecNacimiento;
      } else {

      }
      this.oBlockUI.stop();
    });
  }
  CargarOperadores() {
    this.oBlockUI.start('Cargando operadores...');
    this.oOperadorEsService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}@${this.nIdSucursalxES}`)
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
    this.oBlockUI.start('Guardando Operador...');
    if (this.nCurrentOption === 1) {
      this.oOperadorEsService.Insert(
        Number(this.nIdSucursalxES),
        Number(this.nIdTpDocumento),
        this.sNroDocumento,
        this.sApePaterno,
        this.sApeMaterno,
        this.sNombre,
        Number(this.nIdTipoOper),
        this.sFecNacimiento,
        this.sFoto
      ).then((response: ResponseModel<any>) => {
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
    } else if (this.nCurrentOption === 2) {
      this.oOperadorEsService.Update(
        Number(this.nIdNominaXSucursal),
        Number(this.nIdTipoOper),
        this.sFecNacimiento
      ).then((response: ResponseModel<any>) => {
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
    this.oComboService.GetTipoDoc('OPESUC').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoDocumento = response.Data;
      }
    });
  }
  CargarTipoOperador() {
    this.lstTipoOperador = [];
    this.oComboService.GetTipoOperador('OPESUC').then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstTipoOperador = response.Data;
      }
    });
  }
  ConsultarCE() {
    this.oBlockUI.start('Consultando CE...');
    this.sNombre = '';
    this.sApeMaterno = '';
    this.sApePaterno = '';
    this.sFoto = '';
    this.sFecNacimiento = '';

    this.oONGEIService.ConsultaCarnetExt(this.sNroDocumento).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.sNombre = response.Data.sNombres;
        this.sApePaterno = response.Data.sPrimerApellido;
        this.sApeMaterno = response.Data.sSegundoApellido;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }
  ConsultarDni() {
    if (this.sNroDocumento.length !== 8) {
      this.oMessageService.warning(this.sTitlePage, 'Ingrese Número de DNI de 8 dígitos');
      return;
    }
    this.oBlockUI.start('Consultando DNI...');
    this.sNombre = '';
    this.sApeMaterno = '';
    this.sApePaterno = '';
    this.sFoto = '';
    this.sFecNacimiento = '';
    this.oReniecService.ConsultaNumDoc(this.sNroDocumento).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
        this.sNombre = response.Data.sNombres;
        this.sApeMaterno = response.Data.sApellidoMaterno;
        this.sApePaterno = response.Data.sApellidoPaterno;
        this.sFecNacimiento = response.Data.sFechaNacimiento;
        this.sFoto = `${response.Data.sFoto}`;
      } else {
        this.oMessageService.warning(this.sTitlePage, response.Message);
      }
      this.oBlockUI.stop();
    });
  }
  LimpiarCampos() {
    this.nIdNominaXSucursal = 0;
    this.nIdTpDocumento = -1;
    this.sNroDocumento = '';
    this.sApePaterno = '';
    this.sApeMaterno = '';
    this.sNombre = '';
    this.nIdTipoOper = -1;
    this.sFecNacimiento = '';
    this.sFoto = '';
  }
  ValidarDatos(): any {
    if (
      Number(this.nIdTipoOper) === -1 ||
      Number(this.nIdTpDocumento) === -1
      ) {
      return 'Seleccione los campos con (*), son obligatorios';
    }
    if (
        this.sNombre.length === 0 ||
        this.sApePaterno.length === 0 ||
        this.sApeMaterno.length === 0 ||
        this.sFecNacimiento.length === 0
      ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    const dFecNacimiento: Date = new Date(this.sFecNacimiento);
    dFecNacimiento.setFullYear(dFecNacimiento.getFullYear() + 18);
    if (  dFecNacimiento > this.dNow ) {
      return 'Fecha de nacimiento ingresado no corresponde a un mayor de edad';
    }
    const dDifFec = this.dNow.getFullYear() - dFecNacimiento.getFullYear();
    if (Number(dDifFec) > 90) {
      return 'Ingrese fecha de nacimiento correctamente.';
    }
    return null;
  }
  KeyUpNumber(event: any) {
    const code: string = event.code;
    if (code.startsWith('Key') || code.startsWith('Space')) {
      if (code !== 'Comma') {
        event.preventDefault();
      }
    }
  }
  KeyUpLetter(event: any) {
    const code: string = event.code;
    if (code.startsWith('Digit')) {
      event.preventDefault();
    }
  }
}
