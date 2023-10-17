using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace estacionamento;

public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
{
    public void Configure(EntityTypeBuilder<NotaFiscal> builder)
    {
        builder.HasKey(x =>x.NumeroNota);
        builder.Property(x => x.Servico.Id).IsRequired();
        builder.Property(x => x.Cliente.Cpf).IsRequired();
    }
}



//esta classe é para configurar o relacionamento 
//entre as chaves primarias e foreign key para conseguir inserir dados no banco.
//cada classe deve ter a sua
//pode se configurar o comportamento dos atributos tambem.
//material de apoio:
//https://www.youtube.com/watch?v=vLP3aRQWhTU