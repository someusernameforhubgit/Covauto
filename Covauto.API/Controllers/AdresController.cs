using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Adres;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class AdresController(AbstractService<object, object, AdresMakeItem, object> service) : AbstractController<object, object, AdresMakeItem, object>(service)
{
    [HttpPost]
    public async Task<ActionResult<int>> Add(AdresMakeItem item)
    {
        return await _add(item);
    }
}
