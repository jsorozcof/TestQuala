import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Componentes
import { ListSucursalComponent } from './components/list-sucursal/list-sucursal.component';
import { AgregarEditarSucursalComponent } from './components/agregar-editar-sucursal/agregar-editar-sucursal.component';

const routes: Routes = [
  { path: '', redirectTo: 'listSucursal', pathMatch: 'full' },
  { path: 'listSucursal', component: ListSucursalComponent },
  { path: 'agregarSucursal', component: AgregarEditarSucursalComponent },
  { path: 'editarSucursal/:id', component: AgregarEditarSucursalComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
