import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class RutaService {

    constructor(private oBaseService: BaseService) { }

    Get(nIdRuta: number) {
      return this.oBaseService.CallGet(`api/Ruta/Get?sInput=${nIdRuta}`);
    }

    GetAllByFilter(nPagina: number, sFilter: string = '') {
      return this.oBaseService.CallGet(`api/Ruta/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
    }

    Insert(
      sNombreRuta: string,
      sItinerario: string,
      sKilometro: string,
      sEstado: string
    ) {
      const req = {
      sNombreRuta,
      sItinerario,
      sKilometro,
      sEstado
      };
      return this.oBaseService.CallPost(`api/Ruta/Insert`, req);
    }

    Update(
      nIdRuta: number,
      sNroRuta: string,
      sNombreRuta: string,
      sItinerario: string,
      sKilometro: string,
      sEstado: string
    ) {
      const req = {
        nIdRuta,
        sNroRuta,
        sNombreRuta,
        sItinerario,
        sKilometro,
        sEstado
      };
      return this.oBaseService.CallPost(`api/Ruta/Update`, req);
    }

    Delete(
      nIdRuta: number = 0
    ) {
      const req = {
        nIdRuta
      };
      return this.oBaseService.CallPost(`api/Ruta/Delete`, req);
    }

}