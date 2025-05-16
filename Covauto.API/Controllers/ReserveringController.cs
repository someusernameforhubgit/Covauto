using Covauto.Application.Interfaces;
using Covauto.Application.Services;
using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveringController(AbstractService<ReserveringListItem, ReserveringItem> service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReserveringListItem>>> Get()
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
        public async Task<ActionResult<ReserveringItem>> Get(int id)
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
