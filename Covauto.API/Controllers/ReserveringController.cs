using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class ReserveringController(AbstractService<ReserveringListItem, ReserveringItem> service)
    : AbstractController<ReserveringListItem, ReserveringItem>(service)
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
}
