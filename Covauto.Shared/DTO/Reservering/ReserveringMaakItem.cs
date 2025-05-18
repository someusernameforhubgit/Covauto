namespace Covauto.Shared.DTO.Reservering;

public class ReserveringMaakItem
{
    public int GebruikerID { get; set; }
    public int AutoID { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
}