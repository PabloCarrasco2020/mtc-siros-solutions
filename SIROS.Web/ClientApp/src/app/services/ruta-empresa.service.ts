import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { RutaEmpresaModel } from '../models/ruta-empresa.model';

const CONTROLLER = 'RutaEmpresa';

@Injectable({providedIn: 'root'})
export class RutaEmpresaService {

    constructor(private oBaseService: BaseService) { }

    Get(nId: number) {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/Get?sInput=${nId}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: RutaEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Insert`, oItem);
    }

    Update(oItem: RutaEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Update`, oItem);
    }

    Delete(nIdRutaXEmp: number) {
        const oRequest = { nIdRutaXEmp };
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Delete`, oRequest);
    }

}
