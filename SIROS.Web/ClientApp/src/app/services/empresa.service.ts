import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { EmpresaModel } from '../models/empresa.model';

const CONTROLLER = 'Empresa';

@Injectable({providedIn: 'root'})
export class EmpresaService {

    constructor(private oBaseService: BaseService) { }

    Get(nId: number) {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/Get?sInput=${nId}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: EmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Insert`, oItem);
    }

    Update(oItem: EmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Update`, oItem);
    }

    Delete(nIdEmpresa: number) {
        const oRequest = { nIdEmpresa };
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Delete`, oRequest);
    }

}
