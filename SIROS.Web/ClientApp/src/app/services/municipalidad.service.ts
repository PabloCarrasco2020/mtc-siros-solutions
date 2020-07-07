import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class MunicipalidadService {

  constructor(private oBaseService: BaseService) { }

  Get(sInput: string) {
    return this.oBaseService.CallGet(`api/Municipalidad/Get?input=${sInput}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string) {
    return this.oBaseService.CallGet(`api/Municipalidad/GetAllByFilter?pagina=${nPagina}&filter=${sFilter}`);
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
    console.log('test:', nCentroPoblado);
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
    console.log(req);
    return this.oBaseService.CallPost(`api/Municipalidad/Insert`, req);
  }

}
