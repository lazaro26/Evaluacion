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
import { IAlumno} from 'src/app/models/ialumno';
import { SnackBarService} from 'src/app/services/snack.services';
import { TablaMetodosAlumno, TablaMetodosNotas} from 'src/app/models/modelos-types';
import { TablaMetodosCliclo, TablaMetodosCurso, TablaMetodosSemestre} from 'src/app/models/modelos-types';
import { ISemestre } from 'src/app/models/isemestre';
import { ICiclo } from 'src/app/models/iciclo';
import { ICurso } from 'src/app/models/icurso';
import { INota } from 'src/app/models/inota';
import { ErrorStateMatcher1 } from '../../error-state-matcher1';
import { DatosDialogo } from 'src/app/models/datos-dialogo';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-nota',
  templateUrl: './nota.component.html',
  styleUrls: []
})
export class NotaComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  
  
  cargando = false;
  matcher = new ErrorStateMatcher1();
  maxDate: Date;
  Semestres: ISemestre[];
  Ciclos: ICiclo[];
  Cursos: MatTableDataSource<ICurso>;
  subRef$: Subscription;
  formBuscar : FormGroup;
  displayedColumns: string[] = ['codigoCurso','ciclo','creditos','nombreCurso','notas'];


  idDirTmp = 0;
  idTelTmp = 0;
  alumno : any;

  constructor(
    public dialogRef: MatDialogRef<NotaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DatosDialogo,
    formBuilder: FormBuilder,
    private router: Router,
    public dialog: MatDialog,
    private dataService: DataService,
    public snack : SnackBarService,
  ) 
  
   {

    this.formBuscar = formBuilder.group({
      idSemestre: ['', Validators.required], 
      idCiclo : ['', Validators.required]
    });

    this.alumno = data.dato;
   }

  ngOnInit(): void {
    this.ListarSemestre();
    this.ListarCliclo();
    this.Calificar();
   
    setTimeout(() => {
      this.Calificar();
    }, 500);
  
  }


  ListarSemestre(){
    const met = this.snack.getMetodo(TablaMetodosSemestre.GET_CONSULTAR_LISTA);
    this.subRef$ = this.dataService.get<ISemestre[]>(met)
      .subscribe(res => {
        this.Semestres =  (res.body);
        this.formBuscar.patchValue({ idSemestre: this.Semestres[0].idSemestre });
      },
        err => {
          console.log('Error al recuperar las semestre', err);
        });
  }

  ListarCliclo(){
    const met = this.snack.getMetodo(TablaMetodosCliclo.GET_CONSULTAR_LISTA);
    this.subRef$ = this.dataService.get<ICiclo[]>(met)
      .subscribe(res => {
        this.Ciclos =  (res.body);
        this.formBuscar.patchValue({ idCiclo: this.Ciclos[0].idCiclo });

      },
        err => {
          console.log('Error al recuperar las ciclos', err);
        });
  }

  Calificar(){
    const datosCurso : any ={
      idEscuela :  this.alumno.idEscuela,
      idCliclo :  this.formBuscar.value.idCiclo,
      idAlumno : this.alumno.idAlumno,
      idSemestre : this.formBuscar.value.idSemestre,
    }


    const met = this.snack.getMetodo(TablaMetodosCurso.GET_CONSULTAR_GRID);
    this.subRef$ = this.dataService.post<ICurso[]>(met,datosCurso)
      .subscribe(res => {
        this.cargando = false;
        this.Cursos = new MatTableDataSource<ICurso>(res.body);
        this.Cursos.paginator = this.paginator;
        this.Cursos.sort = this.sort;
      },
        err => {
          console.log('Error al recuperar los clientes', err);
        });

  }



  RegistrarNota(){

   const registro = this.Cursos.data

   let detalle : any =[];
   
    for(let iten of registro){
      let obj : any={
        idCurso : iten.idCurso,
        calificacion :iten.nota
      }
      detalle.push(obj);
    }
    
    const datosNota: INota = {
      idNota : 0,
      idAlumno : this.alumno.idAlumno,
      idSemestre:this.formBuscar.value.idSemestre,
      notaDetalle : detalle
    };



    this.cargando = true;
    const met = this.snack.getMetodo(TablaMetodosNotas.GET_REGISTRAR_NOTA);
    this.subRef$ = this.dataService.post<IAlumno>(met, datosNota)
      .subscribe(res => {
        this.cargando = false;

      }, err => {
        this.cargando = false;
        console.log('Error al registrar nota', err);
      });



  }




  hasError(nombreControl: string, validacion: string) {
    const control = this.formBuscar.get(nombreControl);
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

    const registro = this.Cursos.data

     for(let iten of registro){
       if(iten.evaluado == 1){
        this.mensaje("El alumno ya tiene una evaluacion resgistrada en el cliclo " + iten.ciclo );
        return;
       }

       if(iten.nota == null){
         this.mensaje("Debe ingresar la nota del curso "+ iten.nombreCurso +" ." );
         return;
       }  
     }

    Swal.fire({
      title: 'confirmar',
      text: "Esta seguro que resgistrar la nota del alumno",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Aceptar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.Calificar();
      }
    })      
  }

}
