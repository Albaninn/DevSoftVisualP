using System.ComponentModel.DataAnnotations;

public class Marca
{
    [Key]
    public int? idMarca {get; set;}
    public string? nomeMarca {get; set;}
}
