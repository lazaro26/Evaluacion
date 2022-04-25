import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DatosDialogo } from 'src/app/models/datos-dialogo';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/models/icliente';
import { DataService } from 'src/app/services/data.service';
import { TablaMetodosAlumno, TablaMetodosEscuela} from 'src/app/models/modelos-types';
import { ErrorStateMatcher1 } from '../../error-state-matcher1';
import { IAlumno } from 'src/app/models/ialumno';
import { IEscuela } from 'src/app/models/iescuela';
import { SnackBarService} from 'src/app/services/snack.services';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styles: []
})
export class RegistroComponent implements OnInit {
  cargando = false;
  matcher = new ErrorStateMatcher1();
  formAgregarAlumno: FormGroup;
  maxDate: Date;
  Escuelas: IEscuela[];

  idDirTmp = 0;
  idTelTmp = 0;
  subRef$: Subscription;
  
  constructor(
    public dialogRef: MatDialogRef<RegistroComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DatosDialogo,
    formBuilder: FormBuilder,
    private router: Router,
    public dialog: MatDialog,
    private dataService: DataService,
    public snack : SnackBarService,

    ) {


      this.formAgregarAlumno = formBuilder.group({
        numeroDocumento: ['', Validators.required],
        apellidoPaterno: ['', Validators.required],
        apellidoMaterno: ['', Validators.required],
        nombres: ['', Validators.required],
        idEscuela : ['-1', Validators.required],
      });

     }

  ngOnInit() {
    this.ListarEspecialidad();
  }


  ListarEspecialidad(){
    const met = this.snack.getMetodo(TablaMetodosEscuela.GET_CONSULTAR_LISTA);
    this.subRef$ = this.dataService.get<IEscuela[]>(met)
      .subscribe(res => {
        this.Escuelas =  (res.body);
      },
        err => {
          console.log('Error al recuperar las escuelas', err);
        });
  }


  AgregarAlumno() {
    const datosAlumno: IAlumno = {
      idAlumno : 0,
      codigo :"",
      numeroDocumento : this.formAgregarAlumno.value.numeroDocumento,
      apellidoPaterno: this.formAgregarAlumno.value.apellidoPaterno,
      apellidoMaterno: this.formAgregarAlumno.value.apellidoMaterno,
      nombres: this.formAgregarAlumno.value.nombres,
      idEscuela :  this.formAgregarAlumno.value.idEscuela,
      nombreEscuela : "",
    };

    this.cargando = true;
    const met = this.snack.getMetodo(TablaMetodosAlumno.GET_REGISTRAR_ALUMNO);
    this.subRef$ = this.dataService.post<IAlumno>(met, datosAlumno)
      .subscribe(res => {
        this.cargando = false;
        this.dialogRef.close(datosAlumno);
      }, err => {
        this.cargando = false;
        console.log('Error al crear el cliente', err);
      });
  }


  hasError(nombreControl: string, validacion: string) {
    const control = this.formAgregarAlumno.get(nombreControl);
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

    let numeroDocumento : string = this.formAgregarAlumno.value.numeroDocumento;
    let apellidoPaterno: string =this.formAgregarAlumno.value.apellidoPaterno;
    let apellidoMaterno: string =this.formAgregarAlumno.value.apellidoMaterno;
    let nombres: string =this.formAgregarAlumno.value.nombres;
    let idEscuela: string =this.formAgregarAlumno.value.idEscuela;

   if(numeroDocumento =="") {this.mensaje("Debe ingresar numero de documento"); return;}
   if(apellidoPaterno =="") {this.mensaje("Debe ingresar apellido paterno"); return; }
   if(apellidoMaterno =="") {this.mensaje("Debe ingresar apellido materno");return; }
   if(nombres =="") {this.mensaje("Debe ingresar nombres");return; }
   if(idEscuela =="-1") {this.mensaje("Debe seleccionar la escuela");return; }


    Swal.fire({
      title: 'confirmar',
      text: "Esta seguro que resgistrar alumno",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.AgregarAlumno();
      }
    })      
  }

}
