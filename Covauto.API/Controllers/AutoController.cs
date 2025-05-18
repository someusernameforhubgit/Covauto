using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class AutoController(AbstractService<AutoListItem, AutoItem, object, object> service)
    : AbstractController<AutoListItem, AutoItem, object, object>(service)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutoListItem>>> Get()
    {
        return await _get();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AutoItem>> Get(int id)
    {
        return await _get(id);
    }
}