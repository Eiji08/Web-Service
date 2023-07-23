using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public interface ITasaRepository
    {
        Task<IEnumerable<TasaCambio>> GetTasa();

        Task<TasaCambio> GetTasa(string Moneda);
    }
}
