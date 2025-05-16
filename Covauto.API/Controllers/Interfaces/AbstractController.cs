using Covauto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TListItem, TItem>(AbstractService<TListItem, TItem> service) : ControllerBase
    {
        private readonly AbstractService<TListItem, TItem> Service = service;
        
        protected virtual async Task<ActionResult<IEnumerable<TListItem>>> _get()
        {
            try
            {
                return Ok(await Service.GetAllAsync());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        
        protected virtual async Task<ActionResult<TItem>> _get(int id)
        {
            try
            {
                return Ok(await Service.GetByIDAsync(id));
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        protected async Task<ActionResult<IEnumerable<TListItem>>> _search(string query)
        {
            try
            {
                return Ok(await Service.SearchAsync(query));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        protected async Task<ActionResult<int>> _add(TItem item)
        {
            try
            {
                return Ok(await Service.AddAsync(item));
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        protected async Task<ActionResult> _delete(int id)
        {
            try
            {
                await Service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
