import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { VeiculoService } from './veiculo.service';
import { CarroService } from './carro.service';
import { MotoService } from './moto.service';
import { CaminhoneteService } from './caminhonete.service';
import { ModeloService } from './modelo.service';
import { MarcaService } from './marca.service';

import { VeiculoComponent } from './components/veiculo/veiculo.component';
import { ModeloComponent } from './components/modelo/modelo.component';
import { MarcaComponent } from './components/marca/marca.component';
import { CarroComponent } from './components/carro/carro.component';
import { MotoComponent } from './components/moto/moto.component';
import { CaminhoneteComponent } from './components/caminhonete/caminhonete.component';

@NgModule({
  declarations: [
    AppComponent,
    VeiculoComponent,
    ModeloComponent,
    MarcaComponent,
    CarroComponent,
    MotoComponent,
    CaminhoneteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [
    HttpClientModule, 
    CarroService, 
    VeiculoService, 
    MotoService, 
    CaminhoneteService, 
    ModeloService, 
    MarcaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
