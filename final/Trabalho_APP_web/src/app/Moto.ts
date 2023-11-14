import { Veiculo } from "./Veiculo";

export class Moto extends Veiculo {
    _Bau: boolean;

    constructor(placa: string, cor: string, idModelo: number, bau: boolean) {
        super();
        this._Placa = placa;
        this._Cor = cor;
        this._idModelo = idModelo;
        this._Bau = bau;
    }

    // Métodos específicos da Moto podem ser adicionados aqui
}