using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Services;

public class RitService(IRitRepository ritRepository) : IRitService
{
    private readonly IRitRepository ritRepository = ritRepository;

    public IEnumerable<RitListItem> GeefAlleRitten()
    {
        return ritRepository.GeefAlleRitten();
    }

    public RitItem GeefRit(int id)
    {
        return ritRepository.GeefRit(id);
    }
}