import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SucursalEsService {

  constructor(private oBaseService: BaseService) { }
  Get(nIdEntidad: number) {
    return this.oBaseService.CallGet(`api/SucursalES/Get?sInput=${nIdEntidad}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string = '') {
    return this.oBaseService.CallGet(`api/SucursalES/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
  }
  Insert(
    nIdEstServicio: number,
    nTipoVia: number,
    sVia: string,
    nCentroPoblado: number,
    sCentroPoblado: string,
    nIdNumeroManzana: number,
    sNumeroManzana: string,
    nIdLoteInterior: number,
    sLoteInterior: string,
    sReferencia: string,
    sCodDepartamento: string,
    sCodProvincia: string,
    sCodDistrito: string,
    sLatitud: string,
    sLongitud: string,
    sRucEstacionServicio: string,
    sDireccionSucursal: string
  ) {
    const req = {
    nIdEstServicio,
    nTipoVia,
    sVia,
    nCentroPoblado,
    sCentroPoblado,
    nIdNumeroManzana,
    sNumeroManzana,
    nIdLoteInterior,
    sLoteInterior,
    sReferencia,
    sCodDepartamento,
    sCodProvincia,
    sCodDistrito,
    sLatitud,
    sLongitud,
    sRucEstacionServicio,
    sDireccionSucursal
    };
    return this.oBaseService.CallPost(`api/SucursalES/Insert`, req);
  }
  Update(
    nIdSucursalxES: number,
    nTipoVia: number,
    sVia: string,
    nCentroPoblado: number,
    sCentroPoblado: string,
    nIdNumeroManzana: number,
    sNumeroManzana: string,
    nIdLoteInterior: number,
    sLoteInterior: string,
    sReferencia: string,
    sCodDepartamento: string,
    sCodProvincia: string,
    sCodDistrito: string,
    sLatitud: string,
    sLongitud: string
  ) {
    const req = {
      nIdSucursalxES,
      nTipoVia,
      sVia,
      nCentroPoblado,
      sCentroPoblado,
      nIdNumeroManzana,
      sNumeroManzana,
      nIdLoteInterior,
      sLoteInterior,
      sReferencia,
      sCodDepartamento,
      sCodProvincia,
      sCodDistrito,
      sLatitud,
      sLongitud
    };
    return this.oBaseService.CallPost(`api/SucursalES/Update`, req);
  }
  Delete(
    nIdSucursalxES: number = 0
  ) {
    const req = {
      nIdSucursalxES
    };
    return this.oBaseService.CallPost(`api/SucursalES/Delete`, req);
  }
}

