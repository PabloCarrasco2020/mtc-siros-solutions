import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { ContratoEsModel } from '../models/contrato-es.model';

const CONTROLLER = 'ContratoEs';

@Injectable({providedIn: 'root'})
export class ContratoEsService {

    constructor(private oBaseService: BaseService) { }

    Get(nId: number) {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/Get?sInput=${nId}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: ContratoEsModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Insert`, oItem);
    }

    Update(oItem: ContratoEsModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Update`, oItem);
    }

    Delete(nIdEstServicioEnt: number) {
        const oRequest = { nIdEstServicioEnt };
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Delete`, oRequest);
    }
}
