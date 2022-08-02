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
    public class CapaNegocioImagenCPU
    {
        private AccesoSQL operacion = null;

        public CapaNegocioImagenCPU(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarImagenCPU(EntidadImagenCPU nuevo, ref string m)
        {
            string sentencia = "insert into imagenCpu(urlimg) values(@img);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("img",SqlDbType.VarChar,255)
            };
            coleccion[0].Value = nuevo.urlimg;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarImagenCPU(EntidadImagenCPU nuevo, ref string m)
        {
            string sentencia = "UPDATE imagenCpu set urlimg = @img WHERE id_img =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                 new SqlParameter("img",SqlDbType.VarChar,50)
            };
            coleccion[0].Value = nuevo.id_img;
            coleccion[1].Value = nuevo.urlimg;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadImagenCPU> DevuelveInfoImagenCPU(ref string mensaje)
        {
            List<EntidadImagenCPU> lista = new List<EntidadImagenCPU>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from imagenCpu";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadImagenCPU()
                    {
                        urlimg = atrapa[1].ToString()
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodasImagenCPU(ref string mensaje)
        {
            string consulta = "Select * from imagenCpu";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarImagenCPU(EntidadImagenCPU nuevo, ref string m)
        {
            string sentencia = "DELETE FROM imagenCpu WHERE urlimg = @img";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("img",SqlDbType.VarChar,255)
            };
            coleccion[0].Value = nuevo.urlimg;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
    }
}
