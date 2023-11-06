using System.ComponentModel.DataAnnotations;

public class Veiculo
{
    [Key]
    public string? Placa {get; set;}
    public enum Cor {Vermelho, Branco, Preto, Prata}
    public Cor CorExterna {get; set;}
    public int? ModeloId {get; set;}
    public Modelo?  Modelo {get; set;}
    public string? Descricao {get; set;}
    public List<Cliente>? Clientes { get; set; }
}
