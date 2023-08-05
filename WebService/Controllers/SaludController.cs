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

        private readonly IUsoRepository _usoRepository;

        public SaludController(ISaludRepository saludRepository, IUsoRepository usoRepository)
        {
            _saludRepository = saludRepository;

            _usoRepository = usoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalud()
        {
            await _usoRepository.GuardarUso("SaludFinanciera");

            return Ok(await _saludRepository.GetSalud());
        }

        [HttpGet("{Cedula}")]
        public async Task<IActionResult> GetSalud(string Cedula)
        {
            await _usoRepository.GuardarUso("SaludFinanciera");

            return Ok(await _saludRepository.GetSalud(Cedula));
        }
    }
}
