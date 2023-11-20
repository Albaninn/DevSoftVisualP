using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public int? idModelo {get; set;}
    public int? idMarca {get;set;}
    public Marca? Marca {get; set;}
    public string? nomeModelo {get; set;}
    public int? AnoModelo {get; set;}
    public enum segmento {automovel, moto, onibus, caminhão}
    public segmento Tipo {get; set;}
    public enum Tamanho {hatch, sedã, suv, picape, perua, minivan, esportivo, furgão}
    public Tamanho Porte {get; set;}
}
