namespace Covauto.Domain.Entities;

public class Gebruiker
{
    public int ID { get; set; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public bool Admin { get; set; }
}