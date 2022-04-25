import { Component, OnInit, OnDestroy, HostListener } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ILogin } from 'src/app/models/ilogin';
import { IResponse } from 'src/app/models/iresponse';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { SecurityService } from 'src/app/services/security.service';
import { ErrorStateMatcher1 } from '../error-state-matcher1';
import { environment } from 'src/environments/environment';
import { SnackBarService} from 'src/app/services/snack.services';
import { TablaMetodosLogin, TablaMetodosUsuario} from 'src/app/models/modelos-types';
import { IUsuarios } from 'src/app/models/iusuarios';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit, OnDestroy {
  formLogin: FormGroup;
  subRef$: Subscription;
  matcher = new ErrorStateMatcher1();
  scrHeight: any;
  scrWidth: any;

  // HostListener: https://angular.io/api/core/HostListener
  @HostListener('window:resize', ['$event'])
  getScreenSize(event?) {
    this.scrHeight = window.innerHeight;
    this.scrWidth = window.innerWidth;
    console.log(this.scrHeight, this.scrWidth);
  }
  
  constructor(
    formBuilder: FormBuilder,
    private router: Router,
    private dataService: DataService,
    private securityService: SecurityService,
    public snack : SnackBarService,
  ) {
    this.getScreenSize();
    this.securityService.LogOff();

    this.formLogin = formBuilder.group({
      usuario: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  Login() {
    const usuarioLogin: ILogin = {
      usuario: this.formLogin.value.usuario,
      password: this.formLogin.value.password,
    };


    const url = this.snack.getMetodo(TablaMetodosLogin.GET_AUTENTICACION);

    this.subRef$ = this.dataService.post<IResponse>(url,
      usuarioLogin)
      .subscribe(res => {
        const token = res.body.response;

        localStorage.setItem('currentUser', JSON.stringify(usuarioLogin));
        this.securityService.SetAuthData(token);
        this.router.navigate(['/home']);
      }, err => {
        console.log('Error en el login', err);
      });
  }

  


  hasError(nombreControl: string, validacion: string) {
    const control = this.formLogin.get(nombreControl);
    return control.hasError(validacion);
  }

  ngOnDestroy() {
    if (this.subRef$) {
      this.subRef$.unsubscribe();
    }
  }

}
