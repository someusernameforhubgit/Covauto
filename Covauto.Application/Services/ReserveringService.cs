using Covauto.Application.Interfaces;
using Covauto.Application.Repositories;
using Covauto.Shared.DTO.Reservering;

namespace Covauto.Application.Services;

public class ReserveringService(IReserveringRepository reserveringRepository) : IReserveringService
{
    public async Task<IEnumerable<ReserveringListItem>> GeefAlleReserveringenAsync()
    {
        return await reserveringRepository.GeefAlleReserveringenAsync();
    }

    public async Task<ReserveringItem> GeefReserveringAsync(int id)
    {
        return await reserveringRepository.GeefReserveringAsync(id);
    }
}