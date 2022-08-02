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
    public class CapaNegocioMonitor
    {
        private AccesoSQL operacion = null;

        public CapaNegocioMonitor(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarMonitor(EntidadMonitor nuevo, ref string m)
        {
            string sentencia = "insert into monitor(f_marcam, conectores, tamano) values(@f_maM, @con, @tam);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("f_maM",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,64),
                new SqlParameter("tam",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.marcam;
            coleccion[1].Value = nuevo.conectores;
            coleccion[2].Value = nuevo.tamano;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarMonitor(EntidadMonitor nuevo, ref string m)
        {
            string sentencia = "UPDATE monitor set f_marcam = @f_maM, conectores = @con, tamano = @tam" +
                " WHERE id_monitor = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("f_maM",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,64),
                new SqlParameter("tam",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.id_monitor;
            coleccion[1].Value = nuevo.marcam;
            coleccion[2].Value = nuevo.conectores;
            coleccion[3].Value = nuevo.tamano;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadMonitor> DevuelveInfoMonitor(ref string mensaje)
        {
            List<EntidadMonitor> lista = new List<EntidadMonitor>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from monitor";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadMonitor()
                    {
                        marcam = Convert.ToInt16(atrapa[1]),
                        conectores = atrapa[2].ToString(),
                        tamano = atrapa[3].ToString()
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodMonitor(ref string mensaje)
        {
            string consulta = "select id_monitor,Id_Marca,Marca,conectores, tamano from monitor, Marca where f_marcam=Id_Marca";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarMonitor(EntidadMonitor nuevo, ref string m)
        {
            string sentencia = "DELETE FROM monitor WHERE id_monitor = @mon";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("mon",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_monitor;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable DevuelveMarc(ref string mensaje)
        {
            string consulta = "select  Id_Marca,Marca from marcom, marca where Idcomponente = 3 and Idmarca = Id_Marca";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }
    }
}
