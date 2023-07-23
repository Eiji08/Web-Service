using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceData1.Repositorio;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaludController : ControllerBase
    {

        private readonly ISaludRepository _saludRepository;

        public SaludController(ISaludRepository saludRepository)
        {
            _saludRepository = saludRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalud()
        {
            return Ok(await _saludRepository.GetSalud());
        }

        [HttpGet("{Cedula}")]
        public async Task<IActionResult> GetSalud(string Cedula)
        {
            return Ok(await _saludRepository.GetSalud(Cedula));
        }
    }
}
