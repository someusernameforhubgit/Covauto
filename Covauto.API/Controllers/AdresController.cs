using Covauto.API.Controllers.Interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Adres;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers;

public class AdresController(AbstractService<AdresListItem, AdresItem> service) : AbstractController<AdresListItem, AdresItem>(service)
{
    [HttpPost]
    public async Task<ActionResult<int>> Add(AdresItem item)
    {
        return await _add(item);
    }
}
