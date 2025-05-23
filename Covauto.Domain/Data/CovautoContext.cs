using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Domain.Data;

public class CovautoContext(DbContextOptions<CovautoContext> options) : DbContext(options)
{
    public DbSet<Auto> Autos { get; set; }
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Adres> Adressen { get; set; }
    public DbSet<Rit> Ritten { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Auto>().HasData(new Auto 
        { 
            ID = 1,
            Merk = "Honda",
            Model = "Civic",
            Kleur = "Zwart",
            KilometerStand = 1000
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
            AutoID = 1,
            GebruikerID = 1,
            Kilometers = 1000,
            Begin = new DateTime(2025, 12, 5, 12, 00, 00),
            End = new DateTime(2025, 12, 5, 14, 00, 00),
        });
        modelBuilder.Entity<Adres>().HasData(new Adres
        {
            ID = 1,
            Order = 1,
            RitID = 1,
            Plaats = "Doetinchem",
            Straat = "Expiditieweg",
            Huisnummer = "6A",
            Land = "Nederland"
        });
        modelBuilder.Entity<Adres>().HasData(new Adres
        {
            ID = 2,
            Order = 2,
            RitID = 1,
            Plaats = "Doetinchem", 
            Straat = "J.F. Kennedylaan", 
            Huisnummer = "49",
            Land = "Nederland"
        });
        modelBuilder.Entity<Reservering>().HasData(new Reservering
        {
            ID = 1,
            AutoID = 1,
            GebruikerID = 1,
            Begin = new DateTime(2025, 12, 6, 12, 00, 00),
            End = new DateTime(2025, 12, 6, 15, 00, 00)
        });
    }
}