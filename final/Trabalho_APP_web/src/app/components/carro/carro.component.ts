import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CarroService } from 'src/app/carro.service';
import { Carro } from 'src/app/Carro';

@Component({
  selector: 'app-carro',
  templateUrl: './carro.component.html',
  styleUrls: ['./carro.component.css']
})
export class CarroComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  constructor(private carrosService : CarroService) { }
  ngOnInit(): void {this.tituloFormulario = 'Novo Carro';
    this.formulario = new FormGroup({
      placa: new FormControl(null),
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const carro : Carro = this.formulario.value;
    this.carrosService.cadastrar(carro).subscribe(result => {
      alert('Carro inserido com sucesso.');
    })
  }
}