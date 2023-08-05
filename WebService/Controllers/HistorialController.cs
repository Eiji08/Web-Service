using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceData1.Repositorio;
using WebServiceModel;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {

        private readonly IHistorialRepository _historialRepository;

        private readonly IUsoRepository _usoRepository;

        public HistorialController(IHistorialRepository historialRepository, IUsoRepository usoRepository)
        {
            _historialRepository = historialRepository;

            _usoRepository = usoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistorial()
        {
            await _usoRepository.GuardarUso("HistorialCrediticio");

            return Ok(await _historialRepository.GetHistorial());
        }

        [HttpGet("{Cedula}")]
        public async Task<IActionResult> GetHistorial(string Cedula)
        {
            await _usoRepository.GuardarUso("HistorialCrediticio");

            return Ok(await _historialRepository.GetHistorial(Cedula));
        }
    }
}
