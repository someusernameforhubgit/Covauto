using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class GebruikerRepository(CovautoContext covautoContext): IGebruikerRepository
{
    public async Task<IEnumerable<GebruikerListItem>> GeefAlleGebruikersAsync()
    {
        return await covautoContext.Gebruikers.Select(item => new GebruikerListItem
        {
            ID = item.ID,
            Voornaam = item.Voornaam,
            Achternaam = item.Achternaam
        }).ToListAsync();
    }
    
    public async Task<GebruikerItem> GeefGebruikerAsync(int id)
    {
        var gebruiker = await covautoContext.Gebruikers.FirstOrDefaultAsync(g => g.ID == id);
        
        if (gebruiker == null) return null;

        return new GebruikerItem
        {
            ID = gebruiker.ID,
            Voornaam = gebruiker.Voornaam,
            Achternaam = gebruiker.Achternaam,
            Admin = gebruiker.Admin
        };
    }
}