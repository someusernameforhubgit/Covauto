using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class RitController(AbstractService<RitListItem, RitItem, RitMaakItem, object> service)
    : AbstractController<RitListItem, RitItem, RitMaakItem, object>(service)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RitListItem>>> Get()
    {
        return await _get();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<RitItem>> Get(int id)
    {
        return await _get(id);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Post(RitMaakItem item)
    {
        return await _add(item);
    }
}