import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

const CONTROLLER = 'CoordenadaRuta';

@Injectable({providedIn: 'root'})
export class CoordenadaRutaService {

    constructor(private oBaseService: BaseService) { }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

}