import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Sucursal } from '../interfaces/Sucursal';

@Injectable({
  providedIn: 'root'
})
export class SucursalService {
  private AppUrl: string = environment.endpoint;
  private ApiUrl: string = 'api/Sucursal/';

  constructor(private http: HttpClient) { }

  getAllSucursales(): Observable<Sucursal[]> {
    return this.http.get<Sucursal[]>(`${this.AppUrl}${this.ApiUrl}`);
  }

  getSucursal(id: number): Observable<Sucursal> {
    return this.http.get<Sucursal>(`${this.AppUrl}${this.ApiUrl}${id}`);
  }

  deleteSucursales(id: number): Observable<void> {
    return this.http.delete<void>(`${this.AppUrl}${this.ApiUrl}${id}`);
  }

  addSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.post<Sucursal>(`${this.AppUrl}${this.ApiUrl}`, sucursal);
  }

  updateSucursal(id: number, sucursal: Sucursal): Observable<void> {
    return this.http.put<void>(`${this.AppUrl}${this.ApiUrl}${id}`, sucursal);
  }
}
