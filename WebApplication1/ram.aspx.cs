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
	public partial class ram : System.Web.UI.Page
	{
        CapaNegocioRAM objRAM = null;
        CapaNegocioTipoRAM objTipRAM = null;


        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                // RAM
                objRAM = new CapaNegocioRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objRAM"] = objRAM;
                //TIPO DE  RAM
                objTipRAM = new CapaNegocioTipoRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objTipRAM"] = objTipRAM;
            }
            else
            {
                //RAM
                objRAM = (CapaNegocioRAM)Session["objRAM"];
                //TIPO DE RAM
                objTipRAM = (CapaNegocioTipoRAM)Session["objTipRAM"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadRAM nuevo = new EntidadRAM()
            {
                Capacidad = Convert.ToInt16(TextBox1.Text),
                Velocidad = TextBox2.Text,
                F_TipoR = Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objRAM.InsertarRAM(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objTipRAM.ObtenTodoTipoRAM(ref m);
            GridView3.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView3.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objRAM.ObtenTodaRAM(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    List<EntidadRAM> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objRAM.DevuelveInfoRAM(ref m);
        //    DropDownList2.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList2.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].Capacidad + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

        //protected void Button8_Click(object sender, EventArgs e)
        //{
        //    List<EntidadRAM> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objRAM.DevuelveIdRAM(ref m);
        //    DropDownList4.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList4.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].id_RAM + " "


        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button9_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = objTipRAM.ObtenTodoTipoRAM(ref m);
            GridView4.DataSource = Session["Tabla3"];
            TextBox3.Text = m;
            GridView4.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadRAM nuevo = new EntidadRAM()
            {
                id_RAM = Convert.ToInt16(TextBox7.Text),
                Capacidad = Convert.ToInt16(TextBox4.Text),
                Velocidad = TextBox5.Text,
                F_TipoR = Convert.ToInt16(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objRAM.ModificarRAM(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox7.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadRAM nuevo = new EntidadRAM()
            {
                id_RAM = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text)
            };
            string cad = "";
            objRAM.EliminarRAM(nuevo, ref cad);
            TextBox3.Text = cad;

            string m = "";
            Session["Tabla1"] = objRAM.ObtenTodaRAM(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox7.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox4.Text = GridView2.Rows[rowind2].Cells[3].Text;
            TextBox5.Text = GridView2.Rows[rowind2].Cells[4].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}