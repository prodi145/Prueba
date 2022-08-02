using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidad
{
    public class EntidadDiscoDuro
    {
        public int id_Disco { get; set; }
        public string TipoDisco { get; set; }
        public string conector { get; set; }
        public string Capacidad { get; set; }
        public int F_MarcaDisco { get; set; }
        public string Extra { get; set; }
    }
}
