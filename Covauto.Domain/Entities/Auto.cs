namespace Covauto.Domain.Entities;

public class Auto
{
    public int ID { get; set; }
    public string Merk { get; set; }
    public string Model { get; set; }
    public string Kleur { get; set; }
    public int KilometerStand { get; set; }
    public bool Beschikbaar { get; set; }
    public ICollection<Rit>? Ritten { get; set; }
}