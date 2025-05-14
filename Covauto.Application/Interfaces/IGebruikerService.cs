using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Application.Interfaces;

public interface IGebruikerService
{
    public Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync();
    public Task<GebruikerItem> GeefGebruikerAsync(int id);
}