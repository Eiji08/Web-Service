using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public interface IInflacionRepository
    {
        Task<IEnumerable<Inflacion>> GetInflacion();

        Task<Inflacion> GetInflacion(string Fecha);
    }
}
