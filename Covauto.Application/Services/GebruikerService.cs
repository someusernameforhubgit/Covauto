using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.Application.Services;

public class GebruikerService(IGebruikerRepository gebruikerRepository) : IGebruikerService
{
    public async Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync()
    {
        return await gebruikerRepository.GeefAlleGebruikersAsync();
    }

    public async Task<GebruikerItem> GeefGebruikerAsync(int id)
    {
        return await gebruikerRepository.GeefGebruikerAsync(id);
    }
}