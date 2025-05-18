using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Shared.DTO.Reservering;

public class ReserveringItem : ReserveringListItem
{
    public GebruikerListItem Gebruiker { get; set; }
    public AutoListItem Auto { get; set; }
}