using Covauto.Shared.DTO.Adres;

namespace Covauto.Shared.DTO.Rit;

public class RitMaakItem
{
    public int GebruikerId { get; set; }
    public int AutoId { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public int Kilometers { get; set; }
    
    public List<AdresMaakItem> Adressen { get; set; } = new();
}