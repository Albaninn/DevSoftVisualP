
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MarcaService } from 'src/app/marca.service';
import { Marca } from 'src/app/Marca';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-marca',
  templateUrl: './marca.component.html',
  styleUrls: ['./marca.component.css'],
})

export class MarcaComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private marcaService: MarcaService) {}

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Marca';
    this.formulario = new FormGroup({

      _idMarca: new FormControl(null),
      _nomeMarca: new FormControl(null),

    });
  }
  enviarFormulario(): void {
    const marca: Marca = this.formulario.value;
    console.log(marca);
    const observer: Observer<Marca> = {
      next(_result): void {
        alert('Marca salva com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {},
    };
    if (marca._idMarca && !isNaN(Number(marca._idMarca)))  {
      this.marcaService.alterar(marca).subscribe(observer);
    } else {
      this.marcaService.cadastrar(marca).subscribe(observer);
    }
  }
}