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
	public partial class tiporam : System.Web.UI.Page
	{
        CapaNegocioTipoRAM objTipRAM = null;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {


                objTipRAM = new CapaNegocioTipoRAM(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objTipRAM"] = objTipRAM;

            }
            else
            {


                objTipRAM = (CapaNegocioTipoRAM)Session["objTipRAM"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadTipoRAM nuevo = new EntidadTipoRAM()
            {
                Tipo = TextBox1.Text,
                Extra = TextBox2.Text

            };
            string cad = "";
            objTipRAM.InsertarTipoRAM(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objTipRAM.ObtenTodoTipoRAM(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    List<EntidadTipoRAM> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objTipRAM.DevuelveInfTipoRAM(ref m);
        //    DropDownList2.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList2.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].Tipo + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadTipoRAM nuevo = new EntidadTipoRAM()
            {
                id_tipoRam = Convert.ToInt16(TextBox7.Text),
                Tipo = TextBox4.Text,
                Extra = TextBox5.Text

            };
            string cad = "";
            objTipRAM.ModificarTipoRAM(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox7.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadTipoRAM> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objTipRAM.DevuelveIdTipRAM(ref m);

        //    DropDownList3.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList3.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].id_tipoRam + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadTipoRAM nuevo = new EntidadTipoRAM()
            {
                id_tipoRam = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text)
            };
            string cad = "";
            objTipRAM.EliminarTipoRAM(nuevo, ref cad);
            TextBox3.Text = cad;

            string m = "";
            Session["Tabla1"] = objTipRAM.ObtenTodoTipoRAM(ref m);
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
    }
}