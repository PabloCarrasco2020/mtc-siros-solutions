import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ComboService {

  constructor(private oBaseService: BaseService) { }
  GetDepartamento() {
    return this.oBaseService.CallGet(`api/Combo/GetDepartamento`);
  }
  GetProvincia(sCodDepartamento: string) {
    return this.oBaseService.CallGet(`api/Combo/GetProvincia?sCodDepartamento=${sCodDepartamento}`);
  }
  GetDistrito(sCodDepartamento: string, sCodProvincia: string) {
    return this.oBaseService.CallGet(`api/Combo/GetDistrito?sCodDepartamento=${sCodDepartamento}&sCodProvincia=${sCodProvincia}`);
  }
  GetTipoVia() {
    return this.oBaseService.CallGet(`api/Combo/GetTipoVia`);
  }
  GetCentroPoblado() {
    return this.oBaseService.CallGet(`api/Combo/GetCentroPoblado`);
  }
  GetNumeroManzana() {
    return this.oBaseService.CallGet(`api/Combo/GetNumeroManzana`);
  }
  GetLoteInterior() {
    return this.oBaseService.CallGet(`api/Combo/GetLoteInterior`);
  }
  GetTipoDoc(sTipoConsulta: string) {
    return this.oBaseService.CallGet(`api/Combo/GetTipoDoc?sTipoConsulta=${sTipoConsulta}`);
  }
  GetTipoOperador(sTipoConsulta: string) {
    return this.oBaseService.CallGet(`api/Combo/GetTipoOperador?sTipoConsulta=${sTipoConsulta}`);
  }
  GetCargoRepresentanteLegal() {
    return this.oBaseService.CallGet(`api/Combo/GetCargoRepresentanteLegal`);
  }
  GetEstacionServicio() {
    return this.oBaseService.CallGet(`api/Combo/GetEstacionServicio`);
  }
  GetRutas() {
    return this.oBaseService.CallGet(`api/Combo/GetRutas`);
  }
}
