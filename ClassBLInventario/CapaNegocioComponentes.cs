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
    public class CapaNegocioComponentes
    {
        private AccesoSQL operacion = null;

        public CapaNegocioComponentes(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarComponentes(EntidadComponentes nuevo, ref string m)
        {
            string sentencia = "insert into Componentes(categoria) values(@cate);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("cate",SqlDbType.VarChar,16)
            };

            coleccion[0].Value = nuevo.categoria;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarComponentes(EntidadComponentes nuevo, ref string m)
        {
            string sentencia = "DELETE FROM Componentes WHERE id_Componente = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_Componente;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadComponentes> DevuelveInfoComponentes(ref string mensaje)
        {
            List<EntidadComponentes> lista = new List<EntidadComponentes>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from Componentes";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadComponentes()
                    {
                        categoria = atrapa[1].ToString(),
                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public List<EntidadComponentes> DevuelveIdComponentes(ref string mensaje)
        {
            List<EntidadComponentes> lista = new List<EntidadComponentes>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from Componentes";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadComponentes()
                    {
                        id_Componente = Convert.ToInt16(atrapa[0]),
                        categoria = atrapa[1].ToString(),
                    }
                    );

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public Boolean ModificarComponentes(EntidadComponentes nuevo, ref string m)
        {
            string sentencia = "UPDATE Componentes set categoria = @cate WHERE id_Componente = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("cate",SqlDbType.VarChar,16)
            };
            coleccion[0].Value = nuevo.id_Componente;
            coleccion[1].Value = nuevo.categoria;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodComponentes(ref string mensaje)
        {
            string consulta = "Select * from Componentes";
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
