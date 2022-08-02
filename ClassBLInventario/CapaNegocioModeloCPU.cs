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
    public class CapaNegocioModeloCPU
    {
        private AccesoSQL operacion = null;

        public CapaNegocioModeloCPU(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarModeloCPU(EntidadModeloCPU nuevo, ref string m)
        {
            string sentencia = "insert into ModeloCPU(modeloCPU, f_marca) values(@mod, @f_ma);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("mod",SqlDbType.VarChar,50),
                new SqlParameter("f_ma",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.modeloCPU;
            coleccion[1].Value = nuevo.f_marca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarModeloCPU(EntidadModeloCPU nuevo, ref string m)
        {
            string sentencia = "UPDATE ModeloCPU set modeloCPU = @mod, f_marca = @f_ma WHERE id_modcpu =@id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("mod",SqlDbType.VarChar,50),
                new SqlParameter("f_ma",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.id_modcpu;
            coleccion[1].Value = nuevo.modeloCPU;
            coleccion[2].Value = nuevo.f_marca;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadModeloCPU> DevuelveInfoModeloCPU(ref string mensaje)
        {
            List<EntidadModeloCPU> lista = new List<EntidadModeloCPU>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from ModeloCPU";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadModeloCPU()
                    {
                        modeloCPU = atrapa[1].ToString(),
                        f_marca = Convert.ToInt16(atrapa[2])
                    }
                    );
                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public List<EntidadModeloCPU> DevuelveIdModeloCPU(ref string mensaje)
        {
            List<EntidadModeloCPU> lista = new List<EntidadModeloCPU>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from ModeloCPU";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadModeloCPU()
                    {
                        id_modcpu = (int)atrapa[0],
                        modeloCPU = atrapa[1].ToString(),
                        f_marca = Convert.ToInt16(atrapa[2])

                    }
                    ); ;

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public DataTable ObtenTodModeloCPU(ref string mensaje)
        {
            string consulta = "Select * from ModeloCPU";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable DevuelveMarc(ref string mensaje)
        {
            string consulta = "select  Id_Marca,Marca from marcom, marca where Idcomponente = 6 and Idmarca = Id_Marca";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public Boolean EliminarModeloCPU(EntidadModeloCPU nuevo, ref string m)
        {
            string sentencia = "DELETE FROM ModeloCPU WHERE id_modcpu = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
            };
            coleccion[0].Value = nuevo.id_modcpu;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }
    }
}
