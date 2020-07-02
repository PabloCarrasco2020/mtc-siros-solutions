import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }
  Set(name: string, value: any) {
    localStorage.setItem(name, value);
  }
  Get(name: string): any {
    return localStorage.getItem(name);
  }
  SetObj(name: string, value: any) {
    localStorage.setItem(name, JSON.stringify(value));
  }
  GetObj(name: string): any {
    return JSON.parse(localStorage.getItem(name));
  }
  Remove(name: string) {
    localStorage.removeItem(name);
  }
}
