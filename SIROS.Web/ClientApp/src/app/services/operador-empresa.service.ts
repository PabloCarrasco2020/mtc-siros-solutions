import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { OperadorEmpresaModel } from '../models/operador-empresa.model';

const CONTROLLER = 'OperadorEmpresa';

@Injectable({providedIn: 'root'})
export class OperadorEmpresaService {

    constructor(private oBaseService: BaseService) { }

    Get(nId: number) {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/Get?sInput=${nId}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: OperadorEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Insert`, oItem);
    }

    Update(oItem: OperadorEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Update`, oItem);
    }

    Delete(nIdNominaXEmpresa: number) {
        const oRequest = { nIdNominaXEmpresa };
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Delete`, oRequest);
    }

}
