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
    public class CapaNegocioTeclado
    {
        private AccesoSQL operacion = null;

        public CapaNegocioTeclado(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarTeclado(EntidadTeclado nuevo, ref string m)
        {
            string sentencia = "insert into teclado(f_marcat, conector) values(@f_maT, @con);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("f_maT",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,5)
            };
            coleccion[0].Value = nuevo.f_marcat;
            coleccion[1].Value = nuevo.conector;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarTeclado(EntidadTeclado nuevo, ref string m)
        {
            string sentencia = "UPDATE teclado set f_marcat = @f_maT, conector = @con" +
                "WHERE id_teclado = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("f_maT",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,5)
            };
            coleccion[0].Value = nuevo.id_teclado;
            coleccion[1].Value = nuevo.f_marcat;
            coleccion[2].Value = nuevo.conector;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadTeclado> DevuelveInfoTeclado(ref string mensaje)
        {
            List<EntidadTeclado> lista = new List<EntidadTeclado>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from teclado";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadTeclado()
                    {
                        f_marcat = Convert.ToInt16(atrapa[1]),
                        conector = atrapa[2].ToString()
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodTeclado(ref string mensaje)
        {
            string consulta = "Select * from teclado";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarTeclado(EntidadTeclado nuevo, ref string m)
        {
            string sentencia = "DELETE FROM teclado WHERE id_teclado = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_teclado;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable DevuelveMarc(ref string mensaje)
        {
            string consulta = "select  Id_Marca,Marca from marcom, marca where Idcomponente = 2 and Idmarca = Id_Marca";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean ModificarTecladov2(EntidadTeclado nuevo, ref string m)
        {
            string sentencia = "UPDATE teclado set f_marcat = @f_maM, conector = @con" +
                " WHERE id_teclado = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("f_maM",SqlDbType.Int),
                new SqlParameter("con",SqlDbType.VarChar,64),

            };
            coleccion[0].Value = nuevo.id_teclado;
            coleccion[1].Value = nuevo.f_marcat;
            coleccion[2].Value = nuevo.conector;

            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
    }
}
