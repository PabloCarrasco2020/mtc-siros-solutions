import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { LoginResponseModel } from '../models/SSO.model';

const SESSION_USER_TOKEN: string = '000001';
const SESSION_USER_PROFILE: string = '000002';
const SESSION_CURRENT_USER: string = '000003';

@Injectable({
    providedIn: 'root'
})
export class SessionService {

    constructor(private oStorageService: StorageService) { }

    SaveSession(oUser: LoginResponseModel) {
        this.oStorageService.Set(SESSION_USER_TOKEN, oUser.sToken);
        this.oStorageService.Set(SESSION_USER_PROFILE, oUser.sNombrePerfil);
        this.oStorageService.SetObj(SESSION_CURRENT_USER, oUser);
    }

    EndSession() {
        this.oStorageService.Remove(SESSION_USER_TOKEN);
        this.oStorageService.Remove(SESSION_USER_PROFILE);
        this.oStorageService.Remove(SESSION_CURRENT_USER);
        window.location.reload();
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
}