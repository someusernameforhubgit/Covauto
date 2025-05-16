using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Adres;
using Microsoft.AspNetCore.Mvc;

namespace Covauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class AdresController(IAdresRepository adresRepository) : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] CreateAdres request)
        {
            try
            {
                var aangemaakteAuto = adresRepository.VoegToe(request);
                return Ok(aangemaakteAuto.ID);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
