using IELENT.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELibertadWEB.Startup
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage("Login.aspx");
            }
            else
            {
                try
                {
                    if (!Page.IsPostBack)
                    {

                        UsuariosBE itemSecurity = new UsuariosBE();
                        itemSecurity = (UsuariosBE)Session["USER_SESSION"];
                        lblUsuario.Text = itemSecurity.NOMBRE + " " + itemSecurity.APATERNO + " " + itemSecurity.AMATERNO;
                        // GetNotificaciones(itemSecurity.IDUSUARIOAPP);

                    }
                }
                catch (Exception ex)
                {

                }


            }
        }
    }
}