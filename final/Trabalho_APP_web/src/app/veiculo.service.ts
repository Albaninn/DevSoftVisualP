import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Veiculo } from './Veiculo';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {
  apiUrl = 'http://localhost:5000/Veiculo';
  constructor(private http: HttpClient) { }

  listar(): Observable<Veiculo[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Veiculo[]>(url);
  }

  buscar(placa: string): Observable<Veiculo> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Veiculo>(url);
  }

  cadastrar(veiculo: Veiculo): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Veiculo>(url, Veiculo, httpOptions);
  }

  alterar(veiculo: Veiculo): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Veiculo>(url, Veiculo, httpOptions);
  }

  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/excluir/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}