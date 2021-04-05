using IELBUS.Common;
using IELBUS.Security;
using IELBUS.User;
using IELENT.Common;
using IELENT.Security;
using IELENT.User;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELWEB.Roles
{
    public partial class RolesLista : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
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
                        CargaApps();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oCommonServiceClient = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            Respuesta = oCommonServiceClient.GetCatEspecifico(sIdCatalogo, sValorFiltro);

            List<CatalogosBE> lstDdl = new List<CatalogosBE>();
            CatalogosBE item = new CatalogosBE();

            item.ID = "";
            item.DESCRIPCION = "Seleccione Opción..";

            lstDdl.Add(item);
            lstDdl.AddRange(Respuesta.lstCatalogo);

            ddl.DataSource = lstDdl;
            ddl.DataValueField = "ID";
            ddl.DataTextField = "DESCRIPCION";

            ddl.DataBind();
        }



        public void CargaApps()
        {
            SetDdlCatalogos(ddlApps, "13");
        }
        public void CargaRoles(string idApp)
        {
            ddlRoles.Items.Clear();
            UsersBR userSecurity = new UsersBR();
            ReglasBE item = new ReglasBE();
            List<RolesBE> oRoles = new List<RolesBE>();
            item.IDAPP = long.Parse(idApp);

            oRoles = userSecurity.getRolesXApp(item, long.Parse(ResIEL.IdApp));

            List<RolesBE> oAplicacionesLista = new List<RolesBE>();
            oAplicacionesLista = oRoles;
            ddlRoles.Items.Add(new ListItem() { Text = "Selecciona un Rol ...", Value = "" });
            ddlRoles.AppendDataBoundItems = true;
            ddlRoles.DataSource = oAplicacionesLista;
            ddlRoles.DataValueField = "IDROL";
            ddlRoles.DataTextField = "DESCRIPCION";
            ddlRoles.DataBind();

        }
        public void CargaGridMenu(string idRol, string idApp)
        {
            SecurityBR security = new SecurityBR();
            List<PermisosXMenuBE> oPermisos = new List<PermisosXMenuBE>();


            oPermisos = security.getMenuXAppRolAdmin(long.Parse(idRol), long.Parse(idApp));
            List<PermisosXMenuBE> oMenuLista = new List<PermisosXMenuBE>();
            oMenuLista = oPermisos;
            gvMenu.DataSource = oMenuLista;
            gvMenu.DataBind();
            CargaSiempre();




        }

        public void CargaGridObjetos(string idRol, string idApp)
        {




        }


        //public void getAplicacion(string idApp)
        //{
        //    SECURITYWCF.SecurityServiceClient seguridad = new SecurityServiceClient();
        //    SECURITYWCF.SecutityDC resSeguridad = new SecutityDC();
        //    SECURITYWCF.SecutityDC ResDesencriptaPass = new SECURITYWCF.SecutityDC();
        //    resSeguridad = seguridad.getAplicaciones(idApp, idApp, long.Parse(ResIEL.IdApp), ResIEL.Password);
        //    ResDesencriptaPass = seguridad.encryptDesEncrypt(resSeguridad.Aplicaciones[0].PASSWORD.ToString(), 2, long.Parse(ResIEL.IdApp), ResIEL.Password);
        //    // txtPassword.Text = ResDesencriptaPass.Encriptacion.VALOROUT.ToString();
        //    // txtDescripcion.Text = resSeguridad.Aplicaciones[0].DESCRIPCION.ToString();
        //    // lblIDAplicacion.Text = resSeguridad.Aplicaciones[0].IDAPLICACION.ToString();
        //    // txtDescripcion.Text = resSeguridad.Aplicaciones[0].DESCRIPCION.ToString();
        //    // txtPassword.Attributes.Add("value", ResDesencriptaPass.Encriptacion.VALOROUT.ToString());
        //    //txtPassword.Text = ResDesencriptaPass.Encriptacion.VALOROUT.ToString();
        //    //  DetailsView1.DataSource = resSeguridad.Aplicaciones;
        //    //  DetailsView1.DataBind();

        //}


        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);

            //CatGeneralesBE item = new CatGeneralesBE();

            //string sIdCatalogo = gvMenu.DataKeys[index].Value.ToString();



            if (e.CommandName.Equals("EditMenu"))
            {
                string sIdMenu = string.Empty;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMenu.Rows[index];
                sIdMenu = gvMenu.DataKeys[index].Value.ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlMenu').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlCatalogoScript", sb.ToString(), false);
                PermisosXMenuBE itemMenu = new PermisosXMenuBE();
                itemMenu.IDPERMISOSMENU = long.Parse(sIdMenu);
                itemMenu.NOMBREMENU = row.Cells[4].Text;
                itemMenu.TIPOOBJETO = row.Cells[5].Text;
                itemMenu.URL = row.Cells[6].Text;
                itemMenu.IMAGEN = row.Cells[7].Text;
                itemMenu.ORDENMENU = Convert.ToInt32(row.Cells[8].Text);
                itemMenu.TOOLTIP = row.Cells[9].Text;
                itemMenu.ACTIVO = Convert.ToBoolean(row.Cells[10].Text);
                AddMenuWUC.SetMenuInfo(itemMenu);
                //CatGeneralesWUC.SetDdlCatalogos(2);
                //GetCatGenerales(sIdCatalogo);

                sMensajelbl.Append(" EDITAR MENU ");


                lblTituloModal.Text = sMensajelbl.ToString();
            }
            else if (e.CommandName.Equals("AddSubMenu"))
            {
                string sIdMenu = string.Empty;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvMenu.Rows[index];
                sIdMenu = gvMenu.DataKeys[index].Value.ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('");
                sb.Append("#mdlSubMenu");
                sb.Append("').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
                AddSubMenuWUC.ClearSubMenuItem();
                PermisosXSubmenuBE itemSubMenu = new PermisosXSubmenuBE();
                itemSubMenu.IDPERMISOSMENU = long.Parse(sIdMenu);
                AddSubMenuWUC.SetSubMenuInfo(itemSubMenu);
                RegisterGridpaging(gvMenu);
                lblSubMenuTitle.Text = " AGREGAR ELEMENTO AL MENÚ: " + row.Cells[4].Text; 
            }


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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Propiedades", sQuery.ToString(), true);
            }
        }

        private void CargaSiempre()
        {
            RegisterGridpaging(gvMenu);
        }


        protected void ddlApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlApps.SelectedValue.ToString() != "")
            {
                SetDdlCatalogos(ddlRoles, "14", ddlApps.SelectedValue.ToString());
                pnlGrids.Attributes.Add("Style", "display:none");
                // CargaRoles(ddlApps.SelectedValue.ToString());
                //CargaGrid(ddlApps.SelectedValue.ToString());
            }
           
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoles.SelectedValue.ToString() != "")
            {
                StringBuilder txtLabel = new StringBuilder();
                txtLabel.Append(" APP -> ");
                txtLabel.Append(ddlApps.SelectedItem.Text);
                txtLabel.Append(" ROL ->");
                txtLabel.Append(ddlRoles.SelectedItem.Text);
                lblTitulo.Text = txtLabel.ToString();
                CargaGridMenu(ddlRoles.SelectedValue.ToString(), ddlApps.SelectedValue.ToString());
                CargaGridObjetos(ddlRoles.SelectedValue.ToString(), ddlApps.SelectedValue.ToString());
                pnlGrids.Attributes.Add("Style", "display:block");
                RegisterGridpaging(gvMenu);
            }
            else
            {
                pnlGrids.Attributes.Add("Style", "display:none");
            }

        }

        protected void btnAgregaRol_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('");
            sb.Append("#mdlAddRol");
            sb.Append("').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
            RegisterGridpaging(gvMenu);

        }




        protected void gvMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string IDPERMISOSMENU = gvMenu.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvSubMenu = e.Row.FindControl("gvSubMenu") as GridView;
                SecurityBR security = new SecurityBR();
              

                List<PermisosXSubmenuBE> oListaSubMenu = new List<PermisosXSubmenuBE>();
                oListaSubMenu = security.getSubMenuXIdMenu(long.Parse(IDPERMISOSMENU), long.Parse(ResIEL.IdApp));
               

                gvSubMenu.DataSource = oListaSubMenu;
                gvSubMenu.DataBind();
            }
        }


        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('");
            sb.Append("#mdlMenu");
            sb.Append("').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

            AddMenuWUC.ClearMenuItem();
            RegisterGridpaging(gvMenu);
            lblTituloModal.Text = " AGREGAR MENÚ";

        }


        protected void btnSaveRol_Click(object sender, EventArgs e)
        {
            SecurityBR security = new SecurityBR();
            bool x;
            x = security.addRolxApp(txtNombreRol.Text, long.Parse(ddlApps.SelectedValue));
            SetDdlCatalogos(ddlRoles, "14", ddlApps.SelectedValue.ToString());
            //lblMensajeOk.Text = "Se agregó un nuevo Rol . . ";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Se agrego un nuevo rol..');");
            sb.Append("$('#mdlAddRol').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
        }

        protected void btnSaveAddMenu_Click(object sender, EventArgs e)
        {
            SecurityBR security = new SecurityBR();
           
            PermisosXMenuBE item = new PermisosXMenuBE();
            bool menu;
            item = AddMenuWUC.GetMenuItem(long.Parse(ddlRoles.SelectedValue));
            if (item.IDPERMISOSMENU != 0)
            {

                menu = security.updMenuxAppRol(item.IDPERMISOSMENU, item.NOMBREMENU, item.IMAGEN, item.TIPOOBJETO, item.URL, item.TOOLTIP, item.ORDENMENU, item.ACTIVO, Convert.ToString(ResIEL.IdApp));
            }
            else
            {
                menu = security.addMenuxAppRol(item.IDROL, long.Parse(ddlApps.SelectedValue), item.NOMBREMENU, item.IMAGEN, item.TIPOOBJETO, item.URL, item.TOOLTIP, item.ORDENMENU);
            }
            CargaGridMenu(ddlRoles.SelectedValue.ToString(), ddlApps.SelectedValue.ToString());
            RegisterGridpaging(gvMenu);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Se guardo el registro');");
            sb.Append("$('#mdlMenu').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);


        }

        protected void btnSaveAddSubMenu_Click(object sender, EventArgs e)
        {

            SecurityBR security = new SecurityBR();
            bool Submenu;
            PermisosXSubmenuBE item = new PermisosXSubmenuBE();
            item = AddSubMenuWUC.GetSubMenuItem();
            if (item.IDPERMISOSXSUBMENU != 0)
            {
                Submenu = security.updSubMenuxAppRol(item.IDPERMISOSMENU, item.IDPERMISOSXSUBMENU, item.NOMBRESUBMENU, item.IMAGEN, item.TIPOOBJETO, item.URL, item.TOOLTIP, item.ORDENSUBMENU, item.ACTIVO, Convert.ToString(ResIEL.IdApp));
            }
            else
            {
                Submenu = security.addSubMenuxAppRol(item.IDPERMISOSMENU, item.NOMBRESUBMENU, item.IMAGEN, item.TIPOOBJETO, item.URL, item.TOOLTIP, item.ORDENSUBMENU);
            }
            CargaGridMenu(ddlRoles.SelectedValue.ToString(), ddlApps.SelectedValue.ToString());
            RegisterGridpaging(gvMenu);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("alert('Se guardo el registro');");
            sb.Append("$('#mdlSubMenu').modal('hide');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);

        }

        protected void gvSubMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            GridView gvTemp = (GridView)sender;
            
            
            CargaSiempre();
           // string sIndice = hdIndice.Value.ToString().Replace("ContenidoPagina_gvMenu_imgPlus_", "");
            //int indice = Convert.ToInt32(sIndice);
            
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            if (e.CommandName.Equals("EditSubMenu"))
            {
               
                //GridView GridSubMenu = (GridView)gvMenu.Rows[indice].FindControl("gvSubMenu");
                GridView GridSubMenu = (GridView)sender;
            

                string sIdSubMenu = string.Empty , sIdMenu;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridSubMenu.Rows[index];
                sIdSubMenu = GridSubMenu.DataKeys[index].Values[0].ToString();
                sIdMenu = GridSubMenu.DataKeys[index].Values[1].ToString();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlSubMenu').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlCatalogoScript", sb.ToString(), false);
                PermisosXSubmenuBE itemSubMenu = new PermisosXSubmenuBE();
                itemSubMenu.IDPERMISOSXSUBMENU = long.Parse(sIdSubMenu);
                itemSubMenu.IDPERMISOSMENU = long.Parse(sIdMenu);
                itemSubMenu.NOMBRESUBMENU = row.Cells[3].Text;
                itemSubMenu.TIPOOBJETO = row.Cells[4].Text;
                itemSubMenu.URL = row.Cells[5].Text;
                itemSubMenu.IMAGEN = row.Cells[6].Text;
                itemSubMenu.ORDENSUBMENU = Convert.ToInt32(row.Cells[7].Text);
                itemSubMenu.TOOLTIP = row.Cells[8].Text;
                itemSubMenu.ACTIVO = Convert.ToBoolean(row.Cells[9].Text);
                AddSubMenuWUC.SetSubMenuInfo(itemSubMenu);
               // CatGeneralesWUC.SetDdlCatalogos(2);
               // GetCatGenerales(sIdCatalogo);

                sMensajelbl.Append(" EDITAR SUBMENU ");


                lblTituloModal.Text = sMensajelbl.ToString();
               
            }

        }

       

    }
}