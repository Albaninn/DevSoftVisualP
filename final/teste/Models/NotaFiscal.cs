using System.ComponentModel.DataAnnotations;

public class NotaFiscal
{
    [Key]
    public string? NumeroNota { get; set; }
    public double ValorDaNota { get; set; }
    public Servico? Servico { get; set; }
    public Cliente? Cliente { get; set; }

    public void EmiteNF(string CPF, double ValorAPagar)
    {
        ValorDaNota = ValorAPagar;
    }
}

