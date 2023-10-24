using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

public class Veiculo
{
    [Key]
    public string? Placa {get; set;}
    public int? Id {get; set;}
    public string? Descricao {get; set;}
    public enum Cor {Vermelho, Branco, Preto, Prata}
    public Cor CorExterna {get; set;}
    public Modelo?  Modelo {get; set;}

    /*// Chave estrangeira para Cliente
    public string? ClienteCpf { get; set; }

    // Propriedade de navegação para Cliente
    // [ForeignKey("ClienteCpf")]
    public virtual Cliente? Cliente { get; set; } */
}
