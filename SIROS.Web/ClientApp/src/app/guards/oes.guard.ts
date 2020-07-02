import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { StorageService } from '../services/services.index';

@Injectable({
  providedIn: 'root'
})
export class OESGuard implements CanActivate {
  constructor(private localstorage: StorageService, private router: Router) {
  }
  canActivate() {
    // VALIDAR SESION ACTIVA

    // VALIDAR PERFIL DE OPERADOR
    return true;
  }
}
