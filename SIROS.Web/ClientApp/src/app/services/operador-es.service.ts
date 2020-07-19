import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class OperadorEsService {

  constructor(private oBaseService: BaseService) { }
  Get(nIdEntidad: number) {
    return this.oBaseService.CallGet(`api/OperadorES/Get?sInput=${nIdEntidad}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string = '') {
    return this.oBaseService.CallGet(`api/OperadorES/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
  }
  Insert(
    nIdSucursalxES: number,
    nIdTpDocumento: number,
    sNroDocumento: string,
    sApePaterno: string,
    sApeMaterno: string,
    sNombre: string,
    nIdTipoOper: number,
    sFecNacimiento: string,
    sFoto: string
  ) {
    const req = {
      nIdSucursalxES,
      nIdTpDocumento,
      sNroDocumento,
      sApePaterno,
      sApeMaterno,
      sNombre,
      nIdTipoOper,
      sFecNacimiento,
      sFoto
    };
    return this.oBaseService.CallPost(`api/OperadorES/Insert`, req);
  }
  Update(
    nIdNominaXSucursal: number,
    nIdTipoOper: number,
    sFecNacimiento: string
  ) {
    const req = {
      nIdNominaXSucursal,
      nIdTipoOper,
      sFecNacimiento
    };
    return this.oBaseService.CallPost(`api/OperadorES/Update`, req);
  }
  Delete(
    nIdNominaXSucursal: number = 0
  ) {
    const req = {
      nIdNominaXSucursal
    };
    return this.oBaseService.CallPost(`api/OperadorES/Delete`, req);
  }
}
