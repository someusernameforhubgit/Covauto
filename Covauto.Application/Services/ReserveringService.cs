using System.ComponentModel.DataAnnotations;
using Covauto.Application.Interfaces;
using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Reservering;

namespace Covauto.Application.Services;

public class ReserveringService<TItem>(AbstractRepository<ReserveringListItem, TItem, ReserveringMaakItem, ReserveringUpdateItem> repository) : AbstractService<ReserveringListItem, TItem, ReserveringMaakItem, ReserveringUpdateItem>(repository)
{
    public override async Task<int> AddAsync(ReserveringMaakItem item)
    {
        var begin = item.Begin;
        var end = item.End;
        var reserveringen = (await Repository.GetAllAsync()).Where(r => r.AutoID == item.AutoID).Where(r => begin < r.End && end > r.Begin).ToList();
        if (reserveringen.Count > 0) throw new ValidationException("Er is een overlappende reservering.");
        return await Repository.AddAsync(item);
    }

    public override async Task UpdateAsync(int id, ReserveringUpdateItem item)
    {
        if (id != item.ID) throw new ValidationException("IDs zijn niet gelijk");

        var reservering = await Repository.GetByIDAsync(id);
        var auto = (reservering as ReserveringItem).AutoID;
        if (item.AutoID.HasValue) auto = item.AutoID.Value;
        if (!item.Begin.HasValue && !item.End.HasValue)
        {
            var begin = item.Begin;
            var end = item.End;
            var reserveringen = (await Repository.GetAllAsync()).Where(r => r.AutoID == item.AutoID)
                .Where(r => begin < r.End && end > r.Begin).Where(r => r.ID != id).ToList();
            if (reserveringen.Count > 0) throw new ValidationException("Er is een overlappende reservering.");
        }

        await Repository.UpdateAsync(id, item);
    }
}