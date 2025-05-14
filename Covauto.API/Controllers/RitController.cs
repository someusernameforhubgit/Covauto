using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RitController(IRitService ritService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<RitListItem>> Get()
        {
            try
            {
                return Ok(ritService.GeefAlleRitten());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<RitItem> Get(int id)
        {
            try
            {
                return Ok(ritService.GeefRit(id));
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