import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { RutaService, ComboService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { timeStamp } from 'console';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

declare var $: any;
@Component({
  selector: 'app-rutas',
  templateUrl: './rutas.component.html',
  styleUrls: ['./rutas.component.css']
})
export class RutasComponent implements OnInit {
  sTitlePage: string = 'Ruta';

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;

  oIndexDataRepresentanteLegal: IndexModel = new IndexModel();

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';

  // FORMULARIO
  nIdRuta: string = '0';
  sNombreRuta: string = '';
  sItinerario: string = '';
  sKilometro: string = '';

  @BlockUI() oBlockUI: NgBlockUI;
  constructor(
    private oRutaService: RutaService,
    private oMessageService: MessageService) {

    this.CargarRuta();
  }

  ngOnInit() {
    $(document).prop('title', 'SIROS - Ruta');
  }

  fnBuscar() {
    this.nCurrentPage = 1;
    this.CargarRuta();
  }

  fnBefore(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRuta();
  }

  fnNew() {
    this.nCurrentOption = 1;
    this.LimpiarCampos();
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
  }

  fnEdit(nId: string) {
    this.nCurrentOption = 2;
    this.LimpiarCampos();
    this.nIdRuta = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    this.CargarRutaXId();
  }

  fnDelete(nId: number) {
    this.oMessageService.confirm(this.sTitlePage, '¿Está seguro de eliminar la sucursal de estación de servicio?')
    .then((result) => {
      if (result.value) {
        this.oBlockUI.start('Eliminando Ruta.');
        /*
       
        */
      }
    });
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRuta();
  }

  CargarRuta() {
    this.oBlockUI.start('Cargando Rutas...');
    console.log(this.sFilter);
    this.oRutaService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
      .then((response: ResponseModel<any>) => {

        if (response.IsSuccess) {
          this.oIndexData = response.Data;
        } else {
          this.oIndexData = new IndexModel();
        }
        this.oBlockUI.stop();
      });
  }

  CargarRutaXId() {
    this.oBlockUI.start('Cargando Ruta...');
    console.log(this.nIdRuta);
    this.oRutaService.Get(this.nIdRuta).then((response: ResponseModel<any>) => {
      if ( response.IsSuccess) {
        this.nIdRuta = response.Data.nIdRuta;
        this.sNombreRuta = response.Data.sNombreRuta;
        this.sItinerario = response.Data.sItinerario === null ? '' : response.Data.sItinerario;
        this.sKilometro = response.Data.sKilometro === null ? '' : response.Data.sKilometro;
      } else {

      }
      this.oBlockUI.stop();
    });
    
  }

  LimpiarCampos() {
    this.nIdRuta = '0';
    this.sNombreRuta = '';
    this.sItinerario = '';
    this.sKilometro = '';
  }

  fnGuardar() {
    const warningDatos = this.ValidarDatos();
    if (warningDatos !== null) {
      this.oMessageService.warning(this.sTitlePage, warningDatos);
      return;
    }
    this.Guardar();
  }
  Guardar() {
    this.oBlockUI.start('Guardando Ruta..');
    console.log('demo');
    if (this.nCurrentOption === 1) {

    } else if (this.nCurrentOption === 2) {

    }
    this.oBlockUI.stop();
  }
  ValidarDatos(): any {

    if (
        (this.sNombreRuta.length === 0 ) ||
        (this.sItinerario.length === 0) ||
        (this.sKilometro.length === 0) 
      ){
      return  ' Completar los campos con (*),  son obligatorios';
    }
    return null;
  }

}
