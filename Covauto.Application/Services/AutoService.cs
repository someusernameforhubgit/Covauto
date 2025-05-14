using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Services;

public class AutoService(IAutoRepository autoRepository) : IAutoService
{
    public async Task<IEnumerable<AutoListItem>> GeefAlleAutosAsync()
    {
        return await autoRepository.GeefAlleAutosAsync();
    }

    public async Task<AutoItem> GeefAutoAsync(int id)
    {
        return await autoRepository.GeefAutoAsync(id);
    }
}