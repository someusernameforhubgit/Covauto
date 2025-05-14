using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Interfaces;

public interface IRitRepository
{
    public Task<IEnumerable<RitListItem>> GeefAlleRittenAsync();
    public Task<RitItem> GeefRitAsync(int id);
}