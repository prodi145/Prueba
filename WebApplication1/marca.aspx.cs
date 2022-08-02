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
    public partial class Marca : System.Web.UI.Page
    {
        CapaNegocioMarca nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;
                


            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioMarca)Session["Nueva"];
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadMarca nuevo = new EntidadMarca()
            {
                Marca = TextBox1.Text,
               Extra = TextBox2.Text,
                
            };
            string cad = "";
            nueva.InsertarMarca(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.ObtenTodasMarcas(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //EntidadMarca nuevo = new EntidadMarca()
            //{
            //    Marca = DropDownList2.SelectedValue,
            //};
            //string cad = "";
            //nueva.EliminarMarca(nuevo, ref cad);
            //TextBox3.Text = cad;

            string m = "";
            EntidadMarca elimina = null;
            if (GridView1.SelectedIndex >= 0)
            {
                elimina = new EntidadMarca()
                {
                    Id_Marca = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarMarca(elimina, ref m);
                TextBox3.Text = m;
                
            }
            else
            {
                TextBox3.Text = "Selecciona un cliente";
                
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex >= 0)
            {

                TextBox1.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;
                TextBox2.Text = GridView1.Rows[GridView1.SelectedIndex].Cells[3].Text;
                
            }
            else
            {
                TextBox3.Text = "Selecciona un cliente";
                
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadMarca actualiza = null;
            if (GridView1.SelectedIndex >= 0)
            {
                actualiza = new EntidadMarca()
                {
                    Id_Marca = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                    Marca = TextBox1.Text,
                    Extra = TextBox2.Text
                   

                };

                nueva.ModificarMarca(actualiza, ref m);
                TextBox3.Text = m;
                
            }
            else
            {
                TextBox1.Text = "Selecciona un cliente";
                
            }
        }
    }
}