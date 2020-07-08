import { Component, OnInit } from '@angular/core';
import { MunicipalidadService } from 'src/app/services/services.index';
import { ResponseModel } from 'src/app/models/ResponseModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private oMunicipalidadService: MunicipalidadService) { }

  ngOnInit() {
  }

}
