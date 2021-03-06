import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MunicipalidadService {

  constructor(private oBaseService: BaseService) { }

  Get(nIdEntidad: number) {
    return this.oBaseService.CallGet(`api/Municipalidad/Get?sInput=${nIdEntidad}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string = '') {
    return this.oBaseService.CallGet(`api/Municipalidad/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
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
      sRepresentante
    };
    return this.oBaseService.CallPost(`api/Municipalidad/Insert`, req);
  }
  Update(
    nIdEntidad: number = 0,
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
    sRepresentante: string = ''
  ) {
    const req = {
      nIdEntidad,
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
      sRepresentante
    };
    return this.oBaseService.CallPost(`api/Municipalidad/Update`, req);
  }
  Delete(
    nIdEntidad: number = 0
  ) {
    const req = {
      nIdEntidad
    };
    return this.oBaseService.CallPost(`api/Municipalidad/Delete`, req);
  }
}
