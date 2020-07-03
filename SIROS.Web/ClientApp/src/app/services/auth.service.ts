import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private oBaseService: BaseService) { }
  Login(Usuario: string, Credencial: string) {
    const model = {Usuario, Credencial};
    return this.oBaseService.CallPost(`api/auth/login`, model);
  }
}
