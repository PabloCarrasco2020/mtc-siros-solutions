import { Injectable } from '@angular/core';

const GET_FORMAT = 'yyyy-MM-dd';

@Injectable({providedIn: 'root'})
export class DateService {

    constructor() { }

    stringToDate(sDate: string) {
        return new Date(sDate);
    }
}
