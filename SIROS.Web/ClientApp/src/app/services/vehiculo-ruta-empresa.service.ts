import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { VehiculoRutaEmpresaModel } from '../models/vehiculo-ruta-empresa.model';

const CONTROLLER = 'VehiculoRutaEmpresa';

@Injectable({providedIn: 'root'})
export class VehiculoRutaEmpresaService {

    constructor(private oBaseService: BaseService) { }

    Get(nId: number) {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/Get?sInput=${nId}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
        return this.oBaseService.CallGet(`api/${CONTROLLER}/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(oItem: VehiculoRutaEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Insert`, oItem);
    }

    Update(oItem: VehiculoRutaEmpresaModel) {
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Update`, oItem);
    }

    Delete(nIdVehXEmp: number) {
        const oRequest = { nIdVehXEmp };
        return this.oBaseService.CallPost(`api/${CONTROLLER}/Delete`, oRequest);
    }
}
