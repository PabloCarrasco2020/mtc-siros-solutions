import { Component, OnInit } from '@angular/core';
import { IndexModel } from 'src/app/models/IndexModel';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { MunicipalidadService } from 'src/app/services/services.index';
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
  sFilter: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(private oMunicipalidadService: MunicipalidadService) {
    this.CargarMunicipalidades();
  }

  ngOnInit() {
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

  fnNext(nPage: number) {
    this.nCurrentPage = nPage;
    this.CargarMunicipalidades();
  }

  CargarMunicipalidades() {
    this.oBlockUI.start('Cargando Municipalidades...');
    this.oMunicipalidadService.GetAllByFilter(this.nCurrentPage, this.sFilter)
    .then((response: ResponseModel) => {
      console.log('---CargarMunicipalidades');
      console.log(response);

      if (response.IsSuccess) {
        this.oIndexData = response.Data;
      } else {
        this.oIndexData = new IndexModel();
        console.log('>>> Error en el servicio');
      }

      this.oBlockUI.stop();
    });
  }

}
