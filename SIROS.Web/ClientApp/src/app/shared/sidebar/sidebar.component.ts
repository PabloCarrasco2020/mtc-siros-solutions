import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/services/services.index';
import { LoginResponseModel } from '../../models/SSO.model';

const PROFILE_PROMOVILIDAD: string = 'Promovilidad';
const PROFILE_OGTU: string = 'OGTU';
const PROFILE_OES: string = 'OES';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public oCurrentUser: LoginResponseModel = new LoginResponseModel();

  constructor(private oSessionService: SessionService) {

  }

  ngOnInit() {
    this.oCurrentUser = this.oSessionService.GetCurrentUser();
  }

  HasProfilePromovilidad() {
    return this.oSessionService.HasSessionProfile(PROFILE_PROMOVILIDAD);
  }

  hasProfileOGTU() {
    return this.oSessionService.HasSessionProfile(PROFILE_OGTU);
  }

  hasProfileOES() {
    return this.oSessionService.HasSessionProfile(PROFILE_OES);
  }

  fnLogout() {
    this.oSessionService.EndSession();
  }
}
