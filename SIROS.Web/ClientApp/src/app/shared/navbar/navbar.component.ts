import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/services/services.index';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(
    private oSessionService: SessionService
    ) { }

  ngOnInit() {
  }

  fnLogout() {
    this.oSessionService.EndSession();
  }

}
