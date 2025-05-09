using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Interfaces;

public interface IRitRepository
{
    public IEnumerable<RitListItem> GeefAlleRitten();
    public RitItem GeefRit(int id);
}