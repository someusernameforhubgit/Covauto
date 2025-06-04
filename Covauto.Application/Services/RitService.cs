using Covauto.Application.Interfaces;
using Covauto.Domain.Data;
using Covauto.Shared.DTO.Rit;
using Covauto.Domain.Entities;

namespace Covauto.Application.Services;

public class RitService<TItem, TUpdateItem>(AbstractRepository<RitListItem, TItem, RitMaakItem, TUpdateItem> repository, CovautoContext context)
    : AbstractService<RitListItem, TItem, RitMaakItem, TUpdateItem>(repository)
{
    private readonly CovautoContext _context = context;

    public override async Task<int> AddAsync(RitMaakItem item)
    {
        var rit = new Rit
        {
            GebruikerID = item.GebruikerId,
            AutoID = item.AutoId,
            Begin = item.Begin,
            End = item.End,
            Kilometers = item.Kilometers,
            Adressen = item.Adressen.Select((a, i) => new Adres
            {
                Straat = a.Straat,
                Huisnummer = a.Huisnummer,
                Plaats = a.Plaats,
                Land = a.Land,
                Order = a.Order != 0 ? a.Order : i,
            }).ToList()
        };

        _context.Ritten.Add(rit);
        await _context.SaveChangesAsync();

        return rit.ID;
    }
}