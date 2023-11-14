import { Marca } from "./Marca";

export class Modelo {
    _idModelo: number = 0;
    _nomeModelo: String = "";
    _AnoModelo: number = 0;
    _segmento: String ="";
    _TipoModelo: String = "";
    _idMarca: Marca | undefined;
}