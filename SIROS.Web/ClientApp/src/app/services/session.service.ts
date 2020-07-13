import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { LoginResponseModel } from '../models/SSO.model';
import { Router } from '@angular/router';

const SESSION_USER_TOKEN: string = '000001';
const SESSION_USER_PROFILE: string = '000002';
const SESSION_CURRENT_USER: string = '000003';

@Injectable({
    providedIn: 'root'
})
export class SessionService {

    constructor(
      private router: Router,
      private oStorageService: StorageService) { }

    SaveSession(oUser: LoginResponseModel) {
        this.oStorageService.Set(SESSION_USER_TOKEN, oUser.sToken);
        this.oStorageService.Set(SESSION_USER_PROFILE, oUser.sNombrePerfil);
        this.oStorageService.SetObj(SESSION_CURRENT_USER, oUser);
    }

    EndSession() {
        this.oStorageService.Remove(SESSION_USER_TOKEN);
        this.oStorageService.Remove(SESSION_USER_PROFILE);
        this.oStorageService.Remove(SESSION_CURRENT_USER);
        this.router.navigate(['/login']);
    }

    IsSessionActive(): boolean {
        const sToken: string = this.oStorageService.Get(SESSION_USER_TOKEN);
        if (sToken === null) {
          return false;
        }
        // verificar fecha de expiracion del token
        return true;
    }

    HasSessionProfile(sProfile: string): boolean {
        const sProfileName: string = this.oStorageService.Get(SESSION_USER_PROFILE);
        if (sProfileName === null) {
          return false;
        }
        return (sProfile.toUpperCase() === sProfileName.toUpperCase());
    }

    GetToken(): string {
        const sToken: string = this.oStorageService.Get(SESSION_USER_TOKEN);
        if (sToken === null) {
          return null;
        }
        return sToken;
    }

    GetCurrentUser(): LoginResponseModel {
        const oCurrentUser: LoginResponseModel = this.oStorageService.GetObj(SESSION_CURRENT_USER);
        if (oCurrentUser === null) {
          return null;
        }
        return oCurrentUser;
    }
}
