using Microsoft.EntityFrameworkCore;

public class EstacionamentoDbContext : DbContext
{
    public DbSet<Veiculo>? veiculo {get; set;}
    public DbSet<Carro>? carro {get; set;}
    public DbSet<Moto>? moto {get; set;}
    public DbSet<Caminhonete>? caminhonete {get; set;}
    public DbSet<Cliente>? cliente {get; set;}
    public DbSet<NotaFiscal>? notasFiscais {get; set;}
    public DbSet<Servico>? servico {get; set;}
    public DbSet<Periodo>? periodo {get; set;}
    public DbSet<Ticket>? ticket {get; set;}
    //----------------------------------------------------------------------------------
    //configuração de conexão com o banco
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=estacionamento.db;Cache=Shared");
    }


    //------------------------------------------------------------------------------------
    //configuração de sobreescrita de metodo para indicar relacionamento entre chaves
    //https://www.youtube.com/watch?v=urXm22LdBfI

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(EstacionamentoDbContext).Assembly);
    }
}