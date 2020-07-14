import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { CombustibleService, ComboService, MessageService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';
import { timeStamp } from 'console';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

declare var $: any;

@Component({
  selector: 'app-combustible',
  templateUrl: './combustible.component.html',
  styleUrls: ['./combustible.component.css']
})
export class CombustibleComponent implements OnInit {
  sTitlePage: string = 'Combustible';

  oIndexData: IndexModel = new IndexModel();
  nCurrentPage: number = 1;
  nCurrentOption: number = 0;
  nCurrentSectionModal: number = 1;

  oIndexDataRepresentanteLegal: IndexModel = new IndexModel();

  // Busqueda
  nTipoFiltro: number = 1;
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;
  constructor(
    private oCombustibleService: CombustibleService,
    private oMessageService: MessageService) {

    this.CargarCombustible();
  }

  ngOnInit() {
    //$(document).prop('title', 'SIROS - Combustible');
  }

  fnBefore(nPage: number) {
  }

  fnNew() {
  }

  fnEdit(nId: number) {
  }

  fnDelete(nId: number) {
  }

  fnNext(nPage: number) {
  }

  CargarCombustible() {
    this.oBlockUI.start('Cargando Municipalidades...');
    console.log(this.sFilter);
    this.oCombustibleService.GetAllByFilter(this.nCurrentPage, `${this.nTipoFiltro}@${this.sFilter}`)
      .then((response: ResponseModel<any>) => {

        if (response.IsSuccess) {
          this.oIndexData = response.Data;
        } else {
          this.oIndexData = new IndexModel();
        }
        this.oBlockUI.stop();
      });
  }

}
