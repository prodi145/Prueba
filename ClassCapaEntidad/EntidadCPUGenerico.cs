using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidad
{
    public class EntidadCPUGenerico
    {
        public int id_CPU { get; set; }
        public int f_Tcpu { get; set; }
        public int f_MarcaCpu { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int f_tipoRam { get; set; }
        public int id_Gabinete { get; set; }
        public string img { get; set; }
    }
}
