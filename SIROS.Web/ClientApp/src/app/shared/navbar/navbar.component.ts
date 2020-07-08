import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/services.index';
import { LoginResponseModel } from 'src/app/models/SSO.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public oCurrentUser: LoginResponseModel = new LoginResponseModel();

  constructor(private oSessionService: SessionService) {

  }

  ngOnInit() {
    this.oCurrentUser = this.oSessionService.GetCurrentUser();
  }

  fnLogout() {
    this.oSessionService.EndSession();
  }

}
