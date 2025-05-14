using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController(IAutoService autoService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AutoListItem>> Get()
        {
            try
            {
                return Ok(autoService.GeefAlleAutos());
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
                return Ok(autoService.GeefAuto(id));
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
