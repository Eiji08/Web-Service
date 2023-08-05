using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Sources;
using WebServiceData1.Repositorio;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasaController : ControllerBase
    {
        private readonly ITasaRepository _tasaRepository;

        private readonly IUsoRepository _usoRepository;

        public TasaController(ITasaRepository tasaRepository, IUsoRepository usoRepository)
        {
            _tasaRepository = tasaRepository;

            _usoRepository = usoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasa()
        {
            await _usoRepository.GuardarUso("TasaCambio");

            return Ok(await _tasaRepository.GetTasa());
        }

        [HttpGet("{Moneda}")]
        public async Task<IActionResult> GetTasa(string Moneda)
        {
            await _usoRepository.GuardarUso("TasaCambio");

            return Ok(await _tasaRepository.GetTasa(Moneda));
        }
    }
}
