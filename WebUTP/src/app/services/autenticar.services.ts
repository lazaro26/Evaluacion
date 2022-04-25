import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
export class AutenticarService {
    public identity;

    constructor() {
        
    }

    getIdentity() {
        const identity = JSON.parse(localStorage.getItem('currentUser'));
        if (this.identity !== 'undefined') {
            this.identity = identity;
        } else {
            this.identity = null;
        }
        return this.identity;

    }

    getIdentityConte() {
        const identity = JSON.parse(localStorage.getItem('conteUser'));
        if (this.identity !== 'undefined') {
            this.identity = identity;
        } else {
            this.identity = null;
        }
        return this.identity;

    }

}