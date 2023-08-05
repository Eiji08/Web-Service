using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebServiceData1;
using WebServiceData1.Repositorio;
using WebServiceModel;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsoController : ControllerBase
    {
        private readonly IUsoRepository _usoRepository;

        private List<UsoServicio> _invocations = new List<UsoServicio>();

        public UsoController(IUsoRepository usoRepository)
        {
            _usoRepository = usoRepository;
            _invocations = new List<UsoServicio>();
        }

        [HttpGet("{NombreServicio}")]
        public async Task<IActionResult> GetUso(string NombreServicio)
        {
            return Ok(await _usoRepository.GetUso(NombreServicio));
        }

        [HttpGet("FechaConsultada")]
        public async Task<IActionResult> GetFecha(DateTime Desde, DateTime Hasta)
        {
            var registrosFiltrados = await _usoRepository.GetFecha(Desde, Hasta);
            return Ok(registrosFiltrados);
        }






        /*
        [HttpGet("FechaConsultada")]
        public ActionResult<IEnumerable<UsoServicio>> GetFecha(DateTime Desde, DateTime Hasta)
        {

            // Filtrar los registros de invocación por el nombre del servicio y el rango de fechas.
            var filteredInvocations = _invocations
                .Where(invocation => 
                                      invocation.FechaConsultada >= Desde &&
                                      invocation.FechaConsultada <= Hasta)
                .ToList();

            return Ok(filteredInvocations);
        }*/
    }
}
