using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Services;

public class AutoService(IAutoRepository autoRepository) : IAutoService
{
    public IEnumerable<AutoListItem> GeefAlleAutos()
    {
        return autoRepository.GeefAlleAutos();
    }

    public AutoItem GeefAuto(int id)
    {
        return autoRepository.GeefAuto(id);
    }
}