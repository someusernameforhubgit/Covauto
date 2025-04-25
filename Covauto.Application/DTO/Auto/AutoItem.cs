using Covauto.Application.DTO.Rit;

namespace Covauto.Application.DTO.Auto;

public class AutoItem
{
    public int ID { get; set; }
    public string Naam { get; set; }
    public int KilometerStand { get; set; }
    public bool Beschikbaar { get; set; }
    public ICollection<RitListItem>? Ritten { get; set; }
}