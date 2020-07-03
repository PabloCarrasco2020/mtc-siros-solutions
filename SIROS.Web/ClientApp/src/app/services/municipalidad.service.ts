import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MunicipalidadService {

  constructor(private oBaseService: BaseService) { }

  Get(sInput: string) {
    return this.oBaseService.CallGet(`api/Municipalidad/Get?input=${sInput}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string) {
    return this.oBaseService.CallGet(`api/Municipalidad/GetAllByFilter?pagina=${nPagina}&filter=${sFilter}`);
  }

}
