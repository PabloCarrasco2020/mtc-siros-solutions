import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpHeaders, HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';
import { ResponseModel } from '../models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private URL = document.getElementsByTagName('base')[0].href;

  constructor( private clienteHttp: HttpClient, private storageService: StorageService) { }
  CallGet(metodo: string): any {
    const header = this.GetHeaders();
    return new Promise<any> (resolve => {
      this.clienteHttp.get(`${this.URL}${metodo}`, {observe: 'response' as 'body', headers: header} )
          .subscribe((response: any) => {
            resolve(response.body);
      }, (err: HttpErrorResponse) => {
        resolve(this.handleError(err));
      });
  });
  }

  CallPost(metodo: string, request: any): any {
    const header = this.GetHeaders();
    console.log(request);
    return new Promise<any> (resolve => {
      this.clienteHttp.post(`${this.URL}${metodo}`, request , {observe: 'response' as 'body', headers: header } )
          .subscribe((response: any) => {
            resolve(response.body);
      }, (err: HttpErrorResponse) => {
        resolve(this.handleError(err));
      });
  });
  }
  handleError(error: HttpErrorResponse): ResponseModel {
    const responseError = new ResponseModel();
    responseError.IsSuccess = false;
    responseError.Message = error.message;
    return responseError;
  }

  GetHeaders(): HttpHeaders {
  const token = this.storageService.Get('llave');
  // tslint:disable-next-line: object-literal-key-quotes
  return new HttpHeaders({ 'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json'});
  }
}
