import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VeiculoComponent } from './components/veiculo/veiculo.component';
import { ModeloComponent } from './components/modelo/modelo.component';
import { MarcaComponent } from './components/marca/marca.component';
import { CarroComponent } from './components/carro/carro.component';
import { MotoComponent } from './components/moto/moto.component';
import { CaminhoneteComponent } from './components/caminhonete/caminhonete.component';

const routes: Routes = [
  {path: 'veiculo', component: VeiculoComponent},
  {path: 'carro', component: CarroComponent},
  {path: 'moto', component: MotoComponent},
  {path: 'caminhonete', component: CaminhoneteComponent},
  {path: 'marca', component: MarcaComponent},
  {path: 'modelo', component: ModeloComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
