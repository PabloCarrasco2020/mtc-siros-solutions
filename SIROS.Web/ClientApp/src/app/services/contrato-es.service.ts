import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { ContratoEsModel } from '../models/contrato-es.model';

@Injectable({providedIn: 'root'})
export class ContratoEsService {

    constructor(private oBaseService: BaseService) { }

    Get(nIdEntidad: number) {
        return this.oBaseService.CallGet(`api/ContratoEs/Get?sInput=${nIdEntidad}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/ContratoEs/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: ContratoEsModel) {
        return this.oBaseService.CallPost(`api/ContratoEs/Insert`, oItem);
    }

    Update(oItem: ContratoEsModel) {
        return this.oBaseService.CallPost(`api/ContratoEs/Update`, oItem);
    }

    Delete(nIdEstServicioEnt: number) {
        const oRequest = { nIdEstServicioEnt };
        return this.oBaseService.CallPost(`api/ContratoEs/Delete`, oRequest);
    }
}
