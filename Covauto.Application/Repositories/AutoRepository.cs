using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Adres;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Gebruiker;
using Covauto.Shared.DTO.Rit;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class AutoRepository(CovautoContext covautoContext): IAutoRepository
{
    public IEnumerable<AutoListItem> GeefAlleAutos()
    {
        var returnAutos = new List<AutoListItem>();
        var autos = covautoContext.Autos.Select(n => n);
        foreach (var item in autos)
            returnAutos.Add(new AutoListItem
            {
                ID = item.ID,
                Merk = item.Merk,
                Model = item.Model,
                Kleur = item.Kleur,
                Beschikbaar = item.Beschikbaar
            });
        return returnAutos;
    }
    
    public AutoItem GeefAuto(int id)
    {
        var autos = covautoContext.Autos.Select(n => n).Where(n => n.ID == id).Include(n => n.Ritten)
            .ThenInclude(rit => rit.Adressen).Include(auto => auto.Ritten).ThenInclude(rit => rit.Gebruiker).ToList();
        if (autos.Count == 0) throw new KeyNotFoundException("Geen auto gevonden bij geven id");
        var auto = autos[0];
        var returnAuto = new AutoItem
        {
            ID = auto.ID,
            Merk = auto.Merk,
            Model = auto.Model,
            Kleur = auto.Kleur,
            KilometerStand = auto.KilometerStand,
            Beschikbaar = auto.Beschikbaar,
            Ritten = []
        };
        if (!(auto.Ritten?.Count > 0)) return returnAuto;
        foreach (var rit in auto.Ritten)
        {
            var newRit = new RitListItem
            {
                ID = rit.ID,
                Gebruiker = new GebruikerListItem
                {
                    ID = rit.Gebruiker.ID,
                    Voornaam = rit.Gebruiker.Voornaam,
                    Achternaam = rit.Gebruiker.Achternaam,
                },
                Kilometers = rit.Kilometers,
                Datum = rit.Datum,
            };
            returnAuto.Ritten.Add(newRit);
        }
        returnAuto.Ritten = returnAuto.Ritten.OrderByDescending(n => n.Datum).ToList();
        return returnAuto;
    }
}