using Microsoft.EntityFrameworkCore;
using FinanceManager.Models;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { Database.Migrate(); }

    public DbSet<Finanza> Finanzas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
        new Categoria { Id = 1, Nombre = "Nomina" },
        new Categoria { Id = 2, Nombre = "Alimentacion" },
        new Categoria { Id = 3, Nombre = "Transporte" },
        new Categoria { Id = 4, Nombre = "Servicios" },
        new Categoria { Id = 5, Nombre = "Entretenimiento" },
        new Categoria { Id = 6, Nombre = "Hogar" },
        new Categoria { Id = 7, Nombre = "Salud" },
        new Categoria { Id = 8, Nombre = "Educacion" },
        new Categoria { Id = 9, Nombre = "Otros" }
    );

        base.OnModelCreating(modelBuilder);
    }
}
