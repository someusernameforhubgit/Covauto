using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Shared.DTO.Rit;

public class RitListItem
{
    public int ID { get; set; }
    public List<AdresListItem>? Adressen { get; set; }
    public GebruikerListItem Gebruiker { get; set; }
    public int Kilometers { get; set; }
    public DateTime Datum { get; set; }
}