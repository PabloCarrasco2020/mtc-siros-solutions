import { Component, OnInit } from '@angular/core';
import { MunicipalidadService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  nPagina: number = 1;
  sFilter: string = 'test';

  constructor(private oMunicipalidadService: MunicipalidadService) { }

  ngOnInit() {
  }

  TestService() {
    this.oMunicipalidadService.GetAllByFilter(this.nPagina, this.sFilter)
    .then((response: ResponseModel) => {
      console.log('---GetAllByFilter');
      console.log(response);
    });
  }

}
