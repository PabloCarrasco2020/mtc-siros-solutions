import { Component, OnInit } from '@angular/core';
import { IndexModel } from '../../models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComboService, SunatService, MessageService, ReniecService, SucursalEsService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { Router } from '@angular/router';

declare var $: any;
@Component({
  selector: 'app-sucursal-es',
  templateUrl: './sucursal-es.component.html',
  styleUrls: ['./sucursal-es.component.css']
})
export class SucursalESComponent implements OnInit {
  sTitlePage: string = 'Sucursal de estación de servicio';

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;

  oIndexDataRepresentanteLegal: IndexModel = new IndexModel();
  // COMBOS
  lstEstacionServicio: any[] = [];
  lstTipoVia: any[] = [];
  lstCentroPoblado: any[] = [];
  lstNumeroManzana: any[] = [];
  lstLoteInterior: any[] = [];
  lstDepartamento: any[] = [];
  lstProvincia: any[] = [];
  lstDistrito: any[] = [];

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';
  // FORMULARIO
  nIdSucursalxES: number = 0;
  nIdEstServicio: number = -1;
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
  sLatitud: string = '';
  sLongitud: string = '';

  sRuc: string = '';
  sDireccion: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private oSucursalEsService: SucursalEsService,
    private oComboService: ComboService,
    private oSunatService: SunatService,
    private oMessageService: MessageService,
    private oRouter: Router
    ) {
    this.CargarSucursales();
    this.CargarEstacionServicio();
    this.CargarTipoVia();
    this.CargarCentroPoblado();
    this.CargarNumeroManzana();
    this.CargarLoteInterior();
    this.CargarDepartamento();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Sucursal de estación de servicio');
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarSucursales();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarSucursales();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }
  fnOperadores(id: number) {
    this.oRouter.navigate(['/OGTU/operadorES/', id]);
  }
  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.LimpiarCampos();
    this.nIdSucursalxES = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarSucursalXId();
  }
  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar la sucursal de estación de servicio?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando sucursal de estación de servicio.');
        this.oSucursalEsService.Delete(nId).then((response: ResponseModel<any>) => {
          if (response.IsSuccess) {
            this.oMessageService.success(this.sTitlePage, response.Message);
            this.oBlockUI.stop();
            this.CargarSucursales();
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
    this.CargarSucursales();
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
  fnGuardar() {
    const warningDatos = this.ValidarDatos();
    if (warningDatos !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }
  // END - Funciones modal

  CargarSucursalXId() {
    this.oBlockUI.start('Cargando estación de servicio...');
    this.oSucursalEsService.Get(this.nIdSucursalxES).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.nIdSucursalxES = response.Data.nIdSucursalxES;
        this.nIdEstServicio = Number(response.Data.nIdEstServicio);
        this.sRuc = response.Data.sRuc;
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
        this.sLatitud = response.Data.sLatitud === null ? '' : response.Data.sLatitud;
        this.sLongitud = response.Data.sLongitud === null ? '' : response.Data.sLongitud;
        this.CargarProvincia();
        this.CargarDistrito();
      } else {

      }
      this.oBlockUI.stop();
    });
  }
  CargarSucursales() {
    this.oBlockUI.start('Cargando Estaciones de servicios...');
    console.log(this.sFilter);
    this.oSucursalEsService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
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
    this.oBlockUI.start('Guardando Estación...');
    this.ParseOptionsToDirection();
    this.ParseOptionToRuc();
    if (this.nCurrentOption === 1) {
      this.oSucursalEsService.Insert(
        Number(this.nIdEstServicio),
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
        this.sLatitud,
        this.sLongitud,
        this.sRuc,
        this.sDireccion
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.LimpiarCampos();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarSucursales();
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
      this.oSucursalEsService.Update(
        this.nIdSucursalxES,
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
        this.sLatitud,
        this.sLongitud
      ).then((response: ResponseModel<any>) => {
        if (response.IsSuccess) {
          this.oBlockUI.stop();
          this.oMessageService.success(this.sTitlePage, response.Message);
          this.CargarSucursales();
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
  CargarEstacionServicio() {
    this.lstTipoVia = [];
    this.oComboService.GetEstacionServicio().then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.lstEstacionServicio = response.Data;
      }
    });
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
    this.sCodDepartamento = '00';
    this.oSunatService.ConsultaRuc(this.sRuc).then((response: ResponseModel<any>) => {
      if (response.IsSuccess) {
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
  ParseOptionToRuc() {
    const ruc = this.lstEstacionServicio.find(val => Number(val.nId) === Number(this.nIdEstServicio));
    this.sRuc = ruc.sDescription.split('-')[0];
  }
  ParseOptionsToDirection() {
    let direccion = '';
    if (Number(this.nTipoVia) !== 0) {
      const tipoVia: any = this.lstTipoVia.find(val => Number(val.nId) === Number(this.nTipoVia));
      direccion = `${direccion}${tipoVia.sDescription} ${this.sVia}`;
    }
    if (Number(this.nCentroPoblado) !== 0) {
      const centroPoblado: any = this.lstCentroPoblado.find(val => Number(val.nId) === Number(this.nCentroPoblado));
      direccion = `${direccion} ${centroPoblado.sDescription} ${this.sCentroPoblado}`;
    }
    if (Number(this.nIdNumeroManzana) !== 0) {
      const numeroManzana: any = this.lstNumeroManzana.find(val => Number(val.nId) === Number(this.nIdNumeroManzana));
      direccion = `${direccion} ${numeroManzana.sDescription} ${this.sNumeroManzana}`;
    }
    if (Number(this.nIdLoteInterior) !== 0) {
      const loteInterior: any = this.lstLoteInterior.find(val => Number(val.nId) === Number(this.nIdLoteInterior));
      direccion = `${direccion} ${loteInterior.sDescription} ${this.sLoteInterior}`;
    }
    const distrito: any = this.lstDistrito.find(val => val.sCodigo === this.sCodDistrito);
    direccion = `${direccion} (${distrito.sDescription})`;
    this.sDireccion = direccion.trimLeft();
  }
  LimpiarCampos() {
    this.nIdSucursalxES = 0;
    this.nIdEstServicio = -1;
    this.sRuc = '';
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
    this.sLatitud = '';
    this.sLongitud = '';
    this.sDireccion = '';
    this.lstProvincia = [];
    this.lstDistrito = [];
  }
  ValidarDatos(): any {
    if (
      Number(this.nIdEstServicio) === -1 ||
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
        (this.sVia.length === 0 && Number(this.nTipoVia) !== 0) ||
        (this.sCentroPoblado.length === 0 && Number(this.nCentroPoblado) !== 0) ||
        (this.sNumeroManzana.length === 0 && Number(this.nIdNumeroManzana) !== 0) ||
        (this.sLoteInterior.length === 0 && Number(this.nIdLoteInterior) !== 0) ||
        this.sReferencia.length === 0 ||
        this.sLatitud.length === 0 ||
        this.sLongitud.length === 0
      ) {
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }
  KeyUpNumber(event: any) {
    console.log(event);
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
