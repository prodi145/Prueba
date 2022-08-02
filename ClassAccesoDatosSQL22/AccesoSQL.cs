using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Data;

namespace ClassAccesoDatosSQL22
{
    public class AccesoSQL
    {
        private string CadenaConexion { get; set; }



        public AccesoSQL(string cadena)
        {
            CadenaConexion = cadena;
        }


        public SqlConnection AbrirConexion(ref string mensaje)
        {
            SqlConnection conexion = new SqlConnection(); //clase que va a permitir la creacion de la conexion
            conexion.ConnectionString = CadenaConexion;
            //ruta para llegar a la conexion de base de datos
            try
            {
                conexion.Open();
                mensaje = "conexion esta abierta";
                //si abre la conexion, y si conecta manda mensaje de conexion
            }
            catch (Exception h)
            {
                mensaje = "ERROR:" + h.Message;
                //en caso contrario, manda mensaje del error
                conexion = null;
            }
            return conexion;
        }

        public Boolean ModificarBD(string sentSql, SqlConnection cnAb, ref string mensaje)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                mensaje = "conexion abierta";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = sentSql;
                    carrito.Connection = cnAb;
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "modificacion correcta";
                        salida = true;
                    }
                    catch (Exception s)
                    {
                        mensaje = "error:" + s.Message;
                        salida = false;
                    }
                }
                cnAb.Close();
                cnAb.Dispose();
            }
            else
            {
                mensaje = "no hay conexion abierta";
                salida = false;
            }
            return salida;
        }

        public Boolean ModificarBDMasSeguro(string sentSql, SqlConnection cnAb, ref string mensaje, SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand carrito = null;
            if (cnAb != null)
            {
                mensaje = "conexion abierta";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = sentSql;
                    carrito.Connection = cnAb;
                    //se asignan los parametros al sql command
                    foreach (SqlParameter x in parametros)
                    {
                        carrito.Parameters.Add(x);
                        try
                        {
                            carrito.ExecuteNonQuery();
                            mensaje = "modificacion correcta";
                            salida = true;
                        }
                        catch (Exception s)
                        {
                            mensaje = "error:" + s.Message;
                            salida = false;
                        }
                    }
                    cnAb.Close();
                    cnAb.Dispose();
                }
            }
            else
            {
                mensaje = "no hay conexion abierta";
                salida = false;
            }
            return salida;
        }



        public SqlDataReader ConsultaDR(string querySql, SqlConnection cnAb, ref string mensaje)
        {
            SqlCommand vocho = null;
            SqlDataReader caja;
            if (cnAb == null)
            {
                caja = null;
                mensaje = "No hay conexión abierta";

            }
            else
            {
                using (vocho = new SqlCommand(querySql, cnAb))
                {
                    try
                    {
                        caja = vocho.ExecuteReader();
                        mensaje = "consulta correcta";
                    }
                    catch (Exception s)
                    {
                        mensaje = "ERROR: " + s.Message;
                        caja = null;
                    }
                }
            }
            return caja;
        }


        public DataSet ConsultaDataSet(string querySql, SqlConnection cnAb, ref string mensaje)
        {
            SqlCommand vocho = null;
            DataSet cajaGrande = null;
            SqlDataAdapter trailer = null;
            if (cnAb == null)
            {
                cajaGrande = null;
                mensaje = "No hay conexión abierta";

            }
            else
            {
                using (vocho = new SqlCommand(querySql, cnAb))
                {
                    using (trailer = new SqlDataAdapter())
                    {
                        cajaGrande = new DataSet();
                        trailer.SelectCommand = vocho;
                        try
                        {
                            trailer.Fill(cajaGrande);
                            mensaje = "consulta correcta";
                        }
                        catch (Exception s)
                        {
                            mensaje = "ERROR: " + s.Message;
                            cajaGrande = null;
                        }
                    }

                }
                cnAb.Close();
                cnAb.Dispose();
            }
            return cajaGrande;
        }

    }
}
