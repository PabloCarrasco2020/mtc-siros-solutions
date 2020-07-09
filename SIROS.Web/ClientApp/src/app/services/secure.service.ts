import { Injectable } from '@angular/core';

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
    return sValue;
  }

  decrypt(sValue: string): string {
    if (!sValue) {
      return null;
    }
    return sValue;
  }

}
