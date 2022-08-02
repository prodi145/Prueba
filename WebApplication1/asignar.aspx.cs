using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ClassBLInventario;
using ClassCapaEntidad;

namespace WebApplication1
{

    public partial class asignar : System.Web.UI.Page
    {
        CapaNegocioComponentes nueva = null;
        CapaNegocioMarca pruev1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                nueva = new CapaNegocioComponentes(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nuevo"] = nueva;



            }
            else
            {
                nueva = (CapaNegocioComponentes)Session["Nuevo"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}