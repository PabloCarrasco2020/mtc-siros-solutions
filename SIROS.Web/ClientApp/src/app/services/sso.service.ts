import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SSOService {

  constructor(private oBaseService: BaseService) { }

  Login(sUsername: string, sPassword: string) {
    const model = { sUsername, sPassword };
    return this.oBaseService.CallPost(`api/SSO/Login`, model);
  }

}
