using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Interfaces;

public interface IAutoService
{
    public IEnumerable<AutoListItem> GeefAlleAutos();
    public AutoItem GeefAuto(int id);
}