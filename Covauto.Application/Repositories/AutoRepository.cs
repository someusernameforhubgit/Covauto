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
    public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
    {
        return await covautoContext.Autos.Select(item => new AutoListItem
        {
            ID = item.ID,
            Merk = item.Merk,
            Model = item.Model,
            Kleur = item.Kleur
        }).ToListAsync();
    }
    
    public async Task<AutoItem> GeefAutoAsync(int id)
    {
        var autos = await covautoContext.Autos.Select(n => n).Where(n => n.ID == id).Include(n => n.Ritten)
            .ThenInclude(rit => rit.Adressen).Include(auto => auto.Ritten).ThenInclude(rit => rit.Gebruiker).ToListAsync();
        if (autos.Count == 0) throw new KeyNotFoundException("Geen auto gevonden bij geven id");
        var auto = autos[0];
        var returnAuto = new AutoItem
        {
            ID = auto.ID,
            Merk = auto.Merk,
            Model = auto.Model,
            Kleur = auto.Kleur,
            KilometerStand = auto.KilometerStand,
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