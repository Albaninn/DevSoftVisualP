using System.ComponentModel.DataAnnotations;

public class Modelo
{
    [Key]
    public int? Id {get; set;}
    public int? MarcaId {get;set;}
    public Marca? Marca {get; set;}
    public string? DescricaoModelo {get; set;}
    public enum Tamanho {pequeno, medio, grande}
    public Tamanho Porte {get; set;}
}
