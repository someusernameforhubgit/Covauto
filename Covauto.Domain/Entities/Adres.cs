namespace Covauto.Domain.Entities;

public class Adres
{
    public int ID { get; set; }
    public int Order { get; set; }
    public virtual Rit? Rit { get; set; }
    public int RitID { get; set; }
    public string Plaats { get; set; }
    public string Straat { get; set; }
    public string Huisnummer { get; set; }
    public string Land { get; set; }
}