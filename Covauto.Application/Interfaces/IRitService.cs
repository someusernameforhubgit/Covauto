using Covauto.Shared.DTO.Rit;

namespace Covauto.Application.Interfaces;

public interface IRitService
{
    public IEnumerable<RitListItem> GeefAlleRitten();
    public RitItem GeefRit(int id);
}