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

        public HistorialController(IHistorialRepository historialRepository)
        {
            _historialRepository = historialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistorial()
        {
            return Ok(await _historialRepository.GetHistorial());
        }

        [HttpGet("{Cedula}")]
        public async Task<IActionResult> GetHistorial(string Cedula)
        {
            return Ok(await _historialRepository.GetHistorial(Cedula));
        }
    }
}
