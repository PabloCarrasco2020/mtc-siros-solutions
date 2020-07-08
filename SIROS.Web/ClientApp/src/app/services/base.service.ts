import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpHeaders, HttpClient } from '@angular/common/http';
import { ResponseModel } from '../models/ResponseModel';
import { SessionService } from './services.index';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  private URL = document.getElementsByTagName('base')[0].href;

  constructor(
    private clienteHttp: HttpClient,
    private oSessionService: SessionService) { }

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
  handleError(error: HttpErrorResponse): ResponseModel<any> {
    const responseError = new ResponseModel();
    responseError.IsSuccess = false;
    responseError.Message = error.message;
    return responseError;
  }

  GetHeaders(): HttpHeaders {
    const sToken = this.oSessionService.GetToken();
    if (sToken == null) {
      return new HttpHeaders({'Content-Type': 'application/json'});
    }

    // tslint:disable-next-line: object-literal-key-quotes
    return new HttpHeaders({ 'Authorization': `Bearer ${sToken}`, 'Content-Type': 'application/json'});
  }
}
