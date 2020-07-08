import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SunatService {

  constructor(private oBaseService: BaseService) { }
  ConsultaRuc(sRuc: string) {
    return this.oBaseService.CallGet(`api/Sunat/ConsultaRuc?sRuc=${sRuc}`);
  }
}
