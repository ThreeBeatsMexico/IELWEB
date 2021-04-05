using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using IELENT.User;
using IELENT.Common;
using IELBUS.User;
using IELBUS.Common;


namespace IELWEB.Usuarios.UserControls
{
    public partial class PermisosWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaInicial();
            }
            //CargarSiempre();
        }
        private void CargaInicial()
        {
            VariablesViewState();
            SetDdlCatalogos(ddlAplicacionNueva, "13");
        }
        private void VariablesViewState()
        {
            ViewState["Usuario"] = string.Empty;
            ViewState["IdRolXUsuario"] = string.Empty;
            ViewState["lstRoles"] = new List<CatalogosBE>();
            ViewState["lstRolesXUSuario"] = new List<RolesXUsuarioBE>();
            ViewState["lstAplicacionXUsuario"] = new List<UsuarioXAppBE>();
            ViewState["RowIndex"] = string.Empty;
        }
        private void CargarSiempre()
        {
            List<RolesXUsuarioBE> lstRolesXUsuario = new List<RolesXUsuarioBE>();
            lstRolesXUsuario = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
            SetGrid(lstRolesXUsuario, true);
        }
        public void RegisterGridpaging()
        {
            if (grdRoles.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(this.grdRoles.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grdRoles.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StylegrdPermisosWUC", sQuery.ToString(), true);
            }
        }
        public void ClearPermisos()
        {
            ViewState["lstAplicacionXUsuario"] = new List<UsuarioXAppBE>();
            ddlAplicacionXUsuario.DataSource = null;
            ddlAplicacionXUsuario.DataBind();
            ddlRol.DataSource = null;
            ddlRol.DataBind();
        }
        public void ClearGrid()
        {
            ViewState["lstRolesXUSuario"] = new List<RolesXUsuarioBE>();
            grdRoles.DataSource = null;
            grdRoles.DataBind();

        }
        private void SetGrid(List<RolesXUsuarioBE> lstRolesXUsuario, bool bCargaInicial = false)
        {
            if (bCargaInicial)
                ViewState["lstRolesXUSuario"] = lstRolesXUsuario;

            lstRolesXUsuario = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
            grdRoles.DataSource = lstRolesXUsuario;
            grdRoles.DataBind();
        }
        public List<RolesXUsuarioBE> GetPermisos()
        {
            List<RolesXUsuarioBE> lstRolesXUsuario = new List<RolesXUsuarioBE>();

            lstRolesXUsuario = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];

            return lstRolesXUsuario;
        }
        public void SetPermisos(List<RolesXUsuarioBE> lstRolesXUsuario, string sIdUsuario)
        {
            ViewState["Usuario"] = sIdUsuario;
            ViewState["lstRolesXUSuario"] = lstRolesXUsuario;
            SetDdlAplicacionXUsuario(sIdUsuario, true);
            SetGrid(lstRolesXUsuario, true);

        }
        private RolesXUsuarioBE GetPermiso()
        {
            RolesXUsuarioBE item = new RolesXUsuarioBE();
            long dIdRolXUsuario = string.IsNullOrEmpty(ViewState["IdRolXUsuario"].ToString()) ? 0 : long.Parse(ViewState["IdRolXUsuario"].ToString());
            long dIdUsuario = string.IsNullOrEmpty(ViewState["Usuario"].ToString()) ? 0 : long.Parse(ViewState["Usuario"].ToString());

            item.IDUSUARIO = dIdUsuario;
            item.IDROLXUSUARIO = dIdRolXUsuario;
            item.IDROL = long.Parse(ddlRol.SelectedValue);
            item.DESCROL = ddlRol.SelectedItem.ToString();
            item.IDAPLICACION = ddlAplicacionXUsuario.SelectedValue;
            item.APLICACION = ddlAplicacionXUsuario.SelectedItem.ToString();
            item.RowIndex = ViewState["RowIndex"].ToString();
            item.ACTIVO = true;

            return item;
        }
        private void SetPermiso(RolesXUsuarioBE item)
        {
            ddlAplicacionXUsuario.SelectedValue = item.IDAPLICACION;
            SetDdlCatalogos(ddlRol, "14", item.IDAPLICACION);
            ddlRol.SelectedValue = item.IDROL.ToString();
            ViewState["IdRolXUsuario"] = item.IDROLXUSUARIO;
            ViewState["RowIndex"] = item.RowIndex;
        }
        private void ClearPermiso()
        {
            ddlRol.SelectedValue = "0";
            ddlAplicacionNueva.SelectedValue = "0";
            ddlAplicacionXUsuario.SelectedValue = "0";
            ViewState["IdRolXUsuario"] = "0";
            ViewState["RowIndex"] = string.Empty;

        }
        private void SetDdlAplicacionXUsuario(string sIdUsuario, bool bCargaInicial = false)
        {
            UsersBR oUserSecurityServiceClient = new UsersBR();
            
            ReglasBE Reglas = new ReglasBE();
            List<UsuarioXAppBE> lstAppsXUsuario = new List<UsuarioXAppBE>();
            UsuarioXAppBE item = new UsuarioXAppBE();


            Reglas.TIPOBUSQUEDA = 1;
            Reglas.USUARIO = sIdUsuario;

            if (bCargaInicial)
            {
                lstAppsXUsuario = oUserSecurityServiceClient.getAppXUsuario(Reglas, long.Parse(ResIEL.IdApp));
                ViewState["lstAplicacionXUsuario"] = lstAppsXUsuario;
            }

            item.IDAPLICACION = "0";
            item.DESCRIPCION = "Seleccione Opción..";
            lstAppsXUsuario.Add(item);

            lstAppsXUsuario.AddRange((List<UsuarioXAppBE>)ViewState["lstAplicacionXUsuario"]);


            ddlAplicacionXUsuario.DataTextField = "DESCRIPCION";
            ddlAplicacionXUsuario.DataValueField = "IDAPLICACION";
            ddlAplicacionXUsuario.DataSource = lstAppsXUsuario;

            ddlAplicacionXUsuario.DataBind();
        }
        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            List<CatalogosBE> lstDdl = new List<CatalogosBE>();

            lstDdl = GetDdlCatalogos(sIdCatalogo, true, sValorFiltro);

            ddl.DataSource = lstDdl;
            ddl.DataValueField = "ID";
            ddl.DataTextField = "DESCRIPCION";

            ddl.DataBind();
        }
        private List<CatalogosBE> GetDdlCatalogos(string sIdCatalogo, bool bEsCatalogo, string sValorFiltro)
        {
            CatalogosBR oCommonServiceClient = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();

            List<CatalogosBE> lstCatalogos = new List<CatalogosBE>();

            if (sIdCatalogo != "0")
                Respuesta = oCommonServiceClient.GetCatEspecifico(sIdCatalogo, sValorFiltro);
            else
                return lstCatalogos;

            List<CatalogosBE> lstDdl = new List<CatalogosBE>();
            CatalogosBE item = new CatalogosBE();

            if (bEsCatalogo)
            {
                item.ID = "0";
                item.DESCRIPCION = "Seleccione Opción..";
                lstDdl.Add(item);
            }
            lstDdl.AddRange(Respuesta.lstCatalogo);
            lstCatalogos = lstDdl;

            return lstCatalogos;
        }
        protected void ddlAplicacionXUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<RolesXUsuarioBE> lstRolesXUsuario = new List<RolesXUsuarioBE>();
            lstRolesXUsuario = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
            string sUsuario = string.Empty;

            sUsuario = ViewState["Usuario"].ToString();

            SetDdlCatalogos(ddlRol, "14", ddlAplicacionXUsuario.SelectedValue);

            //SetGrid(sUsuario, true);
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void btnAgregarAplicacion_Click(object sender, EventArgs e)
        {
            List<UsuarioXAppBE> lstAplicacionXUsuario = new List<UsuarioXAppBE>();
            UsuarioXAppBE itemAplicacion = new UsuarioXAppBE();
            ReglasBE Reglas = new ReglasBE();
            string sIdAplicacionNueva = string.Empty;
            bool bExiste = false;
            sIdAplicacionNueva = ddlAplicacionNueva.SelectedValue;
            lstAplicacionXUsuario = (List<UsuarioXAppBE>)ViewState["lstAplicacionXUsuario"];


            foreach (var item in lstAplicacionXUsuario)
            {
                if (item.IDAPLICACION.ToString() == sIdAplicacionNueva)
                {
                    bExiste = true;
                    break;
                }
            }

            if (bExiste)
            {
                Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                oMensajeWUC.SetMensaje("La aplicación ya se encuentra asignada al usuario", 2, "mdlMensaje");
                return;
            }

            itemAplicacion.IDAPLICACION = ddlAplicacionNueva.SelectedValue.ToString();
            itemAplicacion.DESCRIPCION = ddlAplicacionNueva.SelectedItem.ToString();
            itemAplicacion.ACTIVO = true.ToString();
            itemAplicacion.IDUSUARIO = ViewState["Usuario"].ToString();

            lstAplicacionXUsuario.Add(itemAplicacion);

            SetDdlAplicacionXUsuario(ViewState["Usuario"].ToString(), false);

            ddlAplicacionNueva.SelectedValue = "0";

        }
        protected void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            List<RolesXUsuarioBE> lstRolesXUsuario = new List<RolesXUsuarioBE>();
            lstRolesXUsuario = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
            RolesXUsuarioBE item = new RolesXUsuarioBE();
            bool bExiste = false;

            item = GetPermiso();

            foreach (var itemFor in lstRolesXUsuario)
            {
                if (itemFor.IDAPLICACION == item.IDAPLICACION && item.IDROLXUSUARIO == 0)
                {
                    bExiste = true;
                    break;
                }
            }

            if (bExiste)
            {
                 Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                oMensajeWUC.SetMensaje("La aplicación ya cuanta con un Rol Asignado Edite el rol", 5, "AlertRolAsignado");
                return;
            }

            if (item.IDROLXUSUARIO != 0)
            {
                lstRolesXUsuario.RemoveAt(int.Parse(item.RowIndex));
                lstRolesXUsuario.Add(item);
            }
            else
            {
                lstRolesXUsuario.Add(item);
            }

            ViewState["lstRolesXUSuario"] = lstRolesXUsuario;
            SetGrid(lstRolesXUsuario, true);
            ClearPermiso();
            RegisterGridpaging();
            RegisterExternarScripts();
        }

        protected void grdRoles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<RolesXUsuarioBE> lstRolesXAplicacion = (List<RolesXUsuarioBE>)ViewState["lstDomicilio"];
            GridViewRow gvrow = grdRoles.Rows[index];
            RolesXUsuarioBE item = new RolesXUsuarioBE();

            string sIdUsuario = grdRoles.DataKeys[index].Value.ToString();

            if (e.CommandName.Equals("EditRol"))
            {

                lstRolesXAplicacion = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
                item = lstRolesXAplicacion[index];
                item.RowIndex = index.ToString();
                SetPermiso(item);
            }
            else if (e.CommandName.Equals("DeleteRol"))
            {
                lstRolesXAplicacion = (List<RolesXUsuarioBE>)ViewState["lstRolesXUSuario"];
                item = lstRolesXAplicacion[index];

                if (item.IDROLXUSUARIO.ToString() != "0")
                {
                    Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                    oMensajeWUC.SetMensaje("No puede eliminar domicilio existentes.", 2, "mdlMensaje");
                    RegisterGridpaging();
                    RegisterExternarScripts();
                    return;
                }

                lstRolesXAplicacion.RemoveAt(index);
                SetGrid(lstRolesXAplicacion, true);
            }

            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void btnCancelarPermiso_Click(object sender, EventArgs e)
        {
            ClearPermiso();
            RegisterGridpaging();
            RegisterExternarScripts();
        }


        private void RegisterExternarScripts()
        {
            Usuarios.UserControls.DomicilioWUC oDomicilioWUC = this.Parent.FindControl("DomicilioWUC") as Usuarios.UserControls.DomicilioWUC;
            if (oDomicilioWUC != null)
                oDomicilioWUC.RegisterGridpaging();

            Usuarios.UserControls.UserWUC oUserWUC = this.Parent.FindControl("UserWUC") as Usuarios.UserControls.UserWUC;
            if (oUserWUC != null)
                oUserWUC.RegisterFileUpload();

            Usuarios.UserControls.ContactoWUC oContactoWUC = this.Parent.FindControl("ContactoWUC") as Usuarios.UserControls.ContactoWUC;
            if (oContactoWUC != null)
                oContactoWUC.RegisterGridpaging();


        }
    }
}