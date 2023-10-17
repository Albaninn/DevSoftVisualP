using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace estacionamento;

public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> builder)
    {
        builder.HasKey(x =>x.Id);
        builder.Property(x => x._ClienteCpf).IsRequired();
        builder.Property(x => x._PeriodoId).IsRequired();
    }
}



//esta classe é para configurar o relacionamento 
//entre as chaves primarias e foreign key para conseguir inserir dados no banco.
//cada classe deve ter a sua
//pode se configurar o comportamento dos atributos tambem.
//material de apoio:
//https://www.youtube.com/watch?v=vLP3aRQWhTU