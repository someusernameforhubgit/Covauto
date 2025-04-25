using Covauto.Application.DTO.Adres;
using Covauto.Application.DTO.Gebruiker;

namespace Covauto.Application.DTO.Rit;

public class RitListItem
{
    public int ID { get; set; }
    public AdresListItem Afkomst { get; set; }
    public GebruikerListItem Gebruiker { get; set; }
    public int Kilometers { get; set; }
    public AdresListItem Bestemming { get; set; }
}