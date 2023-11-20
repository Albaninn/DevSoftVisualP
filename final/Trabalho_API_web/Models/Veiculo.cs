using System.ComponentModel.DataAnnotations;

public class Veiculo
{
    [Key]
    public int? idVeiculo {get; set;}
    public string? Placa {get; set;}
    public enum Cor {Vermelho, Branco, Preto, Prata}
    public Cor CorExterna {get; set;}
    public int? idModelo {get; set;}
    public Modelo?  Modelo {get; set;}
    public List<Cliente>? Clientes { get; set; }
}
