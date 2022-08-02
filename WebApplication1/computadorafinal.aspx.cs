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
    public partial class WebForm1 : System.Web.UI.Page
    {
        CapaNegocioComputFinal nueva = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //para tipo disco
                nueva = new CapaNegocioComputFinal(ConfigurationManager.ConnectionStrings["nueva"].ConnectionString);
                Session["Nueva"] = nueva;



            }
            else
            {
                //para tipo disco
                nueva = (CapaNegocioComputFinal)Session["Nueva"];


            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla1"] = nueva.ObtenTodCPUGenerico(ref m);
            GridView1.DataSource = Session["Tabla1"];
            TextBox1.Text = m;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla2"] = nueva.ObtenTodTeclado(ref m);
            GridView2.DataSource = Session["Tabla2"];
            TextBox1.Text = m;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla3"] = nueva.ObtenTodMonitor(ref m);
            GridView3.DataSource = Session["Tabla3"];
            TextBox1.Text = m;
            GridView3.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla4"] = nueva.ObtenTodMouse(ref m);
            GridView4.DataSource = Session["Tabla4"];
            TextBox1.Text = m;
            GridView4.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //obtenemos el nombre del arcivo a subir
                string nomFile = FileUpload1.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta = "imgcfinal/" + nomFile;
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

                string nomFile2 = FileUpload2.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta2 = "imgcfinal/" + nomFile2;
                //su longitud
                int imgtamano2 = FileUpload2.PostedFile.ContentLength;

                if (imgtamano2 > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile2.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload2.SaveAs(Server.MapPath(imgRuta2));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image2.ImageUrl = "~/" + imgRuta2;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile2.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }

                string nomFile3 = FileUpload3.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta3 = "imgcfinal/" + nomFile3;
                //su longitud
                int imgtamano3 = FileUpload3.PostedFile.ContentLength;

                if (imgtamano3 > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile3.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload3.SaveAs(Server.MapPath(imgRuta3));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image3.ImageUrl = "~/" + imgRuta3;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile3.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }


                string m = "";

                EntidadComputadoraFinal actualiza = null;

                if (GridView1.SelectedIndex >= 0)
                {
                    if (GridView2.SelectedIndex >= 0)
                    {
                        if (GridView3.SelectedIndex >= 0)
                        {
                            if (GridView4.SelectedIndex >= 0)
                            {

                                actualiza = new EntidadComputadoraFinal()
                                {
                                    num_inv = TextBox7.Text,
                                    num_scpu = TextBox2.Text,
                                    id_cpug = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                                    num_steclado = TextBox3.Text,

                                    id_tecladog = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                                    num_smonitor = TextBox4.Text,

                                    id_mong = Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),

                                    num_smouse = TextBox5.Text,
                                    id_mousg = Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),
                                    estado = TextBox6.Text,

                                    img1 = imgRuta,

                                    img2 = imgRuta2,

                                    img3 = imgRuta3






                                };
                                nueva.InsertarComputadoFinal(actualiza, ref m);
                                TextBox1.Text = m;
                            }
                            else
                            {
                                TextBox1.Text = "Selecciona un Mouse";

                            }

                        }
                        else
                        {
                            TextBox1.Text = "Selecciona un Monitor ";

                        }

                    }
                    else
                    {
                        TextBox1.Text = "Selecciona un Teclado";

                    }

                }
                else
                {
                    TextBox1.Text = "Selecciona un CPU";

                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string m = "";
            Session["Tabla5"] = nueva.ObtenTodComputadorFinal(ref m);
            GridView5.DataSource = Session["Tabla5"];
            TextBox1.Text = m;
            GridView5.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (GridView5.SelectedIndex >= 0)
            {

                

                TextBox2.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[2].Text;

                TextBox3.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[4].Text;

                TextBox4.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[6].Text;

                TextBox5.Text= GridView5.Rows[GridView5.SelectedIndex].Cells[8].Text;

                TextBox6.Text = GridView5.Rows[GridView5.SelectedIndex].Cells[10].Text;

                string m = "";
                Session["Tabla1"] = nueva.ObtenTodCPUGenerico(ref m);
                GridView1.DataSource = Session["Tabla1"];
                TextBox1.Text = m;
                GridView1.DataBind();

                string m2 = "";
                Session["Tabla2"] = nueva.ObtenTodTeclado(ref m2);
                GridView2.DataSource = Session["Tabla2"];
                TextBox1.Text = m2;
                GridView2.DataBind();

                string m3 = "";
                Session["Tabla3"] = nueva.ObtenTodMonitor(ref m3);
                GridView3.DataSource = Session["Tabla3"];
                TextBox1.Text = m3;
                GridView3.DataBind();

                string m4 = "";
                Session["Tabla4"] = nueva.ObtenTodMouse(ref m4);
                GridView4.DataSource = Session["Tabla4"];
                TextBox1.Text = m4;
                GridView4.DataBind();

            }
            else
            {
                TextBox2.Text = "Selecciona una computadora final";

            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                //obtenemos el nombre del arcivo a subir
                string nomFile = FileUpload1.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta = "imgcfinal/" + nomFile;
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

                string nomFile2 = FileUpload2.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta2 = "imgcfinal/" + nomFile2;
                //su longitud
                int imgtamano2 = FileUpload2.PostedFile.ContentLength;

                if (imgtamano2 > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile2.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload2.SaveAs(Server.MapPath(imgRuta2));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image2.ImageUrl = "~/" + imgRuta2;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile2.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }

                string nomFile3 = FileUpload3.FileName;

                //definimos la ruta en dnde se almacenara en el servidor
                string imgRuta3 = "imgcfinal/" + nomFile3;
                //su longitud
                int imgtamano3 = FileUpload3.PostedFile.ContentLength;

                if (imgtamano3 > 5242880)
                {
                    Page.ClientScript.RegisterClientScriptBlock(nomFile3.GetType(), "Alert1",
                        "alert('File is too big.')", true);
                }
                else
                {
                    FileUpload3.SaveAs(Server.MapPath(imgRuta3));
                    //oara comprobar ques se subio el archivo se visualiza en el img
                    Image3.ImageUrl = "~/" + imgRuta3;
                    Page.ClientScript.RegisterClientScriptBlock(nomFile3.GetType(), "Alert2",
                        "alert('IMAGEN GUARDADA')", true);
                }


                string m = "";

                EntidadComputadoraFinal actualiza = null;
                if(GridView5.SelectedIndex >= 0)
                {
                    if (GridView1.SelectedIndex >= 0)
                    {
                        if (GridView2.SelectedIndex >= 0)
                        {
                            if (GridView3.SelectedIndex >= 0)
                            {
                                if (GridView4.SelectedIndex >= 0)
                                {

                                    actualiza = new EntidadComputadoraFinal()
                                    {
                                        num_inv = GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text,
                                        num_scpu = TextBox2.Text,
                                        id_cpug = Convert.ToInt32(GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text),

                                        num_steclado = TextBox3.Text,

                                        id_tecladog = Convert.ToInt32(GridView2.Rows[GridView2.SelectedIndex].Cells[1].Text),

                                        num_smonitor = TextBox4.Text,

                                        id_mong = Convert.ToInt32(GridView3.Rows[GridView3.SelectedIndex].Cells[1].Text),

                                        num_smouse = TextBox5.Text,
                                        id_mousg = Convert.ToInt32(GridView4.Rows[GridView4.SelectedIndex].Cells[1].Text),
                                        estado = TextBox6.Text,

                                        img1 = imgRuta,

                                        img2 = imgRuta2,

                                        img3 = imgRuta3






                                    };
                                    nueva.ModificarComputadorFinal(actualiza, ref m);
                                    TextBox1.Text = m;
                                }
                                else
                                {
                                    TextBox1.Text = "Selecciona un Mouse";

                                }

                            }
                            else
                            {
                                TextBox1.Text = "Selecciona un Monitor ";

                            }

                        }
                        else
                        {
                            TextBox1.Text = "Selecciona un Teclado";

                        }

                    }
                    else
                    {
                        TextBox1.Text = "Selecciona un CPU";

                    }
                }   
                else
                {
                    TextBox1.Text = "Selecciona una computadora final";
                }

               
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string m = "";
            EntidadComputadoraFinal elimina = null;
            if (GridView5.SelectedIndex >= 0)
            {
                elimina = new EntidadComputadoraFinal()
                {
                    num_inv = GridView5.Rows[GridView5.SelectedIndex].Cells[1].Text


                };

                nueva.EliminarComputadorFinal(elimina, ref m);
                TextBox1.Text = m;

            }
            else
            {
                TextBox1.Text = "Selecciona una computadora final";

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (GridView5.SelectedIndex >= 0)
            {
                Image1.ImageUrl = GridView5.Rows[GridView5.SelectedIndex].Cells[11].Text;
                Image2.ImageUrl = GridView5.Rows[GridView5.SelectedIndex].Cells[12].Text;
                Image3.ImageUrl = GridView5.Rows[GridView5.SelectedIndex].Cells[13].Text;
            }
            else
            {
                TextBox3.Text = "Selecciona una computadora Final";
            }
        }
    }
}