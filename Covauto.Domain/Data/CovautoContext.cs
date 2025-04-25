using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Domain.Data;

public class CovautoContext(DbContextOptions<CovautoContext> options) : DbContext(options)
{
    public DbSet<Auto> Autos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Auto>().HasData(new Auto { ID = 1, Naam = "Auto 1",  KilometerStand = 0, Beschikbaar = true});
    }
}