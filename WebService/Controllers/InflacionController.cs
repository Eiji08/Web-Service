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

        public InflacionController(IInflacionRepository inflacionRepository)
        {
            _inflacionRepository = inflacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInflacion()
        {
            return Ok(await _inflacionRepository.GetInflacion());
        }

        [HttpGet("{fecha}")]
        public async Task<IActionResult> GetInflacion(string fecha)
        {
            return Ok(await _inflacionRepository.GetInflacion(fecha));
        }
    }
}
