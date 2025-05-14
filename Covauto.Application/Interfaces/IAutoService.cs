using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Interfaces;

public interface IAutoService
{
    public Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync();
    public Task<AutoItem> GeefAutoAsync(int id);
}