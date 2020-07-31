import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({providedIn: 'root'})
export class SunarpService {

    constructor(private oBaseService: BaseService) { }

    ConsultaPlaca(sPlaca: string) {
        return this.oBaseService.CallGet(`api/Sunarp/ConsultaPlaca?sPlaca=${sPlaca}`);
    }

}
