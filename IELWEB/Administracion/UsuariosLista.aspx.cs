using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using IELENT;
using IELBUS;


namespace IELWEB.Administracion
{
    public partial class UsuariosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage("../Startup/login.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        ReadData();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        void ReadData()
        {
            try
            {
                List<UsuarioEnt> oUsuarios = new List<UsuarioEnt>();
                UsuarioBus oUsuariosBus = new UsuarioBus();

                oUsuarios = oUsuariosBus.ListaUsuarios();
                grdLista.DataSource = oUsuarios;
                grdLista.DataBind();
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Usuario.aspx?id=0");
        }


      

    }
}