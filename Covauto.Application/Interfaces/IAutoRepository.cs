using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Interfaces;

public interface IAutoRepository
{
    public IEnumerable<AutoListItem> GeefAlleAutos();
    public AutoItem GeefAuto(int id);
}