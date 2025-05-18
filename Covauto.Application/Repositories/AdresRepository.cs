using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class AdresRepository(CovautoContext ctx) : AbstractRepository<object, object, AdresMakeItem, object>(ctx)
{
    public override async Task<int> AddAsync(AdresMakeItem item)
    {
        var rit = Ctx.Ritten.Include(rit => rit.Adressen).FirstOrDefault(r => r.ID == item.RitID);
        if (rit == null) throw new KeyNotFoundException("Geen Rit met dat ID gevonden");
        var adres = new Adres
        {
            Plaats = item.Plaats,
            Straat = item.Straat,
            Huisnummer = item.Huisnummer,
            Land = item.Land,
            Order = rit.Adressen.Count,
            RitID = item.RitID
        };

        await Ctx.Adressen.AddAsync(adres);
        await Ctx.SaveChangesAsync();
        
        return adres.ID;
    }
}