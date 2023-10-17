import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.css']
})
export class CarrosComponent implements OnInit{
  formulario: any;
  tituloFormulario: string = "Novo Carro";
  constructor() { }
  ngOnInit(): void {
    this.formulario = new FormGroup({
      placa: new FormControl(null),
      descricao: new FormControl(null)})
    }

}
