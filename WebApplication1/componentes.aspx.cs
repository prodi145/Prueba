using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data.SqlClient;
using System.Data;
using ClassBLInventario;
using ClassCapaEntidad;
using System.Configuration;

namespace WebApplication1
{
    public partial class componentes : System.Web.UI.Page
    {
        CapaNegocioComponentes objCompo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para componentes
                objCompo = new CapaNegocioComponentes(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCompo"] = objCompo;
            }
            else
            {
                //para componentes
                objCompo = (CapaNegocioComponentes)Session["objCompo"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadComponentes nuevo = new EntidadComponentes()
            {
                categoria = TextBox1.Text
            };
            string cad = "";
            objCompo.InsertarComponentes(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objCompo.ObtenTodComponentes(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    List<EntidadComponentes> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objCompo.DevuelveInfoComponentes(ref m);
        //    DropDownList1.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList1.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].categoria + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            EntidadComponentes nuevo = new EntidadComponentes()
            {
                id_Componente = Convert.ToInt16(TextBox6.Text),
            };
            string cad = "";
            objCompo.EliminarComponentes(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox6.Text = "";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadComponentes nuevo = new EntidadComponentes()
            {
                id_Componente = Convert.ToInt16(TextBox5.Text),
                categoria = TextBox4.Text
            };
            string cad = "";
            objCompo.ModificarComponentes(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox5.Text = "";
            TextBox4.Text = "";
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox6.Text = GridView2.Rows[rowind].Cells[2].Text;
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox5.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox4.Text = GridView2.Rows[rowind2].Cells[3].Text;
        }
    }
}