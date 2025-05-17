using Covauto.Shared.DTO.Rit;

namespace Covauto.Shared.DTO.Auto;

public class AutoItem : AutoListItem
{
    public int KilometerStand { get; set; }
    public List<RitListItem>? Ritten { get; set; }
}