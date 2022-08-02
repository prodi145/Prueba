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
    public class CapaNegocioRAM
    {
        private AccesoSQL operacion = null;

        public CapaNegocioRAM(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarRAM(EntidadRAM nuevo, ref string m)
        {
            string sentecia = "insert into RAM(Capacidad, Velocidad, F_TipoR) values(@ca, @vel, @f_tip);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("ca",SqlDbType.SmallInt),
                new SqlParameter("vel",SqlDbType.VarChar,15),
                new SqlParameter("f_tip",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.Capacidad;
            coleccion[1].Value = nuevo.Velocidad;
            coleccion[2].Value = nuevo.F_TipoR;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentecia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadRAM> DevuelveInfoRAM(ref string mensaje)
        {
            List<EntidadRAM> lista = new List<EntidadRAM>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from RAM";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadRAM()
                    {

                        Capacidad = Convert.ToInt16(atrapa[1]),
                        Velocidad = atrapa[2].ToString(),

                    }
                    );

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public List<EntidadRAM> DevuelveIdRAM(ref string mensaje)
        {
            List<EntidadRAM> lista = new List<EntidadRAM>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from RAM";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadRAM()
                    {
                        id_RAM = Convert.ToInt16(atrapa[0]),
                        Capacidad = Convert.ToInt16(atrapa[1]),
                        Velocidad = atrapa[2].ToString(),

                    }
                    );

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public Boolean ModificarRAM(EntidadRAM nuevo, ref string m)
        {
            string sentencia = "UPDATE RAM set Capacidad = @ca, Velocidad = @vel, F_TipoR = @f_tip WHERE Id_RAM = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.Int),
                new SqlParameter("ca",SqlDbType.SmallInt),
                new SqlParameter("vel",SqlDbType.VarChar,15),
                new SqlParameter("f_tip",SqlDbType.Int)
            };
            coleccion[0].Value = nuevo.id_RAM;
            coleccion[1].Value = nuevo.Capacidad;
            coleccion[2].Value = nuevo.Velocidad;
            coleccion[3].Value = nuevo.F_TipoR;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean EliminarRAM(EntidadRAM nuevo, ref string m)
        {
            string sentencia = "DELETE FROM RAM WHERE Id_RAM = @id";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("id",SqlDbType.SmallInt)
            };
            coleccion[0].Value = nuevo.id_RAM;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodaRAM(ref string mensaje)
        {
            string consulta = "Select * from RAM";
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
