import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Moto } from './Moto';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class MotoService {
  apiUrl = 'http://localhost:5000/Moto';
  constructor(private http: HttpClient) { }
  
  listar(): Observable<Moto[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Moto[]>(url);
  }
  buscar(placa: string): Observable<Moto> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Moto>(url);
  }
  cadastrar(moto: Moto): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Moto>(url, moto, httpOptions);
  }
  alterar(moto: Moto): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Moto>(url, moto, httpOptions);
  }
  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
