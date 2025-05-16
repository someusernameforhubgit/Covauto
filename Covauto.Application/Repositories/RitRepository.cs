using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Rit;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class RitRepository(CovautoContext covautoContext): IRitRepository
{
    public IEnumerable<RitListItem> GeefAlleRitten()
    {
        var returnRitten = new List<RitListItem>();
        var ritten = covautoContext.Ritten.Select(n => n).Include(n => n.Gebruiker);
        Console.Out.WriteLine("Test");
        foreach (var item in ritten)
            returnRitten.Add(new RitListItem
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
            });
        return returnRitten;
    }

    public RitItem GeefRit(int id)
    {
        var ritten = covautoContext.Ritten.Select(n => n).Where(n => n.ID == id).Include(n => n.Gebruiker).Include(n => n.Adressen).ToList();
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
                ID = adres.ID,
                Huisnummer = adres.Huisnummer,
                Order = adres.Order,
                RitID = adres.RitID,
                Land = adres.Land,
                Plaats = adres.Plaats,
                Straat = adres.Straat
            });
        }
        returnRit.Adressen = returnRit.Adressen.OrderBy(ad => ad.Order).ToList();
        return returnRit;
    }
}