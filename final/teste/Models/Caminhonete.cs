using System.ComponentModel.DataAnnotations;

public class Caminhonete : Veiculo
{
    [Key]
    public int? Id {get; set;}
    public int? NroPortas {get; set;}
    public string? Combustivel {get; set;}

    public Veiculo? veiculo;

}
