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
    public class CapaNegocioComputFinal
    {
        private AccesoSQL operacion = null;

        public CapaNegocioComputFinal(string cadConx)
        {
            operacion = new AccesoSQL(cadConx);
        }

        public Boolean InsertarComputadoFinal(EntidadComputadoraFinal nuevo, ref string m)
        {
            string sentencia = "insert into computadorafinal(num_inv, num_scpu, id_cpug, num_steclado, id_tecladog, num_smonitor, " +
                "id_mong, num_smouse, id_mousg, estado,img1,img2,img3) values (@nuIn, @nuScp, @id_cpg, @nuTecl, @idTecld, @nuMon," +
                "@idMo1, @nuMous, @idMo, @esto,@im1,@im2,@im3);";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nuIn",SqlDbType.VarChar,10),
                new SqlParameter("nuScp",SqlDbType.VarChar,11),
                new SqlParameter("id_cpg",SqlDbType.Int),
                new SqlParameter("nuTecl",SqlDbType.VarChar,11),
                new SqlParameter("idTecld",SqlDbType.Int),
                new SqlParameter("nuMon",SqlDbType.VarChar,11),
                new SqlParameter("idMo1", SqlDbType.Int),
                new SqlParameter("nuMous", SqlDbType.VarChar, 11),
                new SqlParameter("idMo",SqlDbType.Int),
                new SqlParameter("esto",SqlDbType.VarChar,64),
                new SqlParameter("im1",SqlDbType.VarChar,255),
                new SqlParameter("im2",SqlDbType.VarChar,255),
                new SqlParameter("im3",SqlDbType.VarChar,255)
            };

            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.num_scpu;
            coleccion[2].Value = nuevo.id_cpug;
            coleccion[3].Value = nuevo.num_steclado;
            coleccion[4].Value = nuevo.id_tecladog;
            coleccion[5].Value = nuevo.num_smonitor;
            coleccion[6].Value = nuevo.id_mong;
            coleccion[7].Value = nuevo.num_smouse;
            coleccion[8].Value = nuevo.id_mousg;
            coleccion[9].Value = nuevo.estado;
            coleccion[10].Value = nuevo.img1;
            coleccion[11].Value = nuevo.img2;
            coleccion[12].Value = nuevo.img3;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public Boolean ModificarComputadorFinal(EntidadComputadoraFinal nuevo, ref string m)
        {
            string sentencia = "UPDATE computadorafinal set num_inv =@nuIn, num_scpu = @nuScp, id_cpug = @id_cpg, num_steclado = @nuTecl," +
                "id_tecladog = @idTecld, num_smonitor = @nuMon, id_mong  =  @idMo, num_smouse = @nMous, id_mousg = @idMou, estado = @est, img1=@im1, img2=@im2,img3=@im3" +
                "  WHERE num_inv =@nuIn";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nuIn",SqlDbType.VarChar,10),
                new SqlParameter("nuScp",SqlDbType.VarChar,11),
                new SqlParameter("id_cpg",SqlDbType.Int),
                new SqlParameter("nuTecl",SqlDbType.VarChar,11),
                new SqlParameter("idTecld",SqlDbType.Int),
                new SqlParameter("nuMon",SqlDbType.VarChar,11),
                new SqlParameter("idMo", SqlDbType.Int),
                new SqlParameter("nMous", SqlDbType.VarChar, 11),
                new SqlParameter("idMou",SqlDbType.Int),
                new SqlParameter("est",SqlDbType.VarChar,64),
                new SqlParameter("im1",SqlDbType.VarChar,255),
                new SqlParameter("im2",SqlDbType.VarChar,255),
                new SqlParameter("im3",SqlDbType.VarChar,255)
            };
            coleccion[0].Value = nuevo.num_inv;
            coleccion[1].Value = nuevo.num_scpu;
            coleccion[2].Value = nuevo.id_cpug;
            coleccion[3].Value = nuevo.num_steclado;
            coleccion[4].Value = nuevo.id_tecladog;
            coleccion[5].Value = nuevo.num_smonitor;
            coleccion[6].Value = nuevo.id_mong;
            coleccion[7].Value = nuevo.num_smouse;
            coleccion[8].Value = nuevo.id_mousg;
            coleccion[9].Value = nuevo.estado;
            coleccion[10].Value = nuevo.img1;
            coleccion[11].Value = nuevo.img2;
            coleccion[12].Value = nuevo.img3;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public List<EntidadComputadoraFinal> DevuelveInfoComputadorFinal(ref string mensaje)
        {
            List<EntidadComputadoraFinal> lista = new List<EntidadComputadoraFinal>();
            SqlDataReader atrapa = null;
            SqlConnection cn = null;
            cn = operacion.AbrirConexion(ref mensaje);
            string consulta = "select * from computadorafinal";
            atrapa = operacion.ConsultaDR(consulta, cn, ref mensaje);
            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    lista.Add(new EntidadComputadoraFinal()
                    {

                        num_inv = atrapa[0].ToString(),
                        num_scpu = atrapa[1].ToString(),
                        id_cpug = Convert.ToInt16(atrapa[2]),
                        num_steclado = atrapa[3].ToString(),
                        id_tecladog = Convert.ToInt16(atrapa[4]),
                        num_smonitor = atrapa[5].ToString(),
                        id_mong = Convert.ToInt16(atrapa[6]),
                        num_smouse = atrapa[7].ToString(),
                        id_mousg = Convert.ToInt16(atrapa[8]),
                        estado = atrapa[9].ToString()

                    }
                    ); 

                }
            }
            cn.Close();
            cn.Dispose();
            return lista;
        }

        public Boolean EliminarComputadorFinal(EntidadComputadoraFinal nuevo, ref string m)
        {
            string sentencia = "DELETE FROM computadorafinal WHERE num_inv = @nuIn";
            SqlParameter[] coleccion = new SqlParameter[]
            {
                new SqlParameter("nuIn",SqlDbType.VarChar,255)
            };
            coleccion[0].Value = nuevo.num_inv;
            Boolean salida = false;
            salida = operacion.ModificarBDMasSeguro(sentencia, operacion.AbrirConexion(ref m), ref m, coleccion);
            return salida;
        }

        public DataTable ObtenTodComputadorFinal(ref string mensaje)
        {
            string consulta = "Select * from computadorafinal";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable ObtenTodCPUGenerico(ref string mensaje)
        {
            string consulta = "Select * from CPU_Generico";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
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

        public DataTable ObtenTodMonitor(ref string mensaje)
        {
            string consulta = "select * from monitor";
            DataSet obtener = null;
            DataTable salida = null;
            obtener = operacion.ConsultaDataSet(consulta, operacion.AbrirConexion(ref mensaje), ref mensaje);
            if (obtener != null)
            {
                salida = obtener.Tables[0];
            }
            return salida;
        }

        public DataTable ObtenTodMouse(ref string mensaje)
        {
            string consulta = "Select * from mouse";
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
