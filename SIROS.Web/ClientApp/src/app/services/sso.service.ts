import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SSOService {

  private URL = document.getElementsByTagName('base')[0].href;

  constructor(private oBaseService: BaseService) { }

  Login(sUsername: string, sPassword: string, sCode: string) {
    const model = { sUsername, sPassword, sCode };
    return this.oBaseService.CallPost(`api/SSO/Login`, model);
  }

  GetCaptchaUrl() {
    return `${this.URL}api/SSO/GetCaptcha?${Date.now()}`;
  }
}
