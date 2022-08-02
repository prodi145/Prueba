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
    public partial class marcompo : System.Web.UI.Page
    {
        //CapaNegocioMarca objMarc = null;
        CapaNegocioComponentes objCompo = null;
        CapaNegocioMarCom objMarCo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para componente
                objCompo = new CapaNegocioComponentes(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objCompo"] = objCompo;
                //para modelo de marrca
                //objMarc = new CapaNegocioMarca(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                //Session["objMarc"] = objMarc;
                //para modelo de componente
                objMarCo = new CapaNegocioMarCom(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objMarCo"] = objMarCo;

            }
            else
            {
                //para componente
                objCompo = (CapaNegocioComponentes)Session["objCompo"];
                //´para marca
                //objMarc = (CapaNegocioMarca)Session["objMarc"];
                //´para componente
                objMarCo = (CapaNegocioMarCom)Session["objMarCo"];
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = objCompo.ObtenTodComponentes(ref m);
            GridView3.DataSource = Session["Tabla2"];
            TextBox5.Text = m;
            GridView3.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = objMarCo.ObtenTodasMarcasIDMarc(ref m);
            GridView4.DataSource = Session["Tabla3"];
            TextBox5.Text = m;
            GridView4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntidadMarCom nuevo = new EntidadMarCom()
            {
                Idcomponente = Convert.ToInt16(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),
                Idmarca = Convert.ToInt16(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objMarCo.InsertarMarcaComponente(nuevo, ref cad);
            TextBox5.Text = cad;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objMarCo.ObtenTodasMarcaComponente(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView2.DataBind();
        }

        //protected void Button7_Click(object sender, EventArgs e)
        //{
        //    List<EntidadMarCom> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objMarCo.DevuelveInfoMarcaComponente(ref m);
        //    DropDownList3.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList3.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].Idcomponente + " "
        //                ));
        //    }
        //    TextBox5.Text = m;
        //}

        

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            EntidadMarCom nuevo = new EntidadMarCom()
            {
                id_marcom = Convert.ToInt16(TextBox7.Text),
                Idcomponente = Convert.ToInt16(TextBox8.Text),
                Idmarca = Convert.ToInt16(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text)
            };
            string cad = "";
            objMarCo.ModificarMarcaComponente(nuevo, ref cad);
            TextBox5.Text = cad;
            TextBox7.Text = "";
            TextBox8.Text = "";
        }

        //protected void Button12_Click(object sender, EventArgs e)
        //{
        //    List<EntidadComponentes> listaAtrapada = null;
        //    string m = "";
        //    listaAtrapada = objCompo.DevuelveIdComponentes(ref m);
        //    DropDownList6.Items.Clear();
        //    for (int a = 0; a < listaAtrapada.Count; a++)
        //    {
        //        DropDownList6.Items.Add(
        //            new ListItem(
        //                listaAtrapada[a].id_Componente + " "
        //                ));
        //    }
        //    TextBox5.Text = m;
        //}

        protected void Button13_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla4"] = objMarCo.ObtenTodasMarcasIDMarc(ref m);
            GridView5.DataSource = Session["Tabla4"];
            TextBox5.Text = m;
            GridView5.DataBind();
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        //metodo para traer datos y poder eliminar
        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            EntidadMarCom nuevo = new EntidadMarCom()
            {
                id_marcom = Convert.ToInt16(GridView2.Rows[rowind].Cells[2].Text),
            };
            string cad = "";
            objMarCo.EliminarMarcaComponente(nuevo, ref cad);
            TextBox5.Text = cad;

            string m = "";
            Session["Tabla1"] = objMarCo.ObtenTodasMarcaComponente(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox5.Text = m;
            GridView2.DataBind();
        }

        //metodo para traer datos y poder modificar
        protected void chkk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind2 = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox7.Text = GridView2.Rows[rowind2].Cells[2].Text;
            TextBox8.Text = GridView2.Rows[rowind2].Cells[3].Text;
        }
    }
}