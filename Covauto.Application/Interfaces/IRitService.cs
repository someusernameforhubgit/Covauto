using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Interfaces;

public interface IRitService
{
    public Task<IEnumerable<RitListItem>> GeefAlleRittenAsync();
    public Task<RitItem> GeefRitAsync(int id);
}