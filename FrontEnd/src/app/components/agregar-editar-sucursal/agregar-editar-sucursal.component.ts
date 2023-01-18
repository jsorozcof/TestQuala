import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Sucursal } from 'src/app/interfaces/Sucursal';
import { SucursalService } from 'src/app/services/sucursal.service';

@Component({
  selector: 'app-agregar-editar-sucursal',
  templateUrl: './agregar-editar-sucursal.component.html',
  styleUrls: ['./agregar-editar-sucursal.component.css']
})
export class AgregarEditarSucursalComponent {
  loading: boolean = false;
  form: FormGroup;
  id: number;

  operacion: string = 'Agregar';

  constructor(private fb: FormBuilder,
    private Service: SucursalService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      raza: ['', Validators.required],
      color: ['', Validators.required],
      edad: ['', Validators.required],
      peso: ['', Validators.required],
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {

    if (this.id != 0) {
      this.operacion = 'Editar';
      this.obtenerSucursal(this.id)
    }
  }

  obtenerSucursal(id: number) {
    this.loading = true;
    this.Service.getSucursal(id).subscribe((data: { Codigo: any; Descripcion: any; Direccion: any; Identificacion: any; Moneda: any; }) => {
      this.form.setValue({
        Codigo: data.Codigo,
        Descripcion: data.Descripcion,
        Direccion: data.Direccion,
        Identificacion: data.Identificacion,
        Moneda: data.Moneda
      })
      this.loading = false;
    })
  }

  agregarOEditarSucursal() {

    const sucursal: Sucursal = {
      Id: this.form.value.Id,
      Codigo: this.form.value.Codigo,
      Descripcion: this.form.value.Descripcion,
      Direccion: this.form.value.Direccion,
      Identificacion: this.form.value.Identificacion,
      Moneda: this.form.value.Moneda
    }

    if (this.id != 0) {
      sucursal.Id = this.id;
      this.editarSucursal(this.id, sucursal);
    } else {
      this.agregarSucursal(sucursal);
    }
  }

  editarSucursal(id: number, sucursal: Sucursal) {
    this.loading = true;
    this.Service.updateSucursal(id, sucursal).subscribe(() => {
      this.loading = false;
      console.log('llegue')
      this.mensajeExito('actualizada');
      this.router.navigate(['/listSucursal']);
    })
  }

  agregarSucursal(sucursal: Sucursal) {
    this.Service.addSucursal(sucursal).subscribe((data: any) => {
      this.mensajeExito('registrada');
      this.router.navigate(['/listSucursal']);
    })
  }

  mensajeExito(texto: string) {
    this._snackBar.open(`La sucursal fue ${texto} con exito`, '', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }
}
