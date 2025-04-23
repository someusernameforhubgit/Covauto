using Covauto.Application.DTO.Auto;
using Covauto.Domain.Data;

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
                Naam = item.Naam
            });
        return returnAutos;
    }
    
    public AutoItem GeefAuto(int id)
    {
        var autos = covautoContext.Autos.Select(n => n).Where(n => n.ID == id).ToList();
        if (autos.Count == 0) throw new KeyNotFoundException("Geen auto gevonden bij geven id");
        var auto = autos[0];
        var returnAuto = new AutoItem
        {
            ID = auto.ID,
            Naam = auto.Naam,
            KilometerStand = auto.KilometerStand
        };
        return returnAuto;
    }
}