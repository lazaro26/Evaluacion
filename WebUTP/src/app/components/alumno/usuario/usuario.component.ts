import { Component, OnInit, OnDestroy, ViewChild, Inject } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginatorIntl, MatPaginator } from '@angular/material/paginator';
import { MatPaginatorIntlCro } from 'src/app/models/mat-paginator-intl-cro';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder ,Validators} from '@angular/forms';
import { IUsuario} from 'src/app/models/iusuario';
import { SnackBarService} from 'src/app/services/snack.services';
import { TablaMetodosAlumno} from 'src/app/models/modelos-types';
import { ErrorStateMatcher1 } from '../../error-state-matcher1';
import { DatosDialogo } from 'src/app/models/datos-dialogo';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styles: []
})
export class UsuarioComponent implements OnInit {
  cargando = false;
  matcher = new ErrorStateMatcher1();
  formAgregarUsuario: FormGroup;
  maxDate: Date;
  alumno : any;

  idDirTmp = 0;
  idTelTmp = 0;
  subRef$: Subscription;
  
  constructor(
    public dialogRef: MatDialogRef<UsuarioComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DatosDialogo,
    formBuilder: FormBuilder,
    private router: Router,
    public dialog: MatDialog,
    private dataService: DataService,
    public snack : SnackBarService,)
     {
      this.formAgregarUsuario = formBuilder.group({
        Usuario: ['', Validators.required],
        Password: ['', Validators.required],
      });
        this.alumno = data.dato;

      }

  ngOnInit(): void {
  }

  AgregarUsuario() {
   
    const datosUsuario :IUsuario = {
      Usuario : this.formAgregarUsuario.value.Usuario,
      Password: this.formAgregarUsuario.value.Password,
      alumno : this.alumno
    };

    this.cargando = true;
    const met = this.snack.getMetodo(TablaMetodosAlumno.GET_REGISTRAR_USUARIO);
    this.subRef$ = this.dataService.post<IUsuario>(met, datosUsuario)
      .subscribe(res => {
        this.cargando = false;

      }, err => {
        this.cargando = false;
        console.log('Error al crear el cliente', err);
      });
  }


  hasError(nombreControl: string, validacion: string) {
    const control = this.formAgregarUsuario.get(nombreControl);
    return control.hasError(validacion);
  }

  cancelar(): void {
    this.data.id = 0;
    this.dialogRef.close();
  }


  mensaje(mensaje : string ){
    Swal.fire(
      'Advertencia',
       mensaje,
      'question'
    )
   }

  onGuardar(){

   let Usuario : string = this.formAgregarUsuario.value.Usuario;
   let Password: string =this.formAgregarUsuario.value.Password;

  if(Usuario =="") {this.mensaje("Debe ingresar usuario del almuno"); return;}
  if(Password ==""){this.mensaje("Debe ingresar Password del almuno"); return;}


    Swal.fire({
      title: 'confirmar',
      text: "Esta seguro que resgistrar el usuario del alumno",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.AgregarUsuario();
      }
    })      
  }
}
