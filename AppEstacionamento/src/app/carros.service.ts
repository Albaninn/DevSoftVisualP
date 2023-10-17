import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Carro } from './Carro';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class CarrosService {
  url = 'http://localhost:5163/API_Estacionamento/Carro';
  constructor(private http: HttpClient) { }
  listar(): Observable<Carro[]> {
    return this.http.get<Carro[]>(this.url);
  }
  buscar(placa: string): Observable<Carro> {
    const apiUrl = `${this.url}/${placa}`;
    return this.http.get<Carro>(apiUrl); 
  }
  cadastrar(carro: Carro): Observable<any> {
    return this.http.post<Carro>(this.url, carro, httpOptions); 
  }
  atualizar(carro: Carro): Observable<any> {
    return this.http.put<Carro>(this.url, carro, httpOptions); 
  }
  excluir(placa: string): Observable<any> {
    const apiUrl = `${this.url}/${placa}`;
    return this.http.delete<string>(apiUrl, httpOptions); 
  }
}