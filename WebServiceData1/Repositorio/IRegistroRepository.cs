using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceModel;

namespace WebServiceData1.Repositorio
{
    public interface IRegistroRepository
    {
        Task<IEnumerable<RegistroConsultas>> GetRegistro();

        Task<RegistroConsultas> GetRegistro(string TablaConsultada);
    }
}
