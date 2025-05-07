using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController(IAutoRepository autoRepository) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AutoListItem>> Get()
        {
            try
            {
                return Ok(autoRepository.GeefAlleAutos());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<AutoItem> Get(int id)
        {
            try
            {
                return Ok(autoRepository.GeefAuto(id));
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
