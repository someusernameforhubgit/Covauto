using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Application.Interfaces;

public interface IGebruikerRepository
{
    public IEnumerable<GebruikerListItem> GeefAlleGebruikers();
    public GebruikerItem GeefGebruiker(int id);
}