using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELBUS;
using IELENT;


namespace IELWEB.Startup
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

               
                Permisos(Context.User.Identity.Name);

            }
            catch (Exception ex)
            {
                lblOpciones.Text = ex.Message;

            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
          
            FormsAuthentication.SignOut();
            Response.Redirect("../Startup/default.aspx");
        }

        void Permisos(string prmUSER_LOGIN)
        {
            try
            {
                MenuTopBus oMenuBus = new MenuTopBus();
                MenuTopEnt oMenuEnt = new MenuTopEnt();

                oMenuEnt = oMenuBus.ObtieneMenuPrincipal(prmUSER_LOGIN.ToString());
       if (oMenuEnt.psAdministrar)
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{administrar}", "<li><a href='../Administracion/MenuAdmin.aspx\'>Administrar</a></li>");
                    }
                    else
                    {
                        lblOpciones.Text = lblOpciones.Text.Replace("{administrar}", "");
                    }
                    if (oMenuEnt.psAlumnos)
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{alumnos}", "<li><a href='../Alumnos/Alumnos.aspx\'>Alumnos</a></li>");
                    }
                    else
                    {
                        lblOpciones.Text = lblOpciones.Text.Replace("{alumnos}", "");
                    }
                    //if (oMenuEnt.psProfesores)
                    //{
                    //    lblOpciones.Text =
                    //        lblOpciones.Text.Replace("{profesores}", "<li><a href='../Profesores/MenuProfesores.aspx\'>Profesores</a></li>");
                    //}
                    //else
                    //{
                    //    lblOpciones.Text =
                    //        lblOpciones.Text.Replace("{profesores}", "");
                    //}

                    if (oMenuEnt.psCobranza)
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{cobranza}", "<li><a href='../Cobranza/MenuCobranza.aspx\'>Cobranza</a></li>");
                    }
                    else
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{cobranza}", "");
                    }


                  

                    if (oMenuEnt.psPago)
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{pago}", "<li><a href='../Pagos/Pagos.aspx\'>Pago</a></li>");
                    }
                    else
                    {
                        lblOpciones.Text =
                            lblOpciones.Text.Replace("{pago}", "");
                    }

                   



            }
            catch { }

        }

     

    }
}