using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Services;

public class RitService(IRitRepository ritRepository) : IRitService
{
    private readonly IRitRepository ritRepository = ritRepository;

    public async Task<IEnumerable<RitListItem>> GeefAlleRittenAsync()
    {
        return await ritRepository.GeefAlleRittenAsync();
    }

    public async Task<RitItem> GeefRitAsync(int id)
    {
        return await ritRepository.GeefRitAsync(id);
    }
}