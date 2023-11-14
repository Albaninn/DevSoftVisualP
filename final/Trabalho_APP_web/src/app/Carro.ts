import { Veiculo } from "./Veiculo";

export class Carro extends Veiculo {
    _NroPortas: number;

    constructor(placa: string, cor: string, idModelo: number, nroPortas: number) {
        super();
        this._Placa = placa;
        this._Cor = cor;
        this._idModelo = idModelo;
        this._NroPortas = nroPortas;
    }

    // Métodos específicos do Carro podem ser adicionados aqui
}