using Covauto.Application.Interfaces;
using Covauto.Application.Services;
using Covauto.Shared.DTO.Reservering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveringController(IReserveringService reserveringService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReserveringListItem>>> Get()
        {
            try
            {
                return Ok(await reserveringService.GeefAlleReserveringenAsync());
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
                return Ok(await reserveringService.GeefReserveringAsync(id));
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
