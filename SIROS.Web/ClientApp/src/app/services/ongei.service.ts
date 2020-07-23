import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({providedIn: 'root'})
export class ONGEIService {

    constructor(private oBaseService: BaseService) { }

    ConsultaCarnetExt(sNumDoc: string) {
        return this.oBaseService.CallGet(`api/Ongei/ConsultaCarnetExt?sNumDoc=${sNumDoc}`);
    }

}
