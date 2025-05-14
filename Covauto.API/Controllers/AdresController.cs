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
        public IActionResult Create([FromBody] AdresListItem request)
        {
            try
            {
                adresRepository.VoegToe(request);
                return StatusCode(StatusCodes.Status201Created);
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
