import { Injectable } from '@angular/core';
import { SecureService } from './secure.service';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private oSecureService: SecureService) { }

  Set(name: string, value: any) {
    const sEncryptedValue = this.oSecureService.encrypt(value);
    localStorage.setItem(name, sEncryptedValue);
  }

  Get(name: string): any {
    const sValue = localStorage.getItem(name);
    if (sValue === null) {
      return null;
    }
    const sDecryptedValue = this.oSecureService.decrypt(sValue);
    return sDecryptedValue;
  }

  SetObj(name: string, value: any) {
    const sEncryptedValue = this.oSecureService.encrypt(JSON.stringify(value));
    localStorage.setItem(name, sEncryptedValue);
  }

  GetObj(name: string): any {
    const sValue = localStorage.getItem(name);
    if (sValue === null) {
      return null;
    }
    const sDecryptedValue = this.oSecureService.decrypt(sValue);
    return JSON.parse(sDecryptedValue);
  }

  Remove(name: string) {
    localStorage.removeItem(name);
  }
}
