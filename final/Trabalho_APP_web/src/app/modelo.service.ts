import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Modelo } from './Modelo';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ModeloService {
  apiUrl = 'http://localhost:5000/Modelo';
  constructor(private http: HttpClient) { }

  listar(): Observable<Modelo[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Modelo[]>(url);
  }

  buscar(id : number): Observable<Modelo> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Modelo>(url);
  }

  cadastrar(modelo: Modelo): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, modelo, httpOptions);
  }

  alterar(modelo: Modelo): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, modelo, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}