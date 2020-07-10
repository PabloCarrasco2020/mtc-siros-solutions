import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class EstacionServicioService {

  constructor(private oBaseService: BaseService) { }
  Get(nIdEntidad: number) {
    return this.oBaseService.CallGet(`api/EstacionServicio/Get?sInput=${nIdEntidad}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string = '') {
    return this.oBaseService.CallGet(`api/EstacionServicio/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
  }
  Insert(
    sRuc: string = '',
    sRazonSocial: string = '',
    nTipoVia: number = 0,
    sVia: string = '',
    nCentroPoblado: number = 0,
    sCentroPoblado: string = '',
    nIdNumeroManzana: number = 0,
    sNumeroManzana: string = '',
    nIdLoteInterior: number = 0,
    sLoteInterior: string = '',
    sReferencia: string = '',
    sCodDepartamento: string = '',
    sCodProvincia: string = '',
    sCodDistrito: string = '',
    sNroSucursales: string = '',
    sRepresentante: string = ''
  ) {
    const req = {
      sRuc,
      sRazonSocial,
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
      sNroSucursales,
      sRepresentante
    };
    return this.oBaseService.CallPost(`api/EstacionServicio/Insert`, req);
  }
  Update(
    nIdEstServicio: number = 0,
    sRuc: string = '',
    sRazonSocial: string = '',
    nTipoVia: number = 0,
    sVia: string = '',
    nCentroPoblado: number = 0,
    sCentroPoblado: string = '',
    nIdNumeroManzana: number = 0,
    sNumeroManzana: string = '',
    nIdLoteInterior: number = 0,
    sLoteInterior: string = '',
    sReferencia: string = '',
    sCodDepartamento: string = '',
    sCodProvincia: string = '',
    sCodDistrito: string = '',
    sNroSucursales: string = '',
    sRepresentante: string = ''
  ) {
    const req = {
      nIdEstServicio,
      sRuc,
      sRazonSocial,
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
      sNroSucursales,
      sRepresentante
    };
    return this.oBaseService.CallPost(`api/EstacionServicio/Update`, req);
  }
  Delete(
    nIdEstServicio: number = 0
  ) {
    const req = {
      nIdEstServicio
    };
    return this.oBaseService.CallPost(`api/EstacionServicio/Delete`, req);
  }
}

