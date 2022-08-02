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
    public partial class monitor : System.Web.UI.Page
    {
        CapaNegocioMonitor nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioMonitor(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioMonitor)Session["Nueva"];


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";

            EntidadMonitor actualiza = null;
            if (GridView1.SelectedIndex >= 0)
            {
                actualiza = new EntidadMonitor()
                {
                    marcam = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                    conectores = TextBox1.Text,

                    tamano = TextBox2.Text



                };

                nueva.InsertarMonitor(actualiza, ref m);
                TextBox3.Text = m;

            }
            else
            {
                TextBox3.Text = "Selecciona una marca";

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.DevuelveMarc(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.ObtenTodMonitor(ref m);
            GridView2.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView2.SelectedIndex >= 0)
            {

                TextBox4.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[2].Text;
                
                TextBox1.Text = GridView2.Rows[GridView2.SelectedIndex].Cells[4].Text;
                TextBox2.Text= GridView2.Rows[GridView2.SelectedIndex].Cells[5].Text;
                


                string m = "";
                Session["Tabla1"] = nueva.DevuelveMarc(ref m);
                GridView1.DataSource = Session["Tabla1"];
                TextBox3.Text = m;
                GridView1.DataBind();


            }
            else
            {
                TextBox2.Text = "Selecciona un modelo cpu";

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadMonitor actualiza = null;
            if (GridView2.SelectedIndex >= 0)
            {
                if (GridView1.SelectedIndex >= 0)
                {
                    actualiza = new EntidadMonitor()
                    {
                        id_monitor = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                        marcam = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                        conectores = TextBox1.Text,
                        tamano= TextBox2.Text

                        


                    };

                    nueva.ModificarMonitor(actualiza, ref m);
                    TextBox3.Text = m;
                }
                else
                {
                    EntidadMonitor actualizav2 = null;


                    actualizav2 = new EntidadMonitor()
                    {
                        id_monitor = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                        marcam = Convert.ToInt32(TextBox4.Text),

                        conectores = TextBox1.Text,
                        tamano = TextBox2.Text


                    };

                    nueva.ModificarMonitor(actualizav2, ref m);
                    TextBox3.Text = m;
                }


            }
            else
            {


                TextBox3.Text = "Selecciona un monitor";



            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadMonitor elimina = null;
            if (GridView2.SelectedIndex >= 0)
            {
                elimina = new EntidadMonitor()
                {
                    id_monitor = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarMonitor(elimina, ref m);
                TextBox3.Text = m;

            }
            else
            {
                TextBox3.Text = "Seleccionar Modelo Cpu";

            }
        }
    }
}