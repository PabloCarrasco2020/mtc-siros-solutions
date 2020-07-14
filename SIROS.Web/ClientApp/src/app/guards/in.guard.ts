import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { SessionService } from '../services/services.index';

@Injectable({providedIn: 'root'})
export class InGuard implements CanActivate {

  constructor(
    private oSessionService: SessionService,
    private router: Router) { }

  canActivate() {
    if (!this.oSessionService.IsSessionActive()) {
      this.router.navigate(['/login']);
    }
    return true;
  }

}
