import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginatorIntl, MatPaginator } from '@angular/material/paginator';
import { MatPaginatorIntlCro } from 'src/app/models/mat-paginator-intl-cro';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { FormGroup, FormBuilder ,Validators} from '@angular/forms';
import { IAlumno} from 'src/app/models/ialumno';
import { SnackBarService} from 'src/app/services/snack.services';
import { TablaMetodosAlumno} from 'src/app/models/modelos-types';
import { RegistroComponent} from '../alumno/registro/registro.component';
import { UsuarioComponent} from '../alumno/usuario/usuario.component';
import { NotaComponent} from '../alumno/nota/nota.component';
import { ErrorStateMatcher1 } from '../error-state-matcher1';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-alumno',
  templateUrl: './alumno.component.html',
  styles: [],
  providers: [{ provide: MatPaginatorIntl, useClass: MatPaginatorIntlCro }],
})
export class AlumnoComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  Alumnos: MatTableDataSource<IAlumno>;
  subRef$: Subscription;
  formBuscar : FormGroup;
  displayedColumns: string[] = ['codigo','numeroDocumento','apellidoPaterno','apellidoMaterno','nombres','nombreEscuela','acciones'];
  cargando = true;
  matcher = new ErrorStateMatcher1();

  constructor(
    private dataService: DataService,
    private router: Router,
    public dialog: MatDialog,
    public snack : SnackBarService,
    formBuilder: FormBuilder,
  ) { 

    this.formBuscar = formBuilder.group({
      nombres: ['', Validators.required], 
    });

  }

  ngOnInit() {
    this.ListarAlumnos();
  }


  ListarAlumnos(){
    const DatoBusqueda : any ={
      nombre : this.formBuscar.value.nombres,
     }

    const met = this.snack.getMetodo(TablaMetodosAlumno.GET_CONSULTAR_GRID);
    this.subRef$ = this.dataService.get<IAlumno[]>(met,DatoBusqueda)
      .subscribe(res => {
        this.cargando = false;
        this.Alumnos = new MatTableDataSource<IAlumno>(res.body);
        this.Alumnos.paginator = this.paginator;
        this.Alumnos.sort = this.sort;
      },
        err => {
          console.log('Error al recuperar los clientes', err);
        });

  }

  ngOnDestroy() {
    if (this.subRef$) {
      this.subRef$.unsubscribe();
    }
  }

  Buscar(){
     this.ListarAlumnos();
  }

  AgregarAlumno(){
    const dialogRef = this.dialog.open(RegistroComponent, {
      width: '800px',
      data: { titulo: 'Agregar Alumno', dato: '' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.ListarAlumnos();
        Swal.fire('Registro exito', 'Se registro el alumno.', 'success');
      }
    });
  }

  AgregarUsuario(alu : any ){
    const dialogRef = this.dialog.open(UsuarioComponent, {
      width: '400px',
      data: { titulo: 'Agregar Usuario', dato: alu }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        
        Swal.fire('Registro exito', 'Se registro el Usuario.', 'success');
      }
    });
  }


  AgregaNotas(alu : any ){
    const dialogRef = this.dialog.open(NotaComponent, {
      width: '800px',
      data: { titulo: 'Agregar Notas', dato: alu }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
       
        Swal.fire('Registro exito', 'Se registro la  nota del alumno.', 'success');
      }
    });
  }


  hasError(nombreControl: string, validacion: string) {
    const control = this.formBuscar.get(nombreControl);
    return control.hasError(validacion);
  }


}
