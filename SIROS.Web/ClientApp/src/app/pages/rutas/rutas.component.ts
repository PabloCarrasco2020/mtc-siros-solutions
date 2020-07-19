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

  fnEdit(nId: number) {
    this.nCurrentOption = 2;
    this.LimpiarCampos();
    //this.nIdSucursalxES = nId;
    $('#myModalNew').modal({backdrop: 'static', keyboard: false});
    //this.CargarSucursalXId();
  }

  fnDelete(nId: number) {
  }

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarRuta();
  }

  CargarRuta() {
    this.oBlockUI.start('Cargando Municipalidades...');
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

  LimpiarCampos() {

  }

  fnGuardar() {
    
  }
}
