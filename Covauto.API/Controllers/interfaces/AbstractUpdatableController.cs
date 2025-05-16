using Covauto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers.interfaces;

public abstract class AbstractUpdatableController<TListItem, TItem, TUpdatableItem>(AbstractUpdatableService<TListItem, TItem, TUpdatableItem> service) : AbstractController<TListItem, TItem>(service)
{
    protected async Task<ActionResult> _update(int id, TUpdatableItem item)
    {
        try
        {
            await service.UpdateAsync(id, item);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}