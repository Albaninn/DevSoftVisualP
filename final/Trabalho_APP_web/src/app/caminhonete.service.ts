import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Caminhonete } from './Caminhonete';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CaminhoneteService {
  apiUrl = 'http://localhost:5000/Caminhonete';
  constructor(private http: HttpClient) { }

  listar(): Observable<Caminhonete[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Caminhonete[]>(url);
  }

  buscar(placa: string): Observable<Caminhonete> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Caminhonete>(url);
  }

  cadastrar(caminhonete: Caminhonete): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Caminhonete>(url, Caminhonete, httpOptions);
  }

  alterar(caminhonete: Caminhonete): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Caminhonete>(url, Caminhonete, httpOptions);
  }

  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/excluir/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}