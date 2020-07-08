import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/services/services.index';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  PROFILE_PROMOVILIDAD: string = 'Promovilidad';
  PROFILE_OGTU: string = 'OGTU';
  PROFILE_OES: string = 'OES';

  constructor(private oSessionService: SessionService) { }

  ngOnInit() {
  }

  HasProfilePromovilidad() {
    return this.oSessionService.HasSessionProfile(this.PROFILE_PROMOVILIDAD);
  }

  hasProfileOGTU() {
    return this.oSessionService.HasSessionProfile(this.PROFILE_OGTU);
  }

  hasProfileOES() {
    return this.oSessionService.HasSessionProfile(this.PROFILE_OES);
  }

  fnLogout() {
    this.oSessionService.EndSession();
  }
}
