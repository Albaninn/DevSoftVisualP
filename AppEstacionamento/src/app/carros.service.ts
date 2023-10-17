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
}