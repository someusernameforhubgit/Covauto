using System.ComponentModel.DataAnnotations;
using Covauto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TListItem, TItem, TMakeItem, TUpdateItem>(AbstractService<TListItem, TItem, TMakeItem, TUpdateItem> service) : ControllerBase
    {
        private readonly AbstractService<TListItem, TItem, TMakeItem, TUpdateItem> Service = service;
        
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
        
        protected async Task<ActionResult<int>> _add(TMakeItem item)
        {
            try
            {
                return Ok(await Service.AddAsync(item));
            }
            catch (ValidationException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
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
        
        protected async Task<ActionResult> _update(int id, TUpdateItem item)
        {
            try
            {
                await service.UpdateAsync(id, item);
                return Ok();
            }
            catch (ValidationException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
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
            catch (KeyNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
