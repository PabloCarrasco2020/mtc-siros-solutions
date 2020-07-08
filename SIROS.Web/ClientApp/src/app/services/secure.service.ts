import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';

const SECRET_KEY: string = 'MTC@SIROS@PROJECT@2020';

@Injectable({
  providedIn: 'root'
})
export class SecureService {

  constructor() { }

  encrypt(sValue: string): string {
    if (!sValue) {
      return null;
    }
    return CryptoJS.AES.encrypt(sValue, SECRET_KEY).toString();
  }

  decrypt(sValue: string): string {
    if (!sValue) {
      return null;
    }
    return CryptoJS.AES.decrypt(sValue, SECRET_KEY).toString(CryptoJS.enc.Utf8);
  }

}
