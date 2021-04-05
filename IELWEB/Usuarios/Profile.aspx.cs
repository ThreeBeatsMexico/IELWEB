using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELBUS.User;
using IELENT.Common;
using IELENT.User;


namespace IELWEB.Usuarios
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargaInicial();
            //CargarSiempre();
        }

        private void VariablesViewstate()
        {
            ViewState["PasswordProfile"] = string.Empty;
        }

        private void CargaInicial()
        {
            VariablesViewstate();
            GetDatosUsuario();
            RegisterWUCsScripts();
        }

        private void CargarSiempre()
        {
            RegisterWUCsScripts();
        }

        private void GetDatosUsuario()
        {

            UsersBR seguridad = new UsersBR();
            ReglasBE reglas = new ReglasBE();
            DatosUsuarioBE oUsuario = new DatosUsuarioBE();
           
            UsuariosBE itemSecurity = new UsuariosBE();
            itemSecurity = (UsuariosBE)Session["USER_SESSION"];

            reglas.TIPOBUSQUEDA = 1;
            reglas.USUARIO = itemSecurity.IDUSUARIO.ToString();
            reglas.IDAPP = long.Parse(ResIEL.IdApp);
            oUsuario = seguridad.getUsuarioFull(reglas, long.Parse(ResIEL.IdApp));

            //ClearWUCs();
            SetWUCs(oUsuario);
            RegisterWUCsScripts();

        }

        public void ClearWUCs()
        {
            UserWUC.ClearUsuario();

            ContactoWUC.ClearContacto();
            ContactoWUC.ClearGrid();

            DomicilioWUC.ClearDomicilio();
            DomicilioWUC.ClearGrid();
        }
        public void SetWUCs(DatosUsuarioBE Usuario)
        {
            UserWUC.SetUsuario(Usuario.Usuario);
            ContactoWUC.SetGrid(Usuario.Contactos, true);
            DomicilioWUC.SetGrid(Usuario.Domicilios, true);
        }
        public UserBE GetWUCs()
        {
            UserBE Usuario = new UserBE();

            DatosUsuarioBE oDatosUsuario = new DatosUsuarioBE();
            UsuariosBE oUsuario = new UsuariosBE();
            List<ContactoBE> oContactos = new List<ContactoBE>();
            List<DomicilioBE> oDomicilios = new List<DomicilioBE>();

            Usuario.USUARIOS = UserWUC.GetUsuario();
            Usuario.CONTACTOS = ContactoWUC.GetContactos();
            Usuario.DOMICILIOS = DomicilioWUC.GetDomicilios();

            return Usuario;
        }
        public void RegisterWUCsScripts()
        {
            UserWUC.RegisterFileUpload();
            ContactoWUC.RegisterGridpaging();
            DomicilioWUC.RegisterGridpaging();
        }

        protected void btnSavePass_Click(object sender, EventArgs e)
        {
            ViewState["PasswordProfile"] = PasswordWUC.GetNewPass();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsersBR oSecurityClient = new UsersBR();
            UserBE Respuesta = new UserBE();
            ReglasBE Reglas = new ReglasBE();
            string sMensaje = string.Empty;
            StringBuilder sMensajeRespuesta = new StringBuilder(string.Empty);
            bool res;
            Respuesta = GetWUCs();
            Reglas.IDAPP = long.Parse(ResIEL.IdApp);



            res = oSecurityClient.updateUsuario(Reglas, Respuesta.USUARIOS, Respuesta.DOMICILIOS, Respuesta.CONTACTOS,
            Respuesta.DATOSUSUARIO.RolesXUsuario, long.Parse(ResIEL.IdApp));


            sMensajeRespuesta.Append("alert('");
            if (res)
            {
                sMensaje = "El Usuario se actualizó correctamente.";
                sMensajeRespuesta.Append(sMensaje);
            }
            else
            {
                sMensaje = "Existió un error al dar de alta al cliente.";
                sMensajeRespuesta.Append(sMensaje);
            }


            sMensajeRespuesta.Append("');");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(sMensajeRespuesta.ToString());
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ShowAlertUpdateScript", sb.ToString(), false);
        }
    }
}