using System.ComponentModel.DataAnnotations;

public class Marca
{
    [Key]
    public int? Id {get; set;}
    public string? DescricaoMarca {get; set;}
}
