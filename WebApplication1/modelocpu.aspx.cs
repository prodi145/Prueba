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
    public partial class modelocpu : System.Web.UI.Page
    {
        CapaNegocioModeloCPU nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioModeloCPU(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioModeloCPU)Session["Nueva"];


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //EntidadModeloCPU nuevo = new EntidadModeloCPU()
            //{
            //    modeloCPU = TextBox1.Text,
            //    f_marca = Convert.ToInt16(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text)


            //};
            //string cad = "";
            //nueva.InsertarModeloCPU(nuevo, ref cad);
            //TextBox2.Text = cad;
            //TextBox1.Text = "";
            string m = "";

            EntidadModeloCPU actualiza = null;
            if (GridView2.SelectedIndex >= 0)
            {
                actualiza = new EntidadModeloCPU()
                {
                    f_marca = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                    modeloCPU = TextBox1.Text
                    


                };

                nueva.InsertarModeloCPU(actualiza, ref m);
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.DevuelveIdModeloCPU(ref m);
            GridView1.DataSource = Session["Tabla2"];
            TextBox2.Text = m;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {

                TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
                TextBox3.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
                string m = "";
                Session["Tabla1"] = nueva.DevuelveMarc(ref m);
                GridView2.DataSource = Session["Tabla1"];
                TextBox2.Text = m;
                GridView2.DataBind();
                

            }
            else
            {
                TextBox2.Text = "Selecciona un modelo cpu";

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadModeloCPU elimina = null;
            if (GridView1.SelectedIndex >= 0)
            {
                elimina = new EntidadModeloCPU()
                {
                    id_modcpu = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarModeloCPU(elimina, ref m);
                TextBox2.Text = m;

            }
            else
            {
                TextBox2.Text = "Seleccionar Modelo Cpu";

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadModeloCPU actualiza = null;
            if (GridView1.SelectedIndex >= 0)
            {
                if(GridView2.SelectedIndex>=0)
                {
                    actualiza = new EntidadModeloCPU()
                    {
                        id_modcpu = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                        modeloCPU = TextBox1.Text,
                        f_marca = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text)


                    };

                    nueva.ModificarModeloCPU(actualiza, ref m);
                    TextBox2.Text = m;
                }
                else
                {
                    EntidadModeloCPU actualizav2 = null;


                    actualizav2 = new EntidadModeloCPU()
                    {
                        id_modcpu = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                        modeloCPU = TextBox1.Text,
                        f_marca = Convert.ToInt32(TextBox3.Text)


                    };

                    nueva.ModificarModeloCPU(actualizav2, ref m);
                    TextBox2.Text = m;
                }
                

            }
            else
            {


                TextBox2.Text = "Selecciona un modelo cpu";

                

            }
        }
    }
}