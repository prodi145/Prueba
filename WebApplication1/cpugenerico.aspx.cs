using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data.SqlClient;
using System.Data;
using ClassBLInventario;
using ClassCapaEntidad;
using System.Configuration;

namespace WebApplication1
{
    public partial class cpugenerico : System.Web.UI.Page
    {
        CapaNegocioCPUGenerico nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioCPUGenerico(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioCPUGenerico)Session["Nueva"];


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.ObtenTodoTipoCPU(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox3.Text = m;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.DevuelveMarc(ref m);
            GridView2.DataSource = Session["Tabla2"];
            TextBox3.Text = m;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = nueva.ObtenTodaRAM(ref m);
            GridView3.DataSource = Session["Tabla3"];
            TextBox3.Text = m;
            GridView3.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla4"] = nueva.ObtenTodasGabinete(ref m);
            GridView4.DataSource = Session["Tabla4"];
            TextBox3.Text = m;
            GridView4.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //obtenemos el nombre del arcivo a subir
                string nomFile = FileUpload1.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta = "ImgCpu/" + nomFile;
                //su longitud
                int imgtamano = FileUpload1.PostedFile.ContentLength;

                if (imgtamano > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath(imgRuta));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image1.ImageUrl = "~/" + imgRuta;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }


                string m = "";

                EntidadCPUGenerico actualiza = null;
            
                if (GridView1.SelectedIndex >= 0)
                {
                    if (GridView2.SelectedIndex >= 0)
                    {
                        if (GridView3.SelectedIndex >= 0)
                        {
                            if (GridView4.SelectedIndex >= 0)
                            {

                                actualiza = new EntidadCPUGenerico()
                                {
                                    f_Tcpu = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                                    f_MarcaCpu = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                                    Modelo = TextBox1.Text,
                                    Descripcion = TextBox2.Text,
                                    f_tipoRam = Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),

                                    id_Gabinete = Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),

                                    img = imgRuta



                                };
                                nueva.InsertarCPUGenerico(actualiza, ref m);
                                TextBox3.Text = m;
                            }
                            else
                            {
                                TextBox3.Text = "Selecciona un gabinete";

                            }

                        }
                        else
                        {
                            TextBox3.Text = "Selecciona una Ram";

                        }

                    }
                    else
                    {
                        TextBox3.Text = "Selecciona una marca";

                    }

                }
                else
                {
                    TextBox3.Text = "Selecciona una Tipo CPU";

                }
            }


        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla5"] = nueva.ObtenTodCPUGenerico(ref m);
            GridView5.DataSource = Session["Tabla5"];
            TextBox3.Text = m;
            GridView5.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (GridView5.SelectedIndex >= 0)
            {

                TextBox1.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[4].Text;

                TextBox2.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[5].Text;

                string m = "";
                Session["Tabla1"] = nueva.ObtenTodoTipoCPU(ref m);
                GridView1.DataSource = Session["Tabla1"];
                TextBox3.Text = m;
                GridView1.DataBind();

                string m2 = "";
                Session["Tabla2"] = nueva.DevuelveMarc(ref m2);
                GridView2.DataSource = Session["Tabla2"];
                TextBox3.Text = m2;
                GridView2.DataBind();

                string m3 = "";
                Session["Tabla3"] = nueva.ObtenTodaRAM(ref m3);
                GridView3.DataSource = Session["Tabla3"];
                TextBox3.Text = m3;
                GridView3.DataBind();

                string m4 = "";
                Session["Tabla4"] = nueva.ObtenTodasGabinete(ref m4);
                GridView4.DataSource = Session["Tabla4"];
                TextBox3.Text = m4;
                GridView4.DataBind();
                


            }
            else
            {
                TextBox2.Text = "Selecciona un CPU GENERICO";

            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //obtenemos el nombre del arcivo a subir
                string nomFile = FileUpload1.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta = "ImgCpu/" + nomFile;
                //su longitud
                int imgtamano = FileUpload1.PostedFile.ContentLength;

                if (imgtamano > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath(imgRuta));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image1.ImageUrl = "~/" + imgRuta;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }


                string m = "";

                EntidadCPUGenerico actualiza = null;

                if (GridView1.SelectedIndex >= 0)
                {
                    if (GridView2.SelectedIndex >= 0)
                    {
                        if (GridView3.SelectedIndex >= 0)
                        {
                            if (GridView4.SelectedIndex >= 0)
                            {

                                actualiza = new EntidadCPUGenerico()
                                {
                                    id_CPU = Convert.ToInt32(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text),

                                    f_Tcpu = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                                    f_MarcaCpu = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                                    Modelo = TextBox1.Text,
                                    Descripcion = TextBox2.Text,

                                    f_tipoRam = Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),

                                    id_Gabinete = Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),

                                    img = imgRuta



                                };
                                nueva.ModificarCPUGenerico(actualiza, ref m);
                                TextBox3.Text = m;
                            }
                            else
                            {
                                TextBox3.Text = "Selecciona un gabinete";

                            }

                        }
                        else
                        {
                            TextBox3.Text = "Selecciona una Ram";

                        }

                    }
                    else
                    {
                        TextBox3.Text = "Selecciona una marca";

                    }

                }
                else
                {
                    TextBox3.Text = "Selecciona una Tipo CPU";

                }
                         }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadCPUGenerico elimina = null;
            if (GridView5.SelectedIndex >= 0)
            {
                elimina = new EntidadCPUGenerico()
                {
                    id_CPU = Convert.ToInt32(GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text)


                };

                nueva.EliminarCPUGenerico(elimina, ref m);
                TextBox3.Text = m;

            }
            else
            {
                TextBox3.Text = "Selecciona un CPU GENERICO";

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (GridView5.SelectedIndex >= 0)
            {
                Image1.ImageUrl = GridView5.Rows[GridView5.SelectedIndex].Cells[8].Text;
            }
            else
            {
                TextBox3.Text = "Selecciona un CPU";
            }
                
        }
    }
}