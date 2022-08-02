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
    public partial class consultas : System.Web.UI.Page
    {
        CapaNegocioConsultas objConsulta = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para consultas
                objConsulta = new CapaNegocioConsultas(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["objConsulta"] = objConsulta;
            }
            else
            {
                //para consultas
                objConsulta = (CapaNegocioConsultas)Session["objConsulta"];
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            GridView1.DataSource =objConsulta.ObtenConsultaNumInventario(TextBox2.Text, ref m);
            GridView1.DataBind();
            TextBox1.Text = m;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = objConsulta.ObtenEquiposConLaboratorio(ref m);
            GridView2.DataSource = Session["Tabla1"];
            TextBox1.Text = m;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            GridView3.DataSource = objConsulta.ObtenConsultaNumInventarioLaboratorioActualizaciones(TextBox3.Text, ref m);
            GridView3.DataBind();
            TextBox1.Text = m;
        }
    }
}