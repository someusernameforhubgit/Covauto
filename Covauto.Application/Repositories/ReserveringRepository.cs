using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Reservering;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class ReserveringRepository(CovautoContext covautoContext): IReserveringRepository
{
    public async Task<IEnumerable<ReserveringListItem>> GeefAlleReserveringenAsync()
    {
        return await covautoContext.Reserveringen.Select(item => new ReserveringListItem
        {
            ID = item.ID,
            Auto = new AutoListItem
            {
                ID = item.Auto.ID,
                Kleur = item.Auto.Kleur,
                Merk = item.Auto.Merk,
                Model = item.Auto.Model,
            }
        }).ToListAsync();
    }
    
    public async Task<ReserveringItem> GeefReserveringAsync(int id)
    {
        var reservering = await covautoContext.Reserveringen.Include(reservering => reservering.Auto)
            .Include(reservering => reservering.Gebruiker).FirstOrDefaultAsync(g => g.ID == id);
        
        if (reservering == null) return null;

        return new ReserveringItem
        {
            ID = reservering.ID,
            Auto = new AutoListItem
            {
                ID = reservering.Auto.ID,
                Kleur = reservering.Auto.Kleur,
                Merk = reservering.Auto.Merk,
                Model = reservering.Auto.Model,
            },
            Gebruiker = new GebruikerListItem
            {
                ID = reservering.Gebruiker.ID,
                Voornaam = reservering.Gebruiker.Voornaam,
                Achternaam = reservering.Gebruiker.Achternaam,
            },
            Begin = reservering.Begin,
            End = reservering.End
        };
    }
}