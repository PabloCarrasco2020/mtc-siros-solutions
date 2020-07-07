import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
   constructor() {
   }
   success(Title: string, Message: string) {
    Swal.fire({
        customClass: {container: 'swal2-container'},
        icon: 'success',
        title: Title,
        text: Message
      });
   }
   error(Title: string, Message: string) {
    Swal.fire({
        customClass: {container: 'swal2-container'},
        icon: 'error',
        title: Title,
        text: Message
      });
   }
   warning(Title: string, Message: string) {
    Swal.fire({
        customClass: {container: 'swal2-container'},
        icon: 'warning',
        title: Title,
        text: Message
      });
   }
}
