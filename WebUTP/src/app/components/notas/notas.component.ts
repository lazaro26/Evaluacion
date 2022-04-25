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
import { ErrorStateMatcher1 } from '../error-state-matcher1';
import { DatosDialogo } from 'src/app/models/datos-dialogo';
import { AutenticarService } from 'src/app/services/autenticar.services';

@Component({
  selector: 'app-notas',
  templateUrl: './notas.component.html',
  styleUrls: ['./notas.component.css']
})
export class NotasComponent implements OnInit {

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
    formBuilder: FormBuilder,
    private router: Router,
    public dialog: MatDialog,
    private dataService: DataService,
    public snack : SnackBarService,
    private autenticarService: AutenticarService,
  ) { 

    this.formBuscar = formBuilder.group({
      idSemestre: ['', Validators.required], 
    });


  }

  ngOnInit(): void {
    this.ObtenerDatos();
    setTimeout(() => {
      this.Calificaciones();
    }, 800);
  }

   ObtenerDatos(){
    const datosUsuario : any = this.autenticarService.getIdentityConte();

    const datos :any ={
      idUsuario : datosUsuario.idUsuario,
      idTipo : datosUsuario.idTipo
    }
  
    const met = this.snack.getMetodo(TablaMetodosAlumno.GET_ALUMNO);
    this.subRef$ = this.dataService.post<IAlumno[]>(met,datos)
      .subscribe(res => {
        const respuesta : any = res.body[0];
        this.alumno = respuesta;
        this.ListarSemestre(respuesta.idAlumno);
    

      },
        err => {
          console.log('Error al recuperar los clientes', err);
        });

   }


  ListarSemestre(idAlumnos : number){
    const datosAlumno: any = {
      idAlumno : idAlumnos
    };

    const met = this.snack.getMetodo(TablaMetodosSemestre.GET_CONSULTAR_LISTA_ALUMNO);
    this.subRef$ = this.dataService.get<ISemestre[]>(met,datosAlumno)
      .subscribe(res => {
        this.Semestres =  (res.body);
        this.formBuscar.patchValue({ idSemestre: this.Semestres[0].idSemestre });
      },
        err => {
          console.log('Error al recuperar las semestre', err);
        });
  }


  Calificaciones(){
    const datosCurso : any ={
      idEscuela :  this.alumno.idEscuela,
      idAlumno : this.alumno.idAlumno,
      idSemestre : this.formBuscar.value.idSemestre,
    }
    console.log(datosCurso);


    const met = this.snack.getMetodo(TablaMetodosCurso.GET_CONSULTAR_ALUMNO_GRID);
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


}
