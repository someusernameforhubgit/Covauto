using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Shared.DTO.Rit;

public class RitItem : RitListItem
{
    public List<AdresListItem>? Adressen { get; set; }
}