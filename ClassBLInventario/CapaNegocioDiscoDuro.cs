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
    public class CapaNegocioDiscoDuro
    {
        private AccesoSQL operacion = null;

        public CapaNegocioDiscoDuro(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarDiscoDuro(EntidadDiscoDuro nuevo, ref string m)
        {
            string sentencia = "insert into DiscoDuro(TipoDisco, conector, Capacidad, F_MarcaDisco, Extra) values ( @tip, @con, @cap, @f_MaDis, @ext);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("tip",SqlDbType.VarChar,20),
                new SqlParameter("con",SqlDbType.VarChar,10),
                new SqlParameter("cap",SqlDbType.VarChar,12),
                new SqlParameter("f_MaDis",SqlDbType.Int),
                new SqlParameter("ext",SqlDbType.VarChar,25)
            };

            coleccion[0].Value = nuevo.TipoDisco;
            coleccion[1].Value = nuevo.conector;
            coleccion[2].Value = nuevo.Capacidad;
            coleccion[3].Value = nuevo.F_MarcaDisco;
            coleccion[4].Value = nuevo.Extra;

            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarDiscoDuro(EntidadDiscoDuro nuevo, ref string m)
        {
            string sentencia = "UPDATE DiscoDuro set TipoDisco = @tip, conector = @con, Capacidad = @cap, F_MarcaDisco = @f_MaDis, Extra = @ext WHERE id_Disco =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("tip",SqlDbType.VarChar,20),
                new SqlParameter("con",SqlDbType.VarChar,10),
                new SqlParameter("cap",SqlDbType.VarChar,12),
                new SqlParameter("f_MaDis",SqlDbType.Int),
                new SqlParameter("ext",SqlDbType.VarChar,25)
            };
            coleccion[0].Value = nuevo.id_Disco;
            coleccion[1].Value = nuevo.TipoDisco;
            coleccion[2].Value = nuevo.conector;
            coleccion[3].Value = nuevo.Capacidad;
            coleccion[4].Value = nuevo.F_MarcaDisco;
            coleccion[5].Value = nuevo.Extra;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadDiscoDuro> DevuelveInfoDiscoDuro(ref string mensaje)
        {
            List<EntidadDiscoDuro> lista = new List<EntidadDiscoDuro>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from DiscoDuro";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadDiscoDuro()
                    {
                        TipoDisco = atrapa[1].ToString(),
                        conector = atrapa[2].ToString(),
                        Capacidad = atrapa[3].ToString(),
                        F_MarcaDisco = Convert.ToInt16(atrapa[4]),
                        Extra = atrapa[5].ToString() 
                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public List<EntidadDiscoDuro> DevuelveIdDiscoDuro(ref string mensaje)
        {
            List<EntidadDiscoDuro> lista = new List<EntidadDiscoDuro>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from DiscoDuro";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadDiscoDuro()
                    {
                        id_Disco = Convert.ToInt16(atrapa[0]),
                        TipoDisco = atrapa[1].ToString(),
                        conector = atrapa[2].ToString(),
                        Capacidad = atrapa[3].ToString(),
                        F_MarcaDisco = Convert.ToInt16(atrapa[4]),
                        Extra = atrapa[5].ToString()
                    }
                    );

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public Boolean EliminarDiscoDuro(EntidadDiscoDuro nuevo, ref string m)
        {
            string sentencia = "DELETE FROM DiscoDuro WHERE id_Disco =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_Disco;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodDiscoDuro(ref string mensaje)
        {
            string consulta = "Select * from DiscoDuro";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable ObtenTodDiscoDuroMostrar(ref string mensaje)
        {
            string consulta = "select id_Disco, TipoDisco, conector from DiscoDuro";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable ObtenTodasMarcasParaDiscoDuro(ref string mensaje)
        {
            string consulta = "select  Id_Marca,Marca from marcom, marca where Idcomponente = 4 and Idmarca = Id_Marca";
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
