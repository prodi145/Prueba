using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;
using ClassAccesoDatosSQL22;
using ClassCapaEntidad;

namespace ClassBLInventario
{
    public class CapaNegocioConsultas
    {
        private AccesoSQL operacion = null;

        public CapaNegocioConsultas(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        //consulta para Dando un número de inventario de un equipo que salga toda la información de
        //componentes de ese equipo(que mouse, teclado, monitor, memoria ram, procesador, e
        //incluso número de discos duros tiene ese equipo)
        public DataTable ObtenConsultaNumInventario(string num_inv, ref string m)
        {
            string consulta = "Select num_inv as NumInventario, num_scpu as NumeroCPU, id_mousg as Mouse, id_tecladog as Teclado, id_mong as Monitor,id_cpug as MemoriaRam, id_Disco as DiscoDuro from computadorafinal, RAM, DiscoDuro, mouse, teclado, monitor, CPU_Generico where id_mousg = id_mouse and id_tecladog = id_teclado and id_mong = id_monitor and f_tipoRam = id_RAM and id_cpug = id_CPU and " +
                "num_inv= '" + num_inv + "'; ";

            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref m), ref m);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        //Que equipos tiene un laboratorio determinado
        public DataTable ObtenEquiposConLaboratorio(ref string mensaje)
        {
            string consulta = "Select num_inv as Equipo, nombre_laboratorio as Laboratorio from ubicacion;";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        //Dando el número de inventario del equipo, que diga en que laboratorio se encuentra y
        //muestre los detalles de sus actualizaciones.
        public DataTable ObtenConsultaNumInventarioLaboratorioActualizaciones(string num_inv, ref string m)
        {
            string consulta = "select num_serie, descripcion, fecha, nombre_laboratorio as Laboratorio from ubicacion U, actualizacion A where U.num_inv = A.num_inv and U.num_inv= '" + num_inv + "'; ";

            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref m), ref m);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
    }
}
