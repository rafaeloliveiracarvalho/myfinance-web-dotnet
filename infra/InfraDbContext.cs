using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infra;

public class InfraDbContext : DbContext
{
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Transacao> Transacao { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=sqlserver;Database=myfinancedb;User Id=sa;Password=Teste123@;TrustServerCertificate=True;Encrypt=False;");
    }

}


