using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class GebruikerController(AbstractService<GebruikerListItem, GebruikerItem> service)
    : AbstractController<GebruikerListItem, GebruikerItem>(service)
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GebruikerListItem>>> Get()
    {
        return await _get();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GebruikerItem>> Get(int id)
    {
        return await _get(id);
    }
}
