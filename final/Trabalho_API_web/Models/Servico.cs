//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
public class Servico
{
	[Key]
	public int Id { get; set; }
	public string? DescricaoServico { get; set; }
	public double ValorHora { get; set; }
	public double? ValorPagar { get; set; }
	public string _ClienteCpf {get; set;}//atributo para poder inserir dados no banco
	public int _PeriodoId {get; set;}//atributo para poder inserir dados no banco

	//----------------------------------------------------------------

	public Cliente? _Cliente { get; set; }//chave estrangeira do cliente

	public Periodo? _Periodo { get; set; }//chave estrangeira do periodo


	//----------------------------------------------------------------

	public virtual ICollection<Periodo> Periodos { get; set; }//propiedade do sistema para interligar/mapear chaves


    //----------------------------------------------------------------


	public Servico calcularServico()
    {
		var perma =  _Periodo.processarPermanencia().GetValueOrDefault().Hours;

		this.ValorPagar =  this.ValorPagar * perma;

		return this;
	}

}
