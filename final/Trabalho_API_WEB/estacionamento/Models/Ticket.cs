//Autor: Jhonny Guimarães

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public class Ticket
{   
    [Key]
    public int Id {get; set;}
    public  int CodTicket {get; set;}

    public int ServicoId {get; set;}//atributo para inserir dado no banco
    public String VeiculoPlaca{get; set;}//atributo para inserir dado no banco

    //-------------------------------------------------------------------------

    public Servico Servico {get; set;}//referenciamento chave estrangeira de servico
    public Veiculo Veiculo { get; set;}//referenciamento chave estrangeira de veiculo
    

    //-------------------------------------------------------------------------
    public Ticket() { }

    public Ticket(int id, int cod, Boolean ativar){
        this.Id = 0;
        this.CodTicket = 0;
        Servico._Periodo.solicitarEntrada(ativar);

    }
    //-------------------------------------------------------------------------

    public virtual ICollection<Periodo> Periodos { get; set; }//propiedade do sistema para interligar/mapear chaves
    public virtual ICollection<Veiculo> Veiculos { get; set; }//propiedade do sistema para interligar/mapear chaves   

    public virtual ICollection<Ticket> Tickets{get; set;}//propiedade do sistema para interligar/mapear chaves   

    //----------------------------------------------------------------

    public Ticket solicitarTicket()
    { 
        
        return new Ticket();
         
    }


}

