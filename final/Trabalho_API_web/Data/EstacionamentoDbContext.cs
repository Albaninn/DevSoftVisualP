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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: "DataSource=estacionamento.db;Cache=Shared");
    }
}