import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class FormularioOGTUService {

  constructor(private oBaseService: BaseService) { }

  Get(nIdEntidad: number) {
    return this.oBaseService.CallGet(`api/FormularioOGTU/Get?sInput=${nIdEntidad}`);
  }
  GetAllByFilter(nPagina: number, sFilter: string = '') {
    return this.oBaseService.CallGet(`api/FormularioOGTU/GetAllByFilter?nPagina=${nPagina}&sFilter=${sFilter}`);
  }
  Insert(
    sPlaca: string,
    nIdEmpresa: number,
    nIdSucursalXES: number,
    nIdVehXEmp: number,
    nMonto: number,
    sFecSum: string,
    sHoraSum: string,
    sMinutoSum: string,
    sNombreArchivo: string,
    nIdTpDocumentoOpeXEmp: number,
    sNumDocumentoOpeXEmp: string,
    nIdTpDocumentoOpEXEst: number,
    sNumDocumentoOpeXEst: string
  ) {
    const req = {
      sPlaca,
      nIdEmpresa,
      nIdSucursalXES,
      nIdVehXEmp,
      nMonto,
      sFecSum,
      sHoraSum,
      sMinutoSum,
      sNombreArchivo,
      nIdTpDocumentoOpeXEmp,
      sNumDocumentoOpeXEmp,
      nIdTpDocumentoOpEXEst,
      sNumDocumentoOpeXEst
    };
    return this.oBaseService.CallPost(`api/FormularioOGTU/Insert`, req);
  }
  Update(
    nIdFormularioTU: number,
    sPlaca: string,
    nIdEmpresa: number,
    nIdSucursalXES: number,
    nMonto: number,
    sFecSum: string,
    sHoraSum: string,
    sMinutoSum: string,
    sNombreArchivo: string,
    nIdTpDocumentoOpeXEmp: number,
    sNumDocumentoOpeXEmp: string,
    nIdTpDocumentoOpEXEst: number,
    sNumDocumentoOpeXEst: string
  ) {
    const req = {
      nIdFormularioTU,
      sPlaca,
      nIdEmpresa,
      nIdSucursalXES,
      nMonto,
      sFecSum,
      sHoraSum,
      sMinutoSum,
      sNombreArchivo,
      nIdTpDocumentoOpeXEmp,
      sNumDocumentoOpeXEmp,
      nIdTpDocumentoOpEXEst,
      sNumDocumentoOpeXEst
    };
    return this.oBaseService.CallPost(`api/FormularioOGTU/Update`, req);
  }
  Delete(
    nIdFormularioTU: number
  ) {
    const req = {
      nIdFormularioTU
    };
    return this.oBaseService.CallPost(`api/FormularioOGTU/Delete`, req);
  }
}
