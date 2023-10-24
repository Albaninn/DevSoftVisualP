using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public string? Cpf {get; set;}
    public int? Id {get; set;}
    public string? Nome {get; set;}
    public string? Email {get; set;}
     // Lista de veículos associados ao cliente
    public virtual ICollection<Veiculo> Veiculos { get; set; }

}
