using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public int? Id {get; set;}
    public string? DescricaoModelo {get; set;}

    public enum Tamanho {pequeno, medio, grande};

    public Marca? Marca {get; set;}
    public Tamanho Porte {get; set;}
}
