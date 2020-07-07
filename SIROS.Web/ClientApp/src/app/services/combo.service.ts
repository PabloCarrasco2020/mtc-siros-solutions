import { Injectable } from '@angular/core';
import { BaseService } from './services.index';

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
  GetTipoDocRepresentanteLegal() {
    return this.oBaseService.CallGet(`api/Combo/GetTipoDocRepresentanteLegal`);
  }
  GetCargoRepresentanteLegal() {
    return this.oBaseService.CallGet(`api/Combo/GetCargoRepresentanteLegal`);
  }
}
