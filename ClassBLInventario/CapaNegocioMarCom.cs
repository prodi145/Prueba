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
    public class CapaNegocioMarCom
    {
        private AccesoSQL operacion = null;

        public CapaNegocioMarCom(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarMarcaComponente(EntidadMarCom nuevo, ref string m)
        {
            string sentencia = "insert into marcom(Idcomponente, Idmarca) values(@com, @mar);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("com",SqlDbType.Int),
                new SqlParameter("mar",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.Idcomponente;
            coleccion[1].Value = nuevo.Idmarca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarMarcaComponente(EntidadMarCom nuevo, ref string m)
        {
            string sentencia = "UPDATE marcom set Idcomponente = @com, Idmarca = @mar" +
                " WHERE id_marcom =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                 new SqlParameter("com",SqlDbType.Int),
                new SqlParameter("mar",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.id_marcom;
            coleccion[1].Value = nuevo.Idcomponente;
            coleccion[2].Value = nuevo.Idmarca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadMarCom> DevuelveInfoMarcaComponente(ref string mensaje)
        {
            List<EntidadMarCom> lista = new List<EntidadMarCom>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from marcom";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadMarCom()
                    {
                        id_marcom = Convert.ToInt16(atrapa[0]),
                        Idcomponente = Convert.ToInt16(atrapa[1]),
                        Idmarca = Convert.ToInt16(atrapa[2])
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodasMarcaComponente(ref string mensaje)
        {
            string consulta = "Select * from marcom";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarMarcaComponente(EntidadMarCom nuevo, ref string m)
        {
            string sentencia = "DELETE FROM marcom WHERE id_marcom = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_marcom;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodasMarcasIDMarc(ref string mensaje)
        {
            string consulta = "select Id_Marca, Marca from marca";
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
