import { Injectable } from '@angular/core';
import { BaseService } from './services.index';

@Injectable({
  providedIn: 'root'
})
export class ReniecService {

  constructor(private oBaseService: BaseService) { }
  ConsultaNumDoc(sNumDoc: string) {
    return this.oBaseService.CallGet(`api/Reniec/ConsultaNumDoc?sNumDoc=${sNumDoc}`);
  }
}
