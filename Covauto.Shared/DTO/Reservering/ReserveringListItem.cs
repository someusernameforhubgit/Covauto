using Covauto.Shared.DTO.Auto;

namespace Covauto.Shared.DTO.Reservering;

public class ReserveringListItem
{
    public int ID { get; set; }
    public int AutoID { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}