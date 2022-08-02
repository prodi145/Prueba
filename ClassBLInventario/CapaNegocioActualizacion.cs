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
    public class CapaNegocioActualizacion
    {
        private AccesoSQL operacion = null;

        public CapaNegocioActualizacion(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarActualizacion(EntidadActualizacion nuevo, ref string m)
        {
            string sentecia = "insert into actualizacion(num_inv, num_serie, descripcion, fecha) values(@nuI, @nuS, @des, @fec);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nuI",SqlDbType.VarChar,10),
                new SqlParameter("nuS",SqlDbType.VarChar,11),
                new SqlParameter("des",SqlDbType.VarChar,64),
                new SqlParameter("fec",SqlDbType.Date)
            };
            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.num_serie;
            coleccion[2].Value = nuevo.descripcion;
            coleccion[3].Value = nuevo.fecha;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarActualizacion(EntidadActualizacion nuevo, ref string m)
        {
            string sentencia = "UPDATE actualizacion set num_inv = @numI, num_serie = @numS, descripcion = @des, fecha = @fec  WHERE id_act =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("numI",SqlDbType.VarChar,10),
                new SqlParameter("numS",SqlDbType.VarChar,11),
                new SqlParameter("des",SqlDbType.VarChar,64),
                new SqlParameter("fec",SqlDbType.Date)
            };
            coleccion[0].Value = nuevo.id_act;
            coleccion[1].Value = nuevo.num_inv;
            coleccion[2].Value = nuevo.num_serie;
            coleccion[3].Value = nuevo.descripcion;
            coleccion[4].Value = nuevo.fecha;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadActualizacion> DevuelveInfoActualizacion(ref string mensaje)
        {
            List<EntidadActualizacion> lista = new List<EntidadActualizacion>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from actualizacion";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadActualizacion()
                    {

                        num_inv = atrapa[1].ToString(),
                        num_serie = atrapa[2].ToString(),
                        descripcion = atrapa[3].ToString(),
                        fecha = Convert.ToDateTime(atrapa[4])
                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public Boolean EliminarActualizacion(EntidadActualizacion nuevo, ref string m)
        {
            string sentencia = "DELETE FROM actualizacion WHERE id_act = @numI";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("numI",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_act;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodasActualizaciones(ref string mensaje)
        {
            string consulta = "Select * from actualizacion";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable ObtenTodComputadorFinal(ref string mensaje)
        {
            string consulta = "Select * from computadorafinal";
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
