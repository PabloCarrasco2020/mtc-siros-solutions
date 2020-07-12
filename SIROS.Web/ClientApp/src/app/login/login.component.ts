import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SSOService, SessionService } from '../services/services.index';
import { ResponseModel } from '../models/ResponseModel';
import { LoginResponseModel } from '../models/SSO.model';
import Swal from 'sweetalert2';
import { NgBlockUI, BlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  private api: string = "/api/SSO";
  private captchaUrl: string = `${this.api}/captcha`;

  sUsername: string = '';
  sPassword: string = '';
  sCaptcha: string = '';

  @BlockUI() oBlockUI: NgBlockUI;

  constructor(
    private router: Router,
    private oSSOService: SSOService,
    private oSessionService: SessionService
    ) { }

  ngOnInit() {
  }

  fnCaptchaReset() {
    this.sCaptcha = "";
    this.captchaUrl = `${this.api}/captcha?${Date.now()}`;
  }

  fnLogin() {
    if (!this.sUsername) {
      Swal.fire({
        icon: 'error',
        title: 'ERROR',
        text: 'Porfavor ingrese su Usuario.'
      });
      return;
    } else if (this.sUsername.length <= 3) {
      Swal.fire({
        icon: 'error',
        title: 'ERROR',
        text: 'El Usuario debe tener mas de 3 caracteres.'
      });
      return;
    }

    if (!this.sPassword) {
      Swal.fire({
        icon: 'error',
        title: 'ERROR',
        text: 'Porfavor ingrese su Contraseña.'
      });
      return;
    } else if (this.sPassword.length <= 3) {
      Swal.fire({
        icon: 'error',
        title: 'ERROR',
        text: 'La Contraseña debe tener mas de 3 caracteres.'
      });
      return;
    }

    this.oBlockUI.start('Iniciando Sesion...');
    this.oSSOService.Login(this.sUsername, this.sPassword)
      .then((oResponse: ResponseModel<LoginResponseModel>) => {

      if (!oResponse) {
        this.oBlockUI.stop();
        Swal.fire({
          icon: 'error',
          title: 'ERROR',
          text: 'No se pudo obtener respuesta del servidor.'
        });
        return;
      }

      if (!oResponse.IsSuccess) {
        this.oBlockUI.stop();
        Swal.fire({
          icon: 'error',
          title: 'ERROR',
          text: oResponse.Message
        });
        return;
      }

      if (!oResponse.Data) {
        this.oBlockUI.stop();
        Swal.fire({
          icon: 'error',
          title: 'ERROR',
          text: 'El servidor no respondio informacion del usuario.'
        });
        return;
      }

      const oUser = oResponse.Data;
      this.oSessionService.SaveSession(oUser);

      this.oBlockUI.stop();
      this.router.navigate(['/pages/home']);
    });
  }

}
