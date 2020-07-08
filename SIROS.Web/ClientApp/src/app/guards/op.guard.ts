import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { SessionService } from '../services/services.index';

const PROFILE_NAME: string = 'Promovilidad';

@Injectable({
  providedIn: 'root'
})
export class OPGuard implements  CanActivate {

  constructor(
    private oSessionService: SessionService,
    private router: Router) {
  }

  canActivate() {
    if (!(this.oSessionService.IsSessionActive() && this.oSessionService.HasSessionProfile(PROFILE_NAME))) {
      this.router.navigate(['/login']);
    }
    return true;
  }

}
