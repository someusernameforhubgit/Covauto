using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Rit;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class RitRepository(CovautoContext ctx): AbstractRepository<RitListItem, RitItem, RitMaakItem, object>(ctx)
{
    public override async Task<IEnumerable<RitListItem>> GetAllAsync()
    {
        return await Ctx.Ritten.Select(item => new RitListItem
        {
            ID = item.ID,
            GebruikerId = item.GebruikerID,
            Begin = item.Begin,
            End = item.End
        }).ToListAsync();
    }

    public override async Task<RitItem> GetByIDAsync(int id)
    {
        var ritten = await Ctx.Ritten.Select(n => n).Where(n => n.ID == id).Include(n => n.Gebruiker).Include(n => n.Adressen).ToListAsync();
        if (ritten.Count == 0) throw new KeyNotFoundException("Geen rit gevonden bij geven id");
        var rit = ritten[0];
        var returnRit = new RitItem
        {
            ID = rit.ID,
            Begin = rit.Begin,
            End = rit.End,
            GebruikerId = rit.GebruikerID,
            Gebruiker = new GebruikerListItem
            {
                ID = rit.GebruikerID,
                Achternaam = rit.Gebruiker.Achternaam,
                Voornaam = rit.Gebruiker.Voornaam,
            },
            AutoId = rit.AutoID,
            Kilometers = rit.Kilometers,
            Adressen = []
        };
        if (!(rit.Adressen?.Count > 0)) return returnRit;
        foreach (var adres in rit.Adressen)
        {
            returnRit.Adressen.Add(new AdresListItem
            {
                ID = adres.ID,
                Huisnummer = adres.Huisnummer,
                Order = adres.Order,
                Land = adres.Land,
                Plaats = adres.Plaats,
                Straat = adres.Straat
            });
        }
        returnRit.Adressen = returnRit.Adressen.OrderBy(ad => ad.Order).ToList();
        return returnRit;
    }

    public override async Task<int> AddAsync(RitMaakItem item)
    {
        var gebruiker = await Ctx.Ritten.Include(r => r.Gebruiker)
            .FirstOrDefaultAsync(r => r.Gebruiker != null && r.Gebruiker.ID == item.GebruikerId);
        if (gebruiker == null) throw new KeyNotFoundException("Geen Gebruiker met dat ID gevonden");
        var auto = await Ctx.Ritten.Include(r => r.Auto)
            .FirstOrDefaultAsync(r => r.Auto != null && r.Auto.ID == item.AutoId);
        if (auto == null) throw new KeyNotFoundException("Geen Auto met dat ID gevonden");
        var rit = new Rit
        {
            GebruikerID = item.GebruikerId,
            AutoID = item.AutoId,
            Begin = item.Begin,
            End = item.End,
            Kilometers = item.Kilometers
        };

        await Ctx.Ritten.AddAsync(rit);
        await Ctx.SaveChangesAsync();
        
        return rit.ID;
    }
}