using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class GebruikerRepository(CovautoContext ctx): AbstractRepository<GebruikerListItem, GebruikerItem>(ctx)
{
    public override async Task<IEnumerable<GebruikerListItem>> GetAllAsync()
    {
        return await Ctx.Gebruikers.Select(item => new GebruikerListItem
        {
            ID = item.ID,
            Voornaam = item.Voornaam,
            Achternaam = item.Achternaam
        }).ToListAsync();
    }
    
    public override async Task<GebruikerItem> GetByIDAsync(int id)
    {
        var gebruiker = await Ctx.Gebruikers.FirstOrDefaultAsync(g => g.ID == id);
        
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