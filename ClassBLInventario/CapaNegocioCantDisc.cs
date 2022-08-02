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
    public class CapaNegocioCantDisc
    {
        private AccesoSQL operacion = null;

        public CapaNegocioCantDisc(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarCantDisc(EntidadCantDisc nuevo, ref string m)
        {
            string sentencia = "insert into cantDisc(num_inv, id_Disco) values(@nu, @idDis);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nu",SqlDbType.VarChar,10),
                new SqlParameter("idDis",SqlDbType.Int)
            };

            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.id_Disco;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarCantDisc(EntidadCantDisc nuevo, ref string m)
        {
            string sentencia = "DELETE FROM cantDisc WHERE id_cant =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_cant;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadCantDisc> DevuelveInfoCantDisco(ref string mensaje)
        {
            List<EntidadCantDisc> lista = new List<EntidadCantDisc>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from cantDisc";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadCantDisc()
                    {
                        num_inv = atrapa[1].ToString(),
                        id_Disco =Convert.ToInt16(atrapa[2])
                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }
        
        public List<EntidadCantDisc> DevuelveInfoIdCantDisco(ref string mensaje)
        {
            List<EntidadCantDisc> lista = new List<EntidadCantDisc>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from cantDisc";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadCantDisc()
                    {
                        id_Disco = Convert.ToInt16(atrapa[0])
                    }
                    );

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }


        public Boolean ModificarCantDisco(EntidadCantDisc nuevo, ref string m)
        {
            string sentencia = "UPDATE cantDisc set num_inv = @nu, id_Disco = @idDis WHERE id_cant =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("nu",SqlDbType.VarChar,120),
                new SqlParameter("idDis",SqlDbType.VarChar,250)
            };
            coleccion[0].Value = nuevo.id_cant;
            coleccion[1].Value = nuevo.num_inv;
            coleccion[2].Value = nuevo.id_Disco;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodCantidadDisc(ref string mensaje)
        {
            string consulta = "Select * from cantDisc";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
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
