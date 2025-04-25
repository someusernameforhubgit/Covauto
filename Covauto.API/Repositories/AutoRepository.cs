using Covauto.Application.DTO.Adres;
using Covauto.Application.DTO.Auto;
using Covauto.Application.DTO.Gebruiker;
using Covauto.Application.DTO.Rit;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Covauto.API.Repositories;

public class AutoRepository(CovautoContext covautoContext)
{
    public IEnumerable<AutoListItem> GeefAlleAutos()
    {
        var returnAutos = new List<AutoListItem>();
        var autos = covautoContext.Autos.Select(n => n);
        foreach (var item in autos)
            returnAutos.Add(new AutoListItem
            {
                ID = item.ID,
                Naam = item.Naam,
                Beschikbaar = item.Beschikbaar
            });
        return returnAutos;
    }
    
    public AutoItem GeefAuto(int id)
    {
        var autos = covautoContext.Autos.Select(n => n).Where(n => n.ID == id).Include(n => n.Ritten)
            .ThenInclude(rit => rit.Afkomst).Include(auto => auto.Ritten).ThenInclude(rit => rit.Bestemming).Include(auto => auto.Ritten).ThenInclude(rit => rit.Gebruiker).ToList();
        if (autos.Count == 0) throw new KeyNotFoundException("Geen auto gevonden bij geven id");
        var auto = autos[0];
        var returnAuto = new AutoItem
        {
            ID = auto.ID,
            Naam = auto.Naam,
            KilometerStand = auto.KilometerStand,
            Beschikbaar = auto.Beschikbaar,
            Ritten = new List<RitListItem>()
        };
        if (!(auto.Ritten?.Count > 0)) return returnAuto;
        foreach (var rit in auto.Ritten)
        {
            var newRit = new RitListItem
            {
                ID = rit.ID,
                Afkomst = new AdresListItem
                {
                    ID = rit.Afkomst.ID,
                    Plaats = rit.Afkomst.Plaats,
                    Straat = rit.Afkomst.Straat,
                    Huisnummer = rit.Afkomst.Huisnummer
                },
                Gebruiker = new GebruikerListItem
                {
                    ID = rit.Gebruiker.ID,
                    Naam = rit.Gebruiker.Naam
                },
                Bestemming = new AdresListItem
                {
                    ID = rit.Bestemming.ID,
                    Plaats = rit.Bestemming.Plaats,
                    Straat = rit.Bestemming.Straat,
                    Huisnummer = rit.Bestemming.Huisnummer
                },
                Kilometers = rit.Kilometers
            };
            returnAuto.Ritten.Add(newRit);
        }
        return returnAuto;
    }
}