using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Shared.DTO.Rit;

public class RitListItem
{
    public int ID { get; set; }
    public int GebruikerId { get; set; }
    public DateTime Datum { get; set; }
}