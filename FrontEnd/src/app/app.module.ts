import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Modulos
import { SharedModule } from './shared/shared.module';

// Componentes
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgregarEditarSucursalComponent } from './components/agregar-editar-sucursal/agregar-editar-sucursal.component';
import { ListSucursalComponent } from './components/list-sucursal/list-sucursal.component';

@NgModule({
  declarations: [
    AppComponent,
    AgregarEditarSucursalComponent,
    ListSucursalComponent,
    AgregarEditarSucursalComponent,
    ListSucursalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
