using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Covauto.Shared.DTO.Rit;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RitController(IRitRepository ritRepository) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<RitListItem>> Get()
        {
            try
            {
                return Ok(ritRepository.GeefAlleRitten());
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
                return Ok(ritRepository.GeefRit(id));
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