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
	public partial class ubicacion : System.Web.UI.Page
	{
        //CapaNegocioComputFinal objComFin = null;
        CapaNegocioLaboratorio objLab = null;
        CapaNegocioUbicacion objUb = null;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                //para tipo cpu
                //objComFin = new CapaNegocioComputFinal(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                //Session["objComFin"] = objComFin;
                //para modelo de cpu
                objLab = new CapaNegocioLaboratorio(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objLab"] = objLab;
                //ubicacion
                objUb = new CapaNegocioUbicacion(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objUb"] = objUb;
            }
            else
            {
                ////para tipo cpu
                //objComFin = (CapaNegocioComputFinal)Session["objComFin"];
                //´para modelo de cpu
                objLab = (CapaNegocioLaboratorio)Session["objLab"];
                //ubicacion
                objUb = (CapaNegocioUbicacion)Session["objUb"];
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objUb.ObtenTodaComputadoraFinal(ref m);
            GridView3.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView3.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            List<EntidadLaboratorio> listaAtrapada = null;
            string m = "";
            listaAtrapada = objLab.DevuelveInfoLaboratorio(ref m);
            DropDownList2.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList2.Items.Add(
                    new ListItem(
                        listaAtrapada[a].nombre_laboratorio + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadUbicacion nuevo = new EntidadUbicacion()
            {
                num_inv = Convert.ToString(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),
                nombre_laboratorio = Convert.ToString(DropDownList2.SelectedValue),
            };
            string cad = "";
            objUb.InsertarUbicacion(nuevo, ref cad);
            TextBox3.Text = cad;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objUb.ObtenTodaUbicacion(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadUbicacion> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objUb.DevuelveInfUbicacion(ref m);
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

        //protected void Button10_Click(object sender, EventArgs e)
        //{
        //    List<EntidadUbicacion> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objUb.DevuelveInfUbicacion(ref m);
        //    DropDownList4.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList4.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].num_inv + " "


        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        protected void Button12_Click(object sender, EventArgs e)
        {
            List<EntidadLaboratorio> listaAtrapada = null;
            string m = "";
            listaAtrapada = objLab.DevuelveInfoLaboratorio(ref m);
            DropDownList5.Items.Clear();
            for (int a = 0; a < listaAtrapada.Count; a++)
            {
                DropDownList5.Items.Add(
                    new ListItem(
                        listaAtrapada[a].nombre_laboratorio + " "
                        ));
            }
            TextBox3.Text = m;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadUbicacion nuevo = new EntidadUbicacion()
            {
                num_inv = Convert.ToString(TextBox4.Text),
                nombre_laboratorio = Convert.ToString(DropDownList5.SelectedValue),
            };
            string cad = "";
            objUb.ModificarUbicacion(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox4.Text = "";
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadUbicacion nuevo = new EntidadUbicacion()
            {
                num_inv = GridView2.Rows[rowind].Cells[2].Text,
            };
            string cad = "";
            objUb.EliminarUbicacion(nuevo, ref cad);
            TextBox3.Text = cad;

            string m = "";
            Session["Tabla1"] = objUb.ObtenTodaUbicacion(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox4.Text = GridView2.Rows[rowind2].Cells[2].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}