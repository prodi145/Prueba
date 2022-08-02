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
    public class CapaNegocioUbicacion
    {
        private AccesoSQL operacion = null;

        public CapaNegocioUbicacion(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarUbicacion(EntidadUbicacion nuevo, ref string m)
        {
            string sentecia = "insert into ubicacion(num_inv, nombre_laboratorio) values(@numI, @nomLab);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("numI",SqlDbType.VarChar,10),
                new SqlParameter("nomLab",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.nombre_laboratorio;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarUbicacion(EntidadUbicacion nuevo, ref string m)
        {
            string sentencia = "UPDATE ubicacion set num_inv = @numI, nombre_laboratorio = @nomLab WHERE num_inv = @numI";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("numI",SqlDbType.VarChar,10),
                new SqlParameter("nomLab",SqlDbType.VarChar,64)
            };
            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.nombre_laboratorio;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarUbicacion(EntidadUbicacion nuevo, ref string m)
        {
            string sentencia = "DELETE FROM ubicacion WHERE num_inv = @numI";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("numI",SqlDbType.VarChar,10)
            };
            coleccion[0].Value = nuevo.num_inv;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodaUbicacion(ref string mensaje)
        {
            string consulta = "Select * from ubicacion";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public List<EntidadUbicacion> DevuelveInfUbicacion(ref string mensaje)
        {
            List<EntidadUbicacion> lista = new List<EntidadUbicacion>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from ubicacion";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadUbicacion()
                    {

                        num_inv = atrapa[0].ToString(),
                        nombre_laboratorio = atrapa[1].ToString(),

                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        //public List<EntidadComputadoraFinal> DevuelveInfoComputadorFinal(ref string mensaje)
        //{
        //    List<EntidadComputadoraFinal> lista = new List<EntidadComputadoraFinal>();
        //    SqlDataReader atrapa = null;
        //    SqlConnection cn = null;
        //    cn = operacion.AbrirConexion(ref mensaje);
        //    string consulta = "select * from computadorafinal";
        //    atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
        //    if (atrapa != null)
        //    {
        //        while (atrapa.Read())
        //        {
        //            lista.Add(new EntidadComputadoraFinal()
        //            {

        //                num_inv = atrapa[0].ToString(),
        //                num_scpu = atrapa[1].ToString(),
        //                id_cpug = Convert.ToInt16(atrapa[2]),
        //                num_steclado = atrapa[3].ToString(),
        //                id_tecladog = Convert.ToInt16(atrapa[4]),
        //                num_smonitor = atrapa[5].ToString(),
        //                id_mong = Convert.ToInt16(atrapa[6]),
        //                num_smouse = atrapa[7].ToString(),
        //                id_mousg = Convert.ToInt16(atrapa[8]),
        //                estado = atrapa[9].ToString()

        //            }
        //            );

        //        }
        //    }
        //    cn.Close();
        //    cn.Dispose();
        //    return lista;
        //}

        public DataTable ObtenTodaComputadoraFinal(ref string mensaje)
        {
            string consulta = "select num_inv from computadorafinal";
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
