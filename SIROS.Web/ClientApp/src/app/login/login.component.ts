import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService, StorageService } from '../services/services.index';
import { ResponseModel } from '../models/ResponseModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  Usuario: string = '';
  Credencial: string = '';

  constructor(
    private router: Router,
    private oAuthService: AuthService,
    private oStorageService: StorageService
    ) { }

  ngOnInit() {
  }

  fnLogin() {
    // VALIDACION
    this.oAuthService.Login(
      this.Usuario,
      this.Credencial
    ).then((responseLogin: ResponseModel) => {
      if (!responseLogin.IsSuccess) {
        console.log(responseLogin.Message);
      } else {
        // Guardo el to//ken y usuario
        // Modelo del login . {Token:"jfhdsf48fhi8s3yrhsjfyd87",Perfil="OP",Administrado={ Nombre:"Pepito"}}
        const modelLogin = responseLogin.Data;
        this.oStorageService.Set('DB_TOKEN', modelLogin.Token);
        this.oStorageService.Set('DB_PERFIL', modelLogin.Perfil);
        this.oStorageService.SetObj('DB_ADMINISTRADO', modelLogin.Administrado);

        // Redirecciono
        this.router.navigate(['/pages/home']);
      }
    });
  }

}
