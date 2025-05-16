using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RitController(AbstractService<RitListItem, RitItem> ritService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RitListItem>>> Get()
        {
            try
            {
                return Ok(await ritService.GetAllAsync());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RitItem>> Get(int id)
        {
            try
            {
                return Ok(await ritService.GetByIDAsync(id));
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