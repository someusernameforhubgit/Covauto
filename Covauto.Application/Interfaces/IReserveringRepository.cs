using Covauto.Shared.DTO.Reservering;

namespace Covauto.Application.Interfaces;

public interface IReserveringRepository
{
    public Task<IEnumerable<ReserveringListItem>> GeefAlleReserveringenAsync();
    public Task<ReserveringItem> GeefReserveringAsync(int id);
}