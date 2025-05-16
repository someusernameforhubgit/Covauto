using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController(AbstractService<AutoListItem, AutoItem> service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoListItem>>> Get()
        {
            try
            {
                return Ok(await service.GetAllAsync());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoItem>> Get(int id)
        {
            try
            {
                return Ok(await service.GetByIDAsync(id));
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
