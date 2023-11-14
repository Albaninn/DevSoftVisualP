import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ModeloService } from 'src/app/modelo.service';
import { Modelo } from 'src/app/Modelo';
import { Marca } from 'src/app/Marca';
import { MarcaService } from 'src/app/marca.service';

@Component({
  selector: 'app-modelo',
  templateUrl: './modelo.component.html',
  styleUrls: ['./modelo.component.css']
})
export class ModeloComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  marca: Array<Marca> | undefined;

  constructor(private modeloService : ModeloService, private marcaService: MarcaService) { }

  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Modelo';

    this.marcaService.listar().subscribe(marca => {
      this.marca = marca;
      if (this.marca && this.marca.length > 0) {
        this.formulario.get('_idMarca')?.setValue(this.marca[0]._idMarca);
      }
    });
    
    this.formulario = new FormGroup({
      _idModelo: new FormControl(null),
      _nomeModelo: new FormControl(null),
      _segmento: new FormControl(null),
      _motor: new FormControl(null),
      _qtdPortas: new FormControl(null),
      _AnoModelo: new FormControl(null),
      _TipoModelo: new FormControl(null),
      _idMarca: new FormControl(null)

    })
  }
  enviarFormulario(): void {
    const modelo: Modelo = this.formulario.value;
    const observer: Observer<Modelo> = {
      next(_result): void {
        alert('Modelo salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (modelo._idModelo && !isNaN(Number(modelo._idModelo))) {
      this.modeloService.alterar(modelo).subscribe(observer);
    } else {
      this.modeloService.cadastrar(modelo).subscribe(observer);
    }
  }
}