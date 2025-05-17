using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;
using Microsoft.EntityFrameworkCore;

namespace Covauto.Application.Repositories;

public class AdresRepository(CovautoContext ctx) : AbstractRepository<AdresListItem, AdresItem>(ctx)
{
    public override Task<IEnumerable<AdresListItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<AdresItem> GetByIDAsync(int id)
    {
        throw new NotImplementedException();
    }

    public override async Task<int> AddAsync(AdresItem item)
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