import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClientXsrfModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './modules/material.module';
import { JwtInterceptor } from './services/auth/jwt-interceptor';
import { AlumnoComponent } from './components/alumno/alumno.component';
import { RegistroComponent } from './components/alumno/registro/registro.component';
import { UsuarioComponent } from './components/alumno/usuario/usuario.component';
import { NotaComponent } from './components/alumno/nota/nota.component';
import { NotasComponent } from './components/notas/notas.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavmenuComponent,
    PageNotFoundComponent,
    AlumnoComponent,
    RegistroComponent,
    UsuarioComponent,
    NotaComponent,
    NotasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    HttpClientXsrfModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule
  ],
  entryComponents: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
