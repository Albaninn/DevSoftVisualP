import { Veiculo } from "./Veiculo";

export class Caminhonete extends Veiculo {
    _NroPortas: number;
    _Combustivel: string;

    constructor(placa: string, cor: string, idModelo: number, nroPortas: number, combustivel: string) {
        super();
        this._Placa = placa;
        this._Cor = cor;
        this._idModelo = idModelo;
        this._NroPortas = nroPortas;
        this._Combustivel = combustivel;
    }

    // Métodos específicos da Caminhonete podem ser adicionados aqui
}