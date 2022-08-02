using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ClassBLInventario;
using ClassCapaEntidad;
using System.Configuration;

namespace WebApplication1
{
    public partial class actualizacion : System.Web.UI.Page
    {
        CapaNegocioActualizacion nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioActualizacion(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioActualizacion)Session["Nueva"];


            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.ObtenTodComputadorFinal(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";

            EntidadActualizacion actualiza = null;
            if (GridView1.SelectedIndex >= 0)
            {
                actualiza = new EntidadActualizacion()
                {

                    num_inv = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text,
                    num_serie = TextBox1.Text,
                    descripcion= TextBox2.Text,
                    fecha = Convert.ToDateTime(Calendar1.SelectedDate.ToShortTimeString()) 





                };

                nueva.InsertarActualizacion(actualiza, ref m);
                TextBox3.Text = m;

            }
            else
            {
                TextBox2.Text = "Selecciona un Inventario";

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (GridView2.SelectedIndex >= 0)
            {


                TextBox4.Text= GridView2.Rows[GridView2.SelectedIndex].Cells[2].Text;
                TextBox1.Text= GridView2.Rows[GridView2.SelectedIndex].Cells[3].Text;
                TextBox2.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[4].Text;
                Calendar1.SelectedDate = Convert.ToDateTime(GridView2.Rows[GridView2.SelectedIndex].Cells[5].Text);

                
               
                string m = "";
                Session["Tabla1"] = nueva.ObtenTodComputadorFinal(ref m);
                GridView1.DataSource = Session["Tabla1"];
                TextBox3.Text = m;
                GridView1.DataBind();

                

            }
            else
            {
                TextBox3.Text = "Selecciona una computadora final";

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.ObtenTodasActualizaciones(ref m);
            GridView2.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";

            EntidadActualizacion actualiza = null;
            if (GridView2.SelectedIndex >= 0)
            {
                if (GridView1.SelectedIndex >= 0)
                {
                    actualiza = new EntidadActualizacion()
                    {
                        id_act = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),
                        num_inv = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text,
                        num_serie = TextBox1.Text,
                        descripcion = TextBox2.Text,
                        fecha = Convert.ToDateTime(Calendar1.SelectedDate.ToShortTimeString())





                    };

                    nueva.ModificarActualizacion(actualiza, ref m);
                    TextBox3.Text = m;

                }
                else
                {
                    EntidadActualizacion actualizav2 = null;
                    actualizav2 = new EntidadActualizacion()
                    {
                        id_act = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),
                        num_inv = TextBox4.Text,
                        num_serie = TextBox1.Text,
                        descripcion = TextBox2.Text,
                        fecha = Convert.ToDateTime(Calendar1.SelectedDate.ToShortTimeString())





                    };

                    nueva.ModificarActualizacion(actualizav2, ref m);
                    TextBox3.Text = m;
                }
            }
            else
            {
                TextBox3.Text = "Selecciona una actuzalizacion";
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadActualizacion elimina = null;
            if (GridView2.SelectedIndex >= 0)
            {
                elimina = new EntidadActualizacion()
                {
                    id_act =Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarActualizacion(elimina, ref m);
                TextBox3.Text = m;

            }
            else
            {
                TextBox3.Text = "Selecciona una actualizacion";

            }
        }
    }
}