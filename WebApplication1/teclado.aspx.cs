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
    public partial class teclado : System.Web.UI.Page
    {
        CapaNegocioTeclado nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioTeclado(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioTeclado)Session["Nueva"];


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";

            EntidadTeclado actualiza = null;
            if (GridView2.SelectedIndex >= 0)
            {
                actualiza = new EntidadTeclado()
                {
                    f_marcat = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                    conector = TextBox1.Text





                };

                nueva.InsertarTeclado(actualiza, ref m);
                TextBox2.Text = m;

            }
            else
            {
                TextBox2.Text = "Selecciona una marca";

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.DevuelveMarc(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox2.Text = m;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {

                TextBox3.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;

                TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;




                string m = "";
                Session["Tabla1"] = nueva.DevuelveMarc(ref m);
                GridView2.DataSource = Session["Tabla1"];
                TextBox2.Text = m;
                GridView2.DataBind();


            }
            else
            {
                TextBox2.Text = "Selecciona un teclado";

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadTeclado actualiza = null;
            if (GridView1.SelectedIndex >= 0)
            {
                if (GridView2.SelectedIndex >= 0)
                {
                    actualiza = new EntidadTeclado()
                    {
                        id_teclado = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                        f_marcat = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                        conector = TextBox1.Text





                    };

                    nueva.ModificarTecladov2(actualiza, ref m);
                    TextBox2.Text = m;
                }
                else
                {
                    EntidadTeclado actualizav2 = null;


                    actualizav2 = new EntidadTeclado()
                    {
                        id_teclado = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                        f_marcat = Convert.ToInt32(TextBox3.Text),

                        conector = TextBox1.Text


                    };

                    nueva.ModificarTecladov2(actualizav2, ref m);
                    TextBox2.Text = m;
                }


            }
            else
            {


                TextBox2.Text = "Selecciona un teclado";



            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadTeclado elimina = null;
            if (GridView1.SelectedIndex >= 0)
            {
                elimina = new EntidadTeclado()
                {
                    id_teclado = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarTeclado(elimina, ref m);
                TextBox2.Text = m;

            }
            else
            {
                TextBox2.Text = "Seleccionar Mouse";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.ObtenTodTeclado(ref m);
            GridView1.DataSource = Session["Tabla2"];
            TextBox2.Text = m;
            GridView1.DataBind();
        }
    }
}