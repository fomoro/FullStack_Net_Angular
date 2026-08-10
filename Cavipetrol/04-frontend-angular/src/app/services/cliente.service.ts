import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { ClienteDto } from '../models/cliente.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private http = inject(HttpClient);
  private baseUrl = `${environment.apiUrl}/clientes`;

  obtenerTodos(): Observable<ApiResponse<ClienteDto[]>> {
    return this.http.get<ApiResponse<ClienteDto[]>>(this.baseUrl);
  }

  obtenerPorIdentificacion(identificacion: string): Observable<ApiResponse<ClienteDto>> {
    return this.http.get<ApiResponse<ClienteDto>>(`${this.baseUrl}/${identificacion.trim()}`);
  }
}
