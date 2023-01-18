import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Sucursal } from 'src/app/interfaces/Sucursal';
import { SucursalService } from 'src/app/services/sucursal.service';

@Component({
  selector: 'app-list-sucursal',
  templateUrl: './list-sucursal.component.html',
  styleUrls: ['./list-sucursal.component.css']
})
export class ListSucursalComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['Codigo', 'Descripcion', 'Direccion', 'Identificacion', 'Moneda', 'Acciones'];
  dataSource = new MatTableDataSource<Sucursal>();
  loading: boolean = false;

  listSucursales: any;

  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar,
    private _service: SucursalService) { }

  ngOnInit(): void {
    this.obtenerSucursales();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if (this.dataSource.data.length > 0) {
      this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerSucursales() {

    this.loading = true;
    this._service.getAllSucursales().subscribe(data => {
      this.loading = false;
      this.listSucursales = data.values;
      console.log("data", data);
      this.dataSource.data = this.listSucursales
    })
  }


  eliminarSucursal(id: number) {
    this.loading = true;
   console.log("id", id);
    this._service.deleteSucursales(id).subscribe(() => {
      this.mensajeExito();
      this.loading = false;
      this.obtenerSucursales();
    });
    
  }

  mensajeExito() {
    this._snackBar.open('La Sucrusal fue eliminada con exito', '', {
      duration: 4000,
      horizontalPosition: 'right',
    });
  }
}
