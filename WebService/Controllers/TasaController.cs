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

        public TasaController(ITasaRepository tasaRepository)
        {
            _tasaRepository = tasaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasa()
        {
            return Ok(await _tasaRepository.GetTasa());
        }

        [HttpGet("{Moneda}")]
        public async Task<IActionResult> GetTasa(string Moneda)
        {
            return Ok(await _tasaRepository.GetTasa(Moneda));
        }
    }
}
