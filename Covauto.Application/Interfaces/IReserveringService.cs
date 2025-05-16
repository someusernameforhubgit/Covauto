using Covauto.Shared.DTO.Reservering;

namespace Covauto.Application.Interfaces;

public interface IReserveringService
{
    public Task<IEnumerable<ReserveringListItem>> GeefAlleReserveringenAsync();
    public Task<ReserveringItem> GeefReserveringAsync(int id);
}