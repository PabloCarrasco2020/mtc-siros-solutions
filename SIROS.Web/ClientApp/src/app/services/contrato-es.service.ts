import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { ContratoEsRequestModel } from '../models/contrato-es.model';

@Injectable({providedIn: 'root'})
export class ContratoEsService {

    constructor(private oBaseService: BaseService) { }

    Get(nIdEntidad: number) {
        return this.oBaseService.CallGet(`api/ContratoEs/Get?sInput=${nIdEntidad}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/ContratoEs/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: ContratoEsRequestModel) {
        return this.oBaseService.CallPost(`api/ContratoEs/Insert`, oItem);
    }

    Update(oItem: ContratoEsRequestModel) {
        return this.oBaseService.CallPost(`api/ContratoEs/Update`, oItem);
    }

    Delete(nIdEstServicioEnt: number) {
        const oRequest = { nIdEstServicioEnt };
        return this.oBaseService.CallPost(`api/ContratoEs/Delete`, oRequest);
    }
}
