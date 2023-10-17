using System.ComponentModel.DataAnnotations;

public class Carro : Veiculo
{
    [Key]
    public int? Id {get; set;}
    public int? NroPortas {get; set;}

    public Veiculo? veiculo;
}
