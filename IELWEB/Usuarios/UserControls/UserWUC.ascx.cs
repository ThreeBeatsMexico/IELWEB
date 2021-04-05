using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Text;
using System.Web.Security;
using IELENT.User;
using IELBUS.Security;
using IELENT.Security;
using IELBUS.Common;
using IELENT.Common;

namespace IELWEB.Usuarios.UserControls
{
    public partial class UserWUC : System.Web.UI.UserControl
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
                        CargaInicial();
                    }
                }
                catch (Exception)
                {
                    //throw ex;
                }

            }
        }

        private void VariablesViewState()
        {
            ViewState["USuarioValido"] = 0;
            ViewState["Password"] = string.Empty;
        }
        public void CargaSiempre()
        {
            RegisterFileUpload();
        }
        private void CargaInicial()
        {
            SetDdlCatalogos(ddlSexo, "8");
            SetDdlCatalogos(ddlEstadoCivil, "5");
        }

        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oCommonServiceClient = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            Respuesta = oCommonServiceClient.GetCatEspecifico(sIdCatalogo, sValorFiltro);

            List<CatalogosBE> lstDdl = new List<CatalogosBE>();
            CatalogosBE item = new CatalogosBE();

            item.ID = "0";
            item.DESCRIPCION = "Seleccione Opción..";

            lstDdl.Add(item);
            lstDdl.AddRange(Respuesta.lstCatalogo);

            ddl.DataSource = lstDdl;
            ddl.DataValueField = "ID";
            ddl.DataTextField = "DESCRIPCION";

            ddl.DataBind();
        }

        public void RegisterFileUpload()
        {
            StringBuilder sQuery = new StringBuilder(string.Empty);
            //sQuery.Append("$(function () {$('#");
            //sQuery.Append(grd.ClientID);
            //sQuery.Append("').dataTable({");
            ////sQuery.Append("'sScrollX':'300px',");
            //sQuery.Append("'bStateSave': true");
            //sQuery.Append("});});");

            sQuery.Append("$('#");
            sQuery.Append(avatar.ClientID);
            sQuery.Append("').fileinput({");
            sQuery.Append("overwriteInitial: true,");
            sQuery.Append("maxFileSize: 1500,");
            sQuery.Append("showClose: false,");
            sQuery.Append("showCaption: false,");
            sQuery.Append("browseLabel: '',");
            sQuery.Append("removeLabel: '',");
            sQuery.Append("browseIcon: '<i class=\"glyphicon glyphicon-camera\"></i>',");
            sQuery.Append("removeIcon: '<i class=\"glyphicon glyphicon-remove\"></i>',");
            sQuery.Append("removeTitle: 'Cancelar o reiniciar cambios',");
            sQuery.Append("elErrorContainer: '#kv-avatar-errors',");
            sQuery.Append("msgErrorClass: 'alert alert-block alert-danger',");
            sQuery.Append("defaultPreviewContent: '<img src=\"../dist/img/user.png\" alt=\"Your Avatar\" class=\"img-circle\" style=\"width:160px\">',");
            //layoutTemplates: { main2: '{preview} ' + btnCust + ' {remove} {browse}' },
            sQuery.Append("layoutTemplates: { main2: '{preview} ' + ' {remove} {browse}' },");
            sQuery.Append("allowedFileExtensions: ['jpg', 'png', 'gif']");
            sQuery.Append("});");


            //sQuery.Append("Alert('Test Carga');");



            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "RegisterFileUpload", sQuery.ToString(), true);
        }

        public UsuariosBE GetUsuario()
        {
            SecurityBR oSecurity = new SecurityBR();
            EncryptionBE oEncription = new EncryptionBE();
            UsuariosBE item = new UsuariosBE();
            string sPassword = string.Empty;

            oEncription = oSecurity.encryptDesEncrypt(1, ViewState["Password"].ToString(), long.Parse(ResIEL.IdApp));

            item.IDUSUARIO = string.IsNullOrEmpty(txtIdUsuario.Text.ToString()) ? 0 : long.Parse(txtIdUsuario.Text.ToString());

            item.USUARIO = txtUsuario.Text;
            item.IDUSUARIOAPP = txtUsuario.Text;
            item.PASSWORD = oEncription.VALOROUT;

            item.NOMBRE = txtNombres.Text.ToUpper();
            item.APATERNO = txtAPaterno.Text.ToUpper();
            item.AMATERNO = txtAMaterno.Text.ToUpper();
            item.FECHANACCONST = DateTime.Parse(txtFechaNacimiento.Text);

            item.IDSEXO = int.Parse(ddlSexo.SelectedValue);
            item.IDESTADOCIVIL = int.Parse(ddlEstadoCivil.SelectedValue);

            //Consultar con July que Pex
            item.IDTIPOUSUARIO = 1;
            item.IDTIPOPERSONA = 1;//Fisica Moral
            //item.IDAREA = null;
            item.ACTIVO = true;
            item.RUTAFOTOPERFIL = "../dist/img/user.png";//Verificar foto

            return item;
        }
        public void SetUsuario(UsuariosBE item)
        {
            SecurityBR oSecurity = new SecurityBR();
            EncryptionBE itemSecurity = new EncryptionBE();
            itemSecurity = oSecurity.encryptDesEncrypt(2, item.PASSWORD, long.Parse(ResIEL.IdApp));

            txtIdUsuario.Text = item.IDUSUARIO.ToString();
            txtUsuario.Text = item.IDUSUARIO.ToString();

            txtUsuario.Text = item.USUARIO;
            ViewState["Password"] = itemSecurity.VALOROUT;

            txtNombres.Text = item.NOMBRE;
            txtAPaterno.Text = item.APATERNO;
            txtAMaterno.Text = item.AMATERNO;
            txtFechaNacimiento.Text = item.FECHANACCONST.ToString();

            ddlSexo.SelectedValue = item.IDSEXO.ToString();
            ddlEstadoCivil.SelectedValue = item.IDESTADOCIVIL.ToString();

            //Consultar con July que Pex
            //item.IDTIPOUSUARIO = 0;
            //item.IDTIPOPERSONA = 0;
            //item.IDAREA = 8;
            //item.IDTIPOUSUARIO = 0;
        }
        public void ClearUsuario()
        {
            txtIdUsuario.Text = string.Empty;
            txtUsuario.Text = string.Empty;

            txtUsuario.Text = string.Empty;
            ViewState["Password"] = string.Empty;

            txtNombres.Text = string.Empty;
            txtAPaterno.Text = string.Empty;
            txtAMaterno.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;

            ddlSexo.SelectedValue = "0";
            ddlEstadoCivil.SelectedValue = "0";

            //Consultar con July que Pex
            //item.IDTIPOUSUARIO = 0;
            //item.IDTIPOPERSONA = 0;
            //item.IDAREA = 8;
            //item.IDTIPOUSUARIO = 0;
        }
    }
}