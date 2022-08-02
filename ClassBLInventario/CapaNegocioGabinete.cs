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
    public class CapaNegocioGabinete
    {
        private AccesoSQL operacion = null;

        public CapaNegocioGabinete(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarGabinete(EntidadGabinete nuevo, ref string m)
        {
            string sentencia = "insert into Gabinete(Modelo, TipoForma, F_Marca) values(@mo, @tiF, @f_Ma);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("mo",SqlDbType.VarChar,10),
                new SqlParameter("tiF",SqlDbType.VarChar,30),
                new SqlParameter("f_Ma",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.Modelo;
            coleccion[1].Value = nuevo.TipoForma;
            coleccion[2].Value = nuevo.F_Marca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarGabinete(EntidadGabinete nuevo, ref string m)
        {
            string sentencia = "UPDATE Gabinete set Modelo = @mo, TipoForma = @tiF, F_Marca = @f_Ma WHERE id_Gabinete =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("mo",SqlDbType.VarChar,10),
                new SqlParameter("tiF",SqlDbType.VarChar,30),
                new SqlParameter("f_Ma",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.id_Gabinete;
            coleccion[1].Value = nuevo.Modelo;
            coleccion[2].Value = nuevo.TipoForma;
            coleccion[3].Value = nuevo.F_Marca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadGabinete> DevuelveInfoGabinete(ref string mensaje)
        {
            List<EntidadGabinete> lista = new List<EntidadGabinete>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from Gabinete";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadGabinete()
                    {
                        Modelo = atrapa[1].ToString(),
                        TipoForma = atrapa[2].ToString(),
                        F_Marca = Convert.ToInt16(atrapa[3])
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodasGabinete(ref string mensaje)
        {
            string consulta = "Select * from Gabinete";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarGabinete(EntidadGabinete nuevo, ref string m)
        {
            string sentencia = "DELETE FROM Gabinete WHERE id_Gabinete =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_Gabinete;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodasMarcasParaGabinete(ref string mensaje)
        {
            string consulta = "select  Id_Marca,Marca from marcom, marca where Idcomponente = 7 and Idmarca = Id_Marca";
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

