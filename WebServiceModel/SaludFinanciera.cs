using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceModel
{
    public class SaludFinanciera
    {
        public string Cedula { get; set; }

        public int RNC { get; set;}

        public string Indicador { get; set; }

        public string Comentario { get; set; }

        public double MontoTotalendeudado { get; set; }
    }
}
