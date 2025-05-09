namespace Covauto.Domain.Entities;

public class Rit
{
    public int ID { get; set; }
    public virtual Gebruiker? Gebruiker { get; set; }
    public int GebruikerID { get; set; }
    public int Kilometers { get; set; }
    public ICollection<Adres>? Adressen { get; set; }
    public virtual Auto? Auto { get; set; }
    public int AutoID { get; set; }
    public DateTime Datum { get; set; }
}
