using System.ComponentModel.DataAnnotations;

public class Moto : Veiculo
{
    [Key]
    public int? Id {get; set;}
    public Boolean? Bau {get; set;}

    public Veiculo? veiculo;
}
