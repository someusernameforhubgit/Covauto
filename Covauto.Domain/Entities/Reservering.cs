namespace Covauto.Domain.Entities;

public class Reservering
{
    public int ID { get; set; }
    public virtual Gebruiker? Gebruiker { get; set; }
    public int GebruikerID { get; set; }
    public virtual Auto? Auto { get; set; }
    public int AutoID { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}