using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Domain.Data;

public class CovautoContext(DbContextOptions<CovautoContext> options) : DbContext(options)
{
    public DbSet<Auto> Autos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Auto>().HasData(new Auto 
        { 
            ID = 1,
            Merk = "Honda",
            Model = "Civic",
            Kleur = "Zwart",
            KilometerStand = 1000,
            Beschikbaar = true
        });
        modelBuilder.Entity<Adres>().HasData(new Adres
        {
            ID = 1, 
            Plaats = "Doetinchem", 
            Straat = "J.F. Kennedylaan", 
            Huisnummer = "49",
            Land = "Nederland"
        });
        modelBuilder.Entity<Adres>().HasData(new Adres
        {
            ID = 2,
            Plaats = "Doetinchem",
            Straat = "Expiditieweg",
            Huisnummer = "6A",
            Land = "Nederland"
        });
        modelBuilder.Entity<Gebruiker>().HasData(new Gebruiker
        {
            ID = 1,
            Voornaam = "Bas",
            Achternaam = "Peter",
            Admin = true,
        });
        modelBuilder.Entity<Rit>().HasData(new Rit
        {
            ID = 1,
            AfkomstID = 2,
            BestemmingID = 1,
            AutoID = 1,
            GebruikerID = 1,
            Kilometers = 1000,
            Datum = DateTime.Now
        });
    }
}