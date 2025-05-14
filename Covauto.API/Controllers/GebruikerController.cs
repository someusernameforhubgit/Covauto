using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController(IGebruikerRepository gebruikerRepository) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<GebruikerListItem>> Get()
        {
            try
            {
                return Ok(gebruikerRepository.GeefAlleGebruikers());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public ActionResult<GebruikerItem> Get(int id)
        {
            try
            {
                return Ok(gebruikerRepository.GeefGebruiker(id));
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
