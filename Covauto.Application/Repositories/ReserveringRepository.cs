using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Reservering;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class ReserveringRepository(CovautoContext ctx): AbstractRepository<ReserveringListItem, ReserveringItem, ReserveringMaakItem, object>(ctx)
{
    public override async Task<IEnumerable<ReserveringListItem>> GetAllAsync()
    {
        return await Ctx.Reserveringen.Select(item => new ReserveringListItem
        {
            ID = item.ID,
            AutoID =  item.AutoID,
            Begin = item.Begin,
            End = item.End
        }).ToListAsync();
    }
    
    public override async Task<ReserveringItem> GetByIDAsync(int id)
    {
        var reservering = await Ctx.Reserveringen.Include(reservering => reservering.Auto)
            .Include(reservering => reservering.Gebruiker).FirstOrDefaultAsync(g => g.ID == id);
        
        if (reservering == null) return null;

        return new ReserveringItem
        {
            ID = reservering.ID,
            AutoID = reservering.AutoID,
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

    public override async Task<int> AddAsync(ReserveringMaakItem item)
    {
        var gebruiker = await Ctx.Reserveringen.Include(r => r.Gebruiker)
            .FirstOrDefaultAsync(r => r.Gebruiker != null && r.Gebruiker.ID == item.GebruikerID);
        if (gebruiker == null) throw new KeyNotFoundException("Geen Gebruiker met dat ID gevonden");
        var auto = await Ctx.Reserveringen.Include(r => r.Auto)
            .FirstOrDefaultAsync(r => r.Auto != null && r.Auto.ID == item.AutoID);
        if (auto == null) throw new KeyNotFoundException("Geen Auto met dat ID gevonden");
        var reservering = new Reservering
        {
            GebruikerID = item.GebruikerID,
            AutoID = item.AutoID,
            Begin = item.Begin,
            End = item.End
        };

        await Ctx.Reserveringen.AddAsync(reservering);
        await Ctx.SaveChangesAsync();
        
        return reservering.ID;
    }

    public override async Task DeleteAsync(int id)
    {
        var reservering = await Ctx.Reserveringen.FirstOrDefaultAsync(r => r.ID == id);
        if (reservering == null) throw new KeyNotFoundException("Geen Reservering met dat ID gevonden");

        Ctx.Reserveringen.Remove(reservering);
        await Ctx.SaveChangesAsync();
    }
}