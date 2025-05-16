using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Rit;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class RitRepository(CovautoContext ctx): AbstractRepository<RitListItem, RitItem>(ctx)
{
    public override async Task<IEnumerable<RitListItem>> GetAllAsync()
    {
        return await Ctx.Ritten.Select(item => new RitListItem
        {
            ID = item.ID,
            Datum = item.Datum,
            Gebruiker = new GebruikerListItem
            {
                ID = item.GebruikerID,
                Achternaam = item.Gebruiker.Achternaam,
                Voornaam = item.Gebruiker.Voornaam,
            },
            Kilometers = item.Kilometers,
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
            Datum = rit.Datum,
            Gebruiker = new GebruikerListItem
            {
                ID = rit.GebruikerID,
                Achternaam = rit.Gebruiker.Achternaam,
                Voornaam = rit.Gebruiker.Voornaam,
            },
            Kilometers = rit.Kilometers,
            Adressen = []
        };
        if (!(rit.Adressen?.Count > 0)) return returnRit;
        foreach (var adres in rit.Adressen)
        {
            returnRit.Adressen.Add(new AdresListItem
            {
                Huisnummer = adres.Huisnummer,
                Order = adres.Order,
                ID = adres.ID,
                Land = adres.Land,
                Plaats = adres.Plaats,
                Straat = adres.Straat
            });
        }
        returnRit.Adressen = returnRit.Adressen.OrderBy(ad => ad.Order).ToList();
        return returnRit;
    }
}