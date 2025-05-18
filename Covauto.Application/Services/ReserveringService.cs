using System.ComponentModel.DataAnnotations;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Reservering;

namespace Covauto.Application.Services;

public class ReserveringService<TItem, TUpdateItem>(AbstractRepository<ReserveringListItem, TItem, ReserveringMaakItem, TUpdateItem> repository) : AbstractService<ReserveringListItem, TItem, ReserveringMaakItem, TUpdateItem>(repository)
{
    public override async Task<int> AddAsync(ReserveringMaakItem item)
    {
        var begin = item.Begin;
        var end = item.End;
        var reserveringen = (await Repository.GetAllAsync()).Where(r => r.AutoID == item.AutoID).Where(r => begin < r.End && end > r.Begin).ToList();
        if (reserveringen.Count > 0) throw new ValidationException("Er is een overlappende reservering.");
        return await Repository.AddAsync(item);
    }
}