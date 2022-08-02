using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidad
{
    public class EntidadTipoCPU
    {
        public int id_Tcup { get; set; }
        public string Tipo { get; set; }
        public string Familia { get; set; }
        public string Velocidad { get; set; }
        public string Extra { get; set; }
        public int id_modCPU { get; set; }
    }
}
