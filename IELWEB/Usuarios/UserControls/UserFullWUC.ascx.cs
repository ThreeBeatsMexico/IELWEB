using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IELENT.User;
namespace IELWEB.Usuarios.UserControls
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarSiempre();
        }
        private void CargarSiempre()
        {
            RegisterTabSaveState();
        }
        public void RegisterWUCsScripts()
        {
            UserWUC.RegisterFileUpload();
            ContactoWUC.RegisterGridpaging();
            DomicilioWUC.RegisterGridpaging();
            PermisosWUC.RegisterGridpaging();
        }
        private void RegisterTabSaveState()
        {
            StringBuilder sQuery = new StringBuilder(string.Empty);
            sQuery.Append("$(function () {");
            sQuery.Append("var tabName = $(\"[id*=TabName]\").val() != \"\" ? $(\"[id*=TabName]\").val() : \"Tab_User\";");
            sQuery.Append("$('#Tabs a[href=\"#' + tabName + '\"]').tab('show');");
            sQuery.Append("$(\"#Tabs a\").click(function () {");
            sQuery.Append("$(\"[id*=TabName]\").val($(this).attr(\"href\").replace(\"#\", \"\"));");
            sQuery.Append("});");
            sQuery.Append("});");

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "TabRegister", sQuery.ToString(), true);
        }
        public void ClearWUCs()
        {
            UserWUC.ClearUsuario();

            ContactoWUC.ClearContacto();
            ContactoWUC.ClearGrid();

            DomicilioWUC.ClearDomicilio();
            DomicilioWUC.ClearGrid();

            PermisosWUC.ClearPermisos();
            PermisosWUC.ClearGrid();
            

        }
        public void SetWUCs(UserBE Usuario)
        {
            UserWUC.SetUsuario(Usuario.DATOSUSUARIO.Usuario);
            ContactoWUC.SetGrid(Usuario.DATOSUSUARIO.Contactos, true);
            DomicilioWUC.SetGrid(Usuario.DATOSUSUARIO.Domicilios, true);
            PermisosWUC.SetPermisos(Usuario.DATOSUSUARIO.RolesXUsuario, Usuario.DATOSUSUARIO.Usuario.IDUSUARIO.ToString());
        }
        public UserBE GetWUCs()
        {
            UserBE Usuario = new UserBE();
             
           
            Usuario.USUARIOS = new UsuariosBE();
            Usuario.CONTACTOS = new List<ContactoBE>();
            Usuario.DOMICILIOS = new List<DomicilioBE>();
            Usuario.ROLESXUSUARIO = new List<RolesXUsuarioBE>();

            Usuario.USUARIOS = UserWUC.GetUsuario();
            Usuario.CONTACTOS = ContactoWUC.GetContactos();
            Usuario.DOMICILIOS = DomicilioWUC.GetDomicilios();
            Usuario.ROLESXUSUARIO = PermisosWUC.GetPermisos();

            return Usuario;
        }
    }
}