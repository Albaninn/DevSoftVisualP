using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

public class Periodo
{
    [Key]
    public int? Id {get; set;}
    public DateTime? HoraEntrada { get; set; }
    public DateTime? HoraSaida {get; set;}




    //----------------------------------------------------------------


    public Periodo? solicitarEntrada(Boolean entra)

    { 
        if(entra == true){
            this.HoraEntrada = DateTime.Now;
        return this;
        }
        else{
            return null;
        }
    }


    public Periodo? solicitarSaida(Boolean sair)
    { 
        if(sair == true)
        {
            this.HoraSaida = DateTime.Now;
            return this;

        }
        else{
            return null;
        }
             
     }

    public TimeSpan? processarPermanencia()
    {
        if (HoraEntrada != default && HoraSaida != default)
        {
            var tempo = HoraSaida - HoraEntrada;
            return tempo;
        }
        else
        {
            return null;
        }
    }
}


    


