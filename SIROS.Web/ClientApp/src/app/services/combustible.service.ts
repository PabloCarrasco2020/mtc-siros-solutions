import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CombustibleService {

    constructor(private oBaseService: BaseService) { }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
      return this.oBaseService.CallGet(`api/Combustible/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }
}