using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceModel
{
    public class HistorialCrediticio
    {
        public string Cedula { get; set; }

        public string RNCEmpresa { get; set; }

        public string ConceptoDeuda { get; set; }

        public DateTime Fecha { get; set; }

        public double MontoAdeudado { get; set; }
    }
}
