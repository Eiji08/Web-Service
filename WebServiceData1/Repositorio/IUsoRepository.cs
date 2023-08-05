using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public interface IUsoRepository
    {
        Task<IEnumerable<UsoServicio>> GetUso();

        Task<IEnumerable<UsoServicio>> GetUso(string NombreServicio);

        Task GuardarUso(string nombreServicio);

        Task<IEnumerable<UsoServicio>> GetFecha(DateTime Desde, DateTime Hasta);
        
    }
}
