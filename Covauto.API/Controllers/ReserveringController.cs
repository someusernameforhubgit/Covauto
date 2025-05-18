using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class ReserveringController(AbstractService<ReserveringListItem, ReserveringItem, ReserveringMaakItem, object> service)
    : AbstractController<ReserveringListItem, ReserveringItem, ReserveringMaakItem, object>(service)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReserveringListItem>>> Get()
    {
        return await _get();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ReserveringItem>> Get(int id)
    {
        return await _get(id);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post(ReserveringMaakItem item)
    {
        return await _add(item);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return await _delete(id);
    }
}
