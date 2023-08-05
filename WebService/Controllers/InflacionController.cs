using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceData1.Repositorio;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InflacionController : ControllerBase
    {
        private readonly IInflacionRepository _inflacionRepository;

        private readonly IUsoRepository _usoRepository;

        public InflacionController(IInflacionRepository inflacionRepository, IUsoRepository usoRepository)
        {
            _inflacionRepository = inflacionRepository;

            _usoRepository = usoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInflacion()
        {
            await _usoRepository.GuardarUso("Inflacion");

            return Ok(await _inflacionRepository.GetInflacion());
        }

        [HttpGet("{fecha}")]
        public async Task<IActionResult> GetInflacion(string fecha)
        {
            await _usoRepository.GuardarUso("Inflacion");

            return Ok(await _inflacionRepository.GetInflacion(fecha));
        }
    }
}
