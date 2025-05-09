namespace Covauto.Domain.Entities;

public class Rit
{
    public int ID { get; set; }
    public virtual Adres? Afkomst { get; set; }
    public int AfkomstID { get; set; }
    public virtual Gebruiker? Gebruiker { get; set; }
    public int GebruikerID { get; set; }
    public int Kilometers { get; set; }
    public virtual Adres? Bestemming { get; set; }
    public int BestemmingID { get; set; }
    public virtual Auto? Auto { get; set; }
    public int AutoID { get; set; }
    public DateTime Datum { get; set; }
}
