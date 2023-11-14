import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { VeiculoService } from 'src/app/veiculo.service';
import { Veiculo } from '../../Veiculo';
import { Modelo } from 'src/app/Modelo';
import { ModeloService } from 'src/app/modelo.service';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculo.component.html',
  styleUrls: ['./veiculo.component.css']
})

export class VeiculoComponent implements OnInit {

  formulario: any;
  tituloFormulario: string = '';
  modelos: Array<Modelo> | undefined;
  
  constructor(private veiculosService : VeiculoService, private modelosService : ModeloService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Veiculo';

    this.modelosService.listar().subscribe(modelos => {
      this.modelos = modelos;
      if (this.modelos && this.modelos.length > 0) {
        this.formulario.get('_idModelo')?.setValue(this.modelos[0]._idModelo);
      }
    });
    this.formulario = new FormGroup({
      
      _idVeiculo: new FormControl(null),
      _Placa: new FormControl(null),
      _Cor: new FormControl(null),
      _idModelo: new FormControl(null)
      
    })
  }
    enviarFormulario(): void {
      const veiculo: Veiculo = this.formulario.value;
      const observer: Observer<Veiculo> = {
        next(_result): void {
          alert('Veiculo salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };

    /*
    if (????) {
      this.carrosService.alterar(carro).subscribe(observer);
    } else {
    */
      this.veiculosService.cadastrar(veiculo).subscribe(observer);
  }
}