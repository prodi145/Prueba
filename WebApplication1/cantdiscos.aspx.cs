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
	public partial class cantdiscos : System.Web.UI.Page
	{
        //CapaNegocioComputFinal objComFin = null;
        CapaNegocioDiscoDuro objDis = null;
        CapaNegocioCantDisc objCant = null;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                //para tipo cpu
                //objComFin = new CapaNegocioComputFinal(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                //Session["objComFin"] = objComFin;
                //para modelo disco duro
                objDis = new CapaNegocioDiscoDuro(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objDis"] = objDis;
                //para modelo cantidad dis
                objCant = new CapaNegocioCantDisc(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCant"] = objCant;
            }
            else
            {
                //para tipo cpu
                //objComFin = (CapaNegocioComputFinal)Session["objComFin"];
                //´para disco duro
                objDis = (CapaNegocioDiscoDuro)Session["objDis"];
                //´para cantidad dis
                objCant = (CapaNegocioCantDisc)Session["objCant"];
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla4"] = objCant.ObtenTodaComputadoraFinal(ref m);
            GridView5.DataSource = Session["Tabla4"];
            TextBox3.Text = m;
            GridView5.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objDis.ObtenTodDiscoDuroMostrar(ref m);
            GridView3.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadCantDisc nuevo = new EntidadCantDisc()
            {
                num_inv = Convert.ToString(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text),
                id_Disco = Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),
            };
            string cad = "";
            objCant.InsertarCantDisc(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objCant.ObtenTodCantidadDisc(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadCantDisc> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objCant.DevuelveInfoCantDisco(ref m);
        //    DropDownList3.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList3.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].num_inv + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

      

        protected void Button9_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = objDis.ObtenTodDiscoDuroMostrar(ref m);
            GridView4.DataSource = Session["Tabla3"];
            TextBox3.Text = m;
            GridView4.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadCantDisc nuevo = new EntidadCantDisc()
            {
                id_cant = Convert.ToInt16(TextBox5.Text),
                num_inv = Convert.ToString(TextBox6.Text),
                id_Disco = Convert.ToInt16(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),
            };
            string cad = "";
            objCant.ModificarCantDisco(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox5.Text = "";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadCantDisc nuevo = new EntidadCantDisc()
            {
                id_cant = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text),
            };
            string cad = "";
            objCant.EliminarCantDisc(nuevo, ref cad);
            TextBox3.Text = cad;

            string m = "";
            Session["Tabla1"] = objCant.ObtenTodCantidadDisc(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();

        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox5.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox6.Text = GridView2.Rows[rowind2].Cells[3].Text;
        }
    }
}