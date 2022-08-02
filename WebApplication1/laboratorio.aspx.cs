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
	public partial class laboratorio : System.Web.UI.Page
	{
        CapaNegocioLaboratorio objBAct = null;

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

                
                objBAct = new CapaNegocioLaboratorio(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objAct"] = objBAct;

            }
            else
            {

                
                objBAct = (CapaNegocioLaboratorio)Session["objAct"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadLaboratorio nuevo = new EntidadLaboratorio()
            {
                nombre_laboratorio = TextBox1.Text

            };
            string cad = "";
            objBAct.InsertarLaboratorio(nuevo, ref cad);
            TextBox2.Text = cad;
            TextBox1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objBAct.ObtenTodLaboratorio(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox2.Text = m;
            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadLaboratorio nuevo = new EntidadLaboratorio()
            {
                nombre_laboratorio = GridView2.Rows[rowind].Cells[1].Text
            };
            string cad = "";
            objBAct.EliminarLaboratorio(nuevo, ref cad);
            TextBox2.Text = cad;

            string m = "";
            Session["Tabla1"] = objBAct.ObtenTodLaboratorio(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox2.Text = m;
            GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadLaboratorio> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objBAct.DevuelveInfoLaboratorio(ref m);
        //    DropDownList3.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList3.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].nombre_laboratorio + " "


        //                ));
        //    }
        //    TextBox2.Text = m;
        //}

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    EntidadLaboratorio nuevo = new EntidadLaboratorio()
        //    {

        //        nombre_laboratorio = TextBox3.Text

        //    };
        //    string cad = "";
        //    objBAct.ModificarLaboratorio(nuevo, ref cad);
        //    TextBox2.Text = cad;
        //    TextBox1.Text = "";
        //}
    }
}