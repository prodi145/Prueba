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
    public class CapaNegocioLaboratorio
    {
        private AccesoSQL operacion = null;

        public CapaNegocioLaboratorio(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarLaboratorio(EntidadLaboratorio nuevo, ref string m)
        {
            string sentecia = "insert into laboratorio(nombre_laboratorio) values(@nomLab);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nomLab",SqlDbType.VarChar,64),
            };
            coleccion[0].Value = nuevo.nombre_laboratorio;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarLaboratorio(EntidadLaboratorio nuevo, ref string m)
        {
            string sentencia = "UPDATE laboratorio set nombre_laboratorio = @nomLab WHERE nombre_laboratorio = @nomLab";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nomLab",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.nombre_laboratorio;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarLaboratorio(EntidadLaboratorio nuevo, ref string m)
        {
            string sentencia = "DELETE FROM laboratorio WHERE nombre_laboratorio = @nomLab";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nomLab",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.nombre_laboratorio;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodLaboratorio(ref string mensaje)
        {
            string consulta = "Select * from laboratorio";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public List<EntidadLaboratorio> DevuelveInfoLaboratorio(ref string mensaje)
        {
            List<EntidadLaboratorio> lista = new List<EntidadLaboratorio>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from laboratorio";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadLaboratorio()
                    {

                        nombre_laboratorio = atrapa[0].ToString()

                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }
    }
}
