import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class RutaService {

    constructor(private oBaseService: BaseService) { }
    Get(nIdRuta: string = '') {
      return this.oBaseService.CallGet(`api/Ruta/Get?sInput=${nIdRuta}`);
    }
    GetAllByFilter(nPagina: number, sFilter: string = '') {
      return this.oBaseService.CallGet(`api/Ruta/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }
}