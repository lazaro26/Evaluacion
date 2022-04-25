import { Injectable, OnDestroy } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class SnackBarService {

    getMetodo( metdo :  string){
        return  environment.urlAPI + metdo;
    }


}