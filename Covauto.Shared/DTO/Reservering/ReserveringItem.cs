using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Shared.DTO.Reservering;

public class ReserveringItem
{
    public int ID { get; set; }
    public AutoListItem Auto { get; set; }
    public GebruikerListItem Gebruiker { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}