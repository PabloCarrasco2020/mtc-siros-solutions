import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivate, Router } from '@angular/router';
import { StorageService } from '../services/services.index';

@Injectable({
  providedIn: 'root'
})
export class OPGuard implements  CanActivate {
  constructor(private localstorage: StorageService, private router: Router) {
  }
  canActivate() {
    // VALIDAR SESION ACTIVA
    //this.router.navigate(['/login']);
    // VALIDAR PERFIL DE OPERADOR
    
    //this.router.navigate(['/pages/home'])

    return true;
  }
}
