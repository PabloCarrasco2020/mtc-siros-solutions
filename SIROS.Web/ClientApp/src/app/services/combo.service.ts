import { Injectable } from '@angular/core';
import { BaseService } from './services.index';

@Injectable({
  providedIn: 'root'
})
export class ComboService {

  constructor(private oBaseService: BaseService) { }
  GetDepartamento() {
    return this.oBaseService.CallGet(`api/Combo/Get`);
  }
  GetProvincia(nValue: number) {
    return this.oBaseService.CallGet(`api/Combo/Get`);
  }
  GetDistrito(nValue: number) {
    return this.oBaseService.CallGet(`api/Combo/GetDistrito?sInput=`);
  }
}
