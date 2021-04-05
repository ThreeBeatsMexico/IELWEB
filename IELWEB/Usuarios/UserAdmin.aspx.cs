using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELENT.User;
using IELBUS.Security;
using IELENT.Common;
using IELBUS.User;
using IELBUS.Common;


namespace IELWEB.Usuarios
{
    public partial class UserAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargaInicial();
            CargaSiempre();
        }



        private void CargaInicial()
        {
            VariablesViewState();
           // SetDdlCatalogos(ddlSistema, "10");
           // SetGrid(true);
            //RegisterGridpaging(grdUsuarios);
        }
        private void CargaSiempre()
        {
            RegisterGridpaging(grdUsuarios);
        }
        private void VariablesViewState()
        {
            ViewState["lstUsuarios"] = new List<UsuariosBE>();
        }
        private void SetGrid(bool bCargaInicial)
        {
            UsersBR oUserSecurity = new UsersBR();
            ReglasBE Reglas = new ReglasBE();
            UserBE Usuario = new UserBE();
            UsuariosBE item = new UsuariosBE();
            List<UsuariosBE> lstUsuarios = new List<UsuariosBE>();

           // item.IDAPLICACION = ddlSistema.SelectedIndex;
            item.IDUSUARIOAPP = txtUsuario.Text;
            item.NOMBRE = txtNombre.Text;
            item.APATERNO = txtAPaterno.Text;
            item.AMATERNO = txtAMaterno.Text;

            if (bCargaInicial)
            {
                lstUsuarios = oUserSecurity.GetUsuarios(item, long.Parse(ResIEL.IdApp));
                ViewState["lstUsuarios"] = lstUsuarios;
            }
            lstUsuarios = (List<UsuariosBE>)ViewState["lstUsuarios"];
            grdUsuarios.DataSource = lstUsuarios;
            grdUsuarios.DataBind();


        }
        private void RegisterGridpaging(GridView grd)
        {
            if (grd.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(grd.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grd.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "javascriptGrdUsuarios", sQuery.ToString(), true);
            }
        }
        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oCommonServiceClient = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();

            if (sIdCatalogo != "0")
                Respuesta = oCommonServiceClient.GetCatEspecifico(sIdCatalogo, sValorFiltro);
            else return;

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
        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<UsuariosBE> lstUsaurios = (List<UsuariosBE>)ViewState["lstUsuarios"];
            UsuariosBE item = new UsuariosBE();
            GridViewRow gvrow = grdUsuarios.Rows[index];
            UserBE Usuario = new UserBE();

            string sIdUsuario = grdUsuarios.DataKeys[index].Value.ToString();

            UsersBR oUserSecurityServiceClient = new UsersBR();
            ReglasBE Reglas = new ReglasBE();

            Reglas.USUARIO = sIdUsuario;
            Reglas.TIPOBUSQUEDA = 1;

            Usuario.DATOSUSUARIO = oUserSecurityServiceClient.getUsuarioFull(Reglas, long.Parse(ResIEL.IdApp));

            if (e.CommandName.Equals("EditUsuario"))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlUser').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlEditUserScript", sb.ToString(), false);

                sMensajelbl.Append(" EDITAR USUARIO ");
                //sMensajelbl.Append(item.psNOMBRECATALOGO);

                lblModalUser.Text = sMensajelbl.ToString();

                UserFullWUC.ClearWUCs();
                UserFullWUC.SetWUCs(Usuario);
                UserFullWUC.RegisterWUCsScripts();
            }

            RegisterGridpaging(grdUsuarios);
        }
        protected void btnShowAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('");
            sb.Append("#mdlUser");
            sb.Append("').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

            RegisterGridpaging(grdUsuarios);

            UserFullWUC.ClearWUCs();
            UserFullWUC.RegisterWUCsScripts();
        }
        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            SetGrid(true);
            RegisterGridpaging(grdUsuarios);
        }

        protected void btnSaveUsuario_Click(object sender, EventArgs e)
        {
            UsersBR oSecurityClient = new UsersBR();
            UserBE Respuesta = new UserBE();
            ReglasBE Reglas = new ReglasBE();
            Respuesta = UserFullWUC.GetWUCs();
            string sMensaje = string.Empty;
            StringBuilder sMensajeRespuesta = new StringBuilder(string.Empty);
            UsuariosBE Res;
            bool upd = false;
            Reglas.IDAPP = long.Parse(ResIEL.IdApp);

            if (Respuesta.USUARIOS.IDUSUARIO == 0)
            {
                Res = oSecurityClient.addUsuario(Reglas, Respuesta.USUARIOS, Respuesta.DOMICILIOS, Respuesta.CONTACTOS,
                Respuesta.ROLESXUSUARIO, long.Parse(ResIEL.IdApp));
                sMensaje = "El Usuario se dio de alta correctamente.";
            }
            else
            {
                upd = oSecurityClient.updateUsuario(Reglas, Respuesta.USUARIOS, Respuesta.DOMICILIOS, Respuesta.CONTACTOS,
                Respuesta.ROLESXUSUARIO, long.Parse(ResIEL.IdApp));
                sMensaje = "El Usuario se actualizó correctamente.";
            }
            sMensajeRespuesta.Append("alert('");
            if (upd)
                sMensajeRespuesta.Append(sMensaje);
            else
                sMensaje = "Existió un error al dar de alta al cliente.";


            sMensajeRespuesta.Append("');");

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append(sMensajeRespuesta.ToString());
            sb.Append("$('#mdlUser').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

            SetGrid(true);
            RegisterGridpaging(grdUsuarios);
        }

    }
}