using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceData1.Repositorio;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistro()
        {
            return Ok(await _registroRepository.GetRegistro());
        }

        [HttpGet("{TablaConsultada}")]
        public async Task<IActionResult> GetRegitro(string TablaConsultada)
        {
            return Ok(await _registroRepository.GetRegistro(TablaConsultada));
        }
    }
}
