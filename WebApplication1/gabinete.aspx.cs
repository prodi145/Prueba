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
    public partial class gabinete : System.Web.UI.Page
    {
        //CapaNegocioMarca objMarc = null;
        CapaNegocioGabinete objGabi = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para gabinete
                objGabi = new CapaNegocioGabinete(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objGabi"] = objGabi;
                //para modelo de marrca
                //objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                //Session["objMarc"] = objMarc;


            }
            else
            {
                //para tipo gabinete
                objGabi = (CapaNegocioGabinete)Session["objGabi"];
                //´para marca
                //objMarc = (CapaNegocioMarca)Session["objMarc"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadGabinete nuevo = new EntidadGabinete()
            {
                Modelo = TextBox1.Text,
                TipoForma = TextBox2.Text,
                F_Marca = Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objGabi.InsertarGabinete(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objGabi.ObtenTodasMarcasParaGabinete(ref m);
            GridView3.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView3.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objGabi.ObtenTodasGabinete(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    List<EntidadGabinete> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objGabi.DevuelveInfoGabinete(ref m);
        //    DropDownList2.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList2.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].Modelo + " "
        //                ));
        //    }
        //    TextBox3.Text = m;
        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    
        //}

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = objGabi.ObtenTodasMarcasParaGabinete(ref m);
            GridView4.DataSource = Session["Tabla3"];
            TextBox3.Text = m;
            GridView4.DataBind();
        }

        

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadGabinete nuevo = new EntidadGabinete()
            {
                id_Gabinete = Convert.ToInt16(TextBox6.Text),
                Modelo = TextBox4.Text,
                TipoForma = TextBox5.Text,
                F_Marca = Convert.ToInt16(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objGabi.ModificarGabinete(nuevo, ref cad);
            TextBox3.Text = cad;
            TextBox6.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadGabinete nuevo = new EntidadGabinete()
            {
                id_Gabinete = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text)
            };
            string cad = "";
            objGabi.EliminarGabinete(nuevo, ref cad);
            TextBox3.Text = cad;

            string m = "";
            Session["Tabla1"] = objGabi.ObtenTodasGabinete(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox6.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox4.Text = GridView2.Rows[rowind2].Cells[3].Text;
            TextBox5.Text = GridView2.Rows[rowind2].Cells[4].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}