using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Gebruiker;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController(IGebruikerService gebruikerService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GebruikerListItem>>> Get()
        {
            try
            {
                return Ok(await gebruikerService.GeefAlleGebruikersAsync());
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GebruikerItem>> Get(int id)
        {
            try
            {
                return Ok(await gebruikerService.GeefGebruikerAsync(id));
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
