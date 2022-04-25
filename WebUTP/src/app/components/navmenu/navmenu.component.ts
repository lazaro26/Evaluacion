import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security.service';
import { Router } from '@angular/router';
import { AutenticarService } from 'src/app/services/autenticar.services';
import { TablaMetodosUsuario } from 'src/app/models/modelos-types';
import { IUsuarios } from 'src/app/models/iusuarios';
import { SnackBarService} from 'src/app/services/snack.services';
import { Subscription } from 'rxjs/internal/Subscription';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-navmenu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavmenuComponent implements OnInit {
  esAlumno : boolean =false;
  esAdminitrativo : boolean =false;
  subRef$: Subscription;
  constructor(
    private secutiryService: SecurityService,
    private router: Router,
    private autenticarService: AutenticarService,
    public snack : SnackBarService,
    private dataService: DataService,
  ) { }

  ngOnInit() {
    this.obtenerUsuario();
  }
  
  obtenerUsuario(){
    const datosUsuario = this.autenticarService.getIdentity();

    const met = this.snack.getMetodo(TablaMetodosUsuario.GET_USURIO);
    this.subRef$ = this.dataService.post<IUsuarios[]>(met,datosUsuario)
      .subscribe(res => {
         const respuesta : any = res.body[0];
         localStorage.setItem('conteUser', JSON.stringify(respuesta));
          switch(respuesta.idTipo){
            case 1 : this.esAdminitrativo = false;
                     this.esAlumno =true;
                     break; 

            case 2 : this.esAdminitrativo = true;
                     this.esAlumno =false;
                     break;             
          }
      },
        err => {
          console.log('Error al recuperar datos del usuario', err);
        });


  }


  LogOut() {
    this.secutiryService.LogOff();
    this.router.navigate(['/']);
  }

}
