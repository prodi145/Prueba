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
    public partial class discoduro : System.Web.UI.Page
    {
        CapaNegocioDiscoDuro objDiscoD = null;
        //CapaNegocioMarca objMarc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                objDiscoD = new CapaNegocioDiscoDuro(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objDiscoD"] = objDiscoD;
                //para modelo de marrca
                //objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                //Session["objMarc"] = objMarc;


            }
            else
            {
                //para tipo disco
                objDiscoD = (CapaNegocioDiscoDuro)Session["objDiscoD"];
                //´para marca
                //objMarc = (CapaNegocioMarca)Session["objMarc"];
                
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = objDiscoD.ObtenTodasMarcasParaDiscoDuro(ref m);
            GridView3.DataSource = Session["Tabla3"];
            TextBox5.Text = m;
            GridView3.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadDiscoDuro nuevo = new EntidadDiscoDuro()
            {
                TipoDisco = TextBox1.Text,
                conector = TextBox2.Text,
                Capacidad = TextBox3.Text,
                F_MarcaDisco = Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),
                Extra = TextBox4.Text
            };
            string cad = "";
            objDiscoD.InsertarDiscoDuro(nuevo, ref cad);
            TextBox5.Text = cad;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objDiscoD.ObtenTodDiscoDuro(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView2.DataBind();
        }

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    List<EntidadDiscoDuro> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objDiscoD.DevuelveInfoDiscoDuro(ref m);
        //    DropDownList2.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList2.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].TipoDisco + " "
        //                ));
        //    }
        //    TextBox5.Text = m;
        //}

       

        protected void Button7_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objDiscoD.ObtenTodasMarcasParaDiscoDuro(ref m);
            GridView4.DataSource = Session["Tabla2"];
            TextBox5.Text = m;
            GridView4.DataBind();
        }

        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadDiscoDuro nuevo = new EntidadDiscoDuro()
            {
                id_Disco = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text)
            };
            string cad = "";
            objDiscoD.EliminarDiscoDuro(nuevo, ref cad);
            TextBox5.Text = cad;

            string m = "";
            Session["Tabla1"] = objDiscoD.ObtenTodDiscoDuro(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView2.DataBind();
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox6.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox7.Text = GridView2.Rows[rowind2].Cells[3].Text;
            TextBox8.Text = GridView2.Rows[rowind2].Cells[4].Text;
            TextBox9.Text = GridView2.Rows[rowind2].Cells[5].Text;
            TextBox10.Text = GridView2.Rows[rowind2].Cells[7].Text;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            EntidadDiscoDuro nuevo = new EntidadDiscoDuro()
            {
                id_Disco = Convert.ToInt16(TextBox6.Text),
                TipoDisco = TextBox7.Text,
                conector = TextBox8.Text,
                Capacidad = TextBox9.Text,
                F_MarcaDisco = Convert.ToInt16(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),
                Extra = TextBox10.Text
            };
            string cad = "";
            objDiscoD.ModificarDiscoDuro(nuevo, ref cad);
            TextBox5.Text = cad;
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}