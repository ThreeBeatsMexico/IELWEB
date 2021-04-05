using IELBUS.Security;
using IELBUS.User;
using IELENT.Common;
using IELENT.Security;
using IELENT.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace IELWEB.Startup
{
    public partial class App : System.Web.UI.MasterPage
    {
        private Dictionary<string, HtmlGenericControl> ctrls = new Dictionary<string, HtmlGenericControl>();
        List<PermisosXMenuBE> oListaMenuxxxx = new List<PermisosXMenuBE>();
        protected void Page_Load(object sender, EventArgs e)
        {




            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            //Response.Cache.SetNoStore();

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
                        GetMenuData(itemSecurity.IDUSUARIOAPP);
                       // SetCurrentPage();
                    }
                }
                catch (Exception x)
                {

                }

            }

        }


        //private void SetCurrentPage()
        //{
        //    var pageName = Request.Url.AbsolutePath.Split('/').LastOrDefault();
        //    Control list = this.Page.Master.FindControl("dvMenuPrincipal");
        //    list.FindControl("MenuJC");
        //   // Control home = this.Page.Master.FindControl("MenuJC").FindControl(pageName);
        //    HtmlControl hola = (HtmlControl)this.Page.Master.FindControl("dvMenuPrincipal").FindControl("MenuJC");
        //    HtmlGenericControl home = (HtmlGenericControl)this.Page.Master.FindControl("MenuJC").FindControl("pageName");

        //    home.Attributes["class"] = "active";
            
          
        //}



    

        public void GetMenuData(string User)
        {
            ReglasBE reglas = new ReglasBE();
            List<PermisosXMenuBE> oListaMenu = new List<PermisosXMenuBE>();
            reglas.TIPOBUSQUEDA = 2;
            reglas.USUARIO = User;
            reglas.IDAPP = long.Parse(ResIEL.IdApp);
            DatosUsuarioBE UsrBE = new DatosUsuarioBE();
            UsersBR seguridad = new UsersBR();
            SecurityBR SecBR = new SecurityBR();
            UsrBE = seguridad.getUsuarioFull(reglas, long.Parse(ResIEL.IdApp));
            List<RolesBE> oRolesLst = new List<RolesBE>();
            oRolesLst = seguridad.getRolesXApp(reglas, long.Parse(ResIEL.IdApp));
            List<PermisosXMenuBE> oPermisosLst = new List<PermisosXMenuBE>();
            List<PermisosXSubmenuBE> oSubPermisosLst = new List<PermisosXSubmenuBE>();
            PermisosXMenuBE oPermisos = new PermisosXMenuBE();

            lblUserMenu2.Text = lblUserProfile.Text = lblUserMenu.Text = UsrBE.Usuario.NOMBRE + " " + UsrBE.Usuario.APATERNO;
            imgUserMenu.Src = UsrBE.Usuario.RUTAFOTOPERFIL.ToString();
            imgUserMenu2.Src = UsrBE.Usuario.RUTAFOTOPERFIL.ToString();
            imgUserProfile.Src = UsrBE.Usuario.RUTAFOTOPERFIL.ToString();
            lblUserProfile.Text = UsrBE.Usuario.DESCAREA.ToString();
            //PROGRAMAR SECCION PARA ELEGIR ROL EN ESTE CASO SOLO TOMA EL PRIMER ROL

            int Rol = Convert.ToInt32(UsrBE.RolesXUsuario[0].IDROL);
            lblRolMenu.Text = lblRolProfile.Text = UsrBE.RolesXUsuario[0].DESCROL.ToString();
            oPermisosLst = SecBR.getMenuXAppRol(Rol, long.Parse(ResIEL.IdApp));
            oListaMenu = oPermisosLst.OrderBy(x => x.ORDENMENU).ToList();
            oListaMenuxxxx = oListaMenu;
            StringBuilder objstr = new StringBuilder();
            var pageName = Request.Url.AbsolutePath.Split('/').LastOrDefault();



            try
            {

                if (oListaMenu.Count > 0)
                {
                    objstr.Append("<ul class='sidebar-menu'><li class='header'>MENÚ PRINCIPAL</li>");
                    string sMenuActual = string.Empty;
                    foreach (PermisosXMenuBE oitemMenu in oListaMenu)
                    {
                        var ItemParentName = oitemMenu.URL.Split('/').LastOrDefault();
                        if (ItemParentName.ToLower() == pageName.ToLower())
                        {
                            objstr.Append("<li id='" + oitemMenu.IDPERMISOSMENU + "' runat='server' Title='" + oitemMenu.TOOLTIP + "' class='treeview active'><a href='" + oitemMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemMenu.IMAGEN + "'></i><span>" + oitemMenu.NOMBREMENU + "</span><i class='fa fa-angle-left pull-right'></i></a>");
                        }
                        else
                        {
                            objstr.Append("<li id='" + oitemMenu.IDPERMISOSMENU + "' runat='server' Title='" + oitemMenu.TOOLTIP + "' class='treeview'><a href='" + oitemMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemMenu.IMAGEN + "'></i><span>" + oitemMenu.NOMBREMENU + "</span><i class='fa fa-angle-left pull-right'></i></a>");
                            sMenuActual = "<li id='" + oitemMenu.IDPERMISOSMENU + "' runat='server' Title='" + oitemMenu.TOOLTIP + "' class='treeview'><a href='" + oitemMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemMenu.IMAGEN + "'></i><span>" + oitemMenu.NOMBREMENU + "</span><i class='fa fa-angle-left pull-right'></i></a>";
                        }
                        if (!string.IsNullOrEmpty(oitemMenu.URL) && oitemMenu.URL == "#")
                        {
                            List<PermisosXSubmenuBE> oListaSubMenu = new List<PermisosXSubmenuBE>();

                            oListaSubMenu = SecBR.getSubMenuXIdMenu(oitemMenu.IDPERMISOSMENU, long.Parse(ResIEL.IdApp));
                        
                            objstr.Append(" <ul class='treeview-menu'>");
                            foreach (PermisosXSubmenuBE oitemSubMenu in oListaSubMenu)
                            {
                                var ItemName = oitemSubMenu.URL.Split('/').LastOrDefault();
                                if (ItemName == pageName)
                                {
                                    objstr = objstr.Replace(sMenuActual, sMenuActual.Replace("class='treeview'", "class='treeview active'"));
                                    objstr.Append("<li class='active' id='" + oitemSubMenu.NOMBRESUBMENU + "' Title='" + oitemSubMenu.TOOLTIP + "'><a href='" + oitemSubMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemSubMenu.IMAGEN + "'></i><span>" + oitemSubMenu.NOMBRESUBMENU + "</a></li>");
                                }
                                else
                                {
                                    objstr.Append("<li id='" + oitemSubMenu.NOMBRESUBMENU + "' Title='" + oitemSubMenu.TOOLTIP + "'><a href='" + oitemSubMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemSubMenu.IMAGEN + "'></i><span>" + oitemSubMenu.NOMBRESUBMENU + "</a></li>");
                                }

                            }
                            objstr.Append("</ul></i></a></li>");
                        }
                        else
                        {
                            objstr.Append("</li>");
                        }
                    }
                    objstr.Append("</ul>");
                    dvMenuPrincipal.InnerHtml = objstr.ToString();
                    dvMenuPrincipal.Visible = true;



                }
                else
                {
                    //NO ENCONTRO ELEMENTROS NO SE PUEDE ARMAR EL MENU
                }
            }
            catch (Exception oException)
            {
                Response.Write(oException.ToString()); //ES SOLO PARA TEST
            }
        }

    
        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Startup/Perfil.aspx");
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            //Session.Abandon();
            //FormsAuthentication.SignOut();
            Response.Redirect("../Startup/Salir.aspx");
        }

        private string CreaTokenPost()
        {
            string sRespuesta = string.Empty;
            SecurityBR SecBR = new SecurityBR();
            EncryptionBE oEncription = new EncryptionBE();
            oEncription = SecBR.encryptDesEncrypt(1, TokenPostXML(), long.Parse(ResIEL.IdApp));
            sRespuesta = oEncription.VALOROUT;
            return sRespuesta;
        }
        private string TokenPostXML()
        {
            string sRespuesta = string.Empty;
            StringBuilder sXML = new StringBuilder();
            sXML.Append("<APP>");
            //sXML.Append("<IDSistema>1000</IDSistema>");
            //sXML.Append("<IDAplicacion>100</IDAplicacion>");
            //sXML.Append("<IDUsuario>" + ViewState["sIDUsuario"].ToString() + "</IDUsuario>");
            //sXML.Append("<IDMiembro>" + ViewState["sIDMiembro"].ToString() + "</IDMiembro>");
            //sXML.Append("<IDRol>" + ViewState["sIDRol"].ToString() + "</IDRol>");
            //sXML.Append("<IDPerfil>" + ViewState["sIDPerfil"].ToString() + "</IDPerfil>");
            //sXML.Append("<IDEstacionOrigen>" + ViewState["sIDEstacionOrigen"].ToString() + "</IDEstacionOrigen>");
            //sXML.Append("<IDEstacionSeleccionada>" + ViewState["sIDEstacionOrigen"].ToString() + "</IDEstacionSeleccionada>");
            //sXML.Append("<IDEstacionSeleccionadaDDL>" + ddlEstacion.SelectedIndex + "</IDEstacionSeleccionadaDDL>");
            sXML.Append("</APP>");
            sRespuesta = sXML.ToString();
            return sRespuesta;
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Startup/Inicio.aspx");
        }

        private void setSelectedMenuItemClass()
        {
            string requestedFile = Path.GetFileName(Request.Path);
            if (!string.IsNullOrEmpty(requestedFile))
            {
                foreach (KeyValuePair<string, HtmlGenericControl> ctrl in ctrls)
                {
                    HtmlGenericControl aCtrl = ctrl.Value;
                    aCtrl.Attributes.Remove("class");
                }

                HtmlGenericControl selectedMenuItem;
                if (ctrls.TryGetValue(requestedFile, out selectedMenuItem))
                    selectedMenuItem.Attributes.Add("class", "active");
            }
        }

        //protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{

        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        if (oListaMenuxxxx != null)
        //        {
        //            UserSecurityServiceClient seguridad = new UserSecurityServiceClient();
        //            ReglasBE reglas = new ReglasBE();
        //            UsuarioDC resUsuario = new UsuarioDC();
        //            UsuarioDC resUsuarioRol = new UsuarioDC();
        //            SECURITYWCF.SecurityServiceClient SeguridadLatino = new SECURITYWCF.SecurityServiceClient();
        //            SECURITYWCF.SecutityDC oSecurity = new SECURITYWCF.SecutityDC();
        //            SECURITYWCF.PermisosXMenuBE drv = e.Item.DataItem as SECURITYWCF.PermisosXMenuBE;
        //            long ID = long.Parse(drv.IDPERMISOSMENU.ToString());
        //            List<SECURITYWCF.PermisosXSubmenuBE> oListaSubMenu = new List<SECURITYWCF.PermisosXSubmenuBE>();
        //            oSecurity = SeguridadLatino.getSubMenuXIdMenu(ID, long.Parse(ResIEL.IdApp), ResIEL.Password);
        //            oListaSubMenu = oSecurity.PermisosXSubmenu.ToList();
        //            StringBuilder objstr = new StringBuilder();
        //            objstr.Append(" <ul class='treeview-menu'>");
        //            foreach (SECURITYWCF.PermisosXSubmenuBE oitemSubMenu in oListaSubMenu)
        //            {
        //                objstr.Append("<li Title='" + oitemSubMenu.TOOLTIP + "'><a href='" + oitemSubMenu.URL + "?Token=" + CreaTokenPost() + "'><i class='" + oitemSubMenu.IMAGEN + "'></i><span>" + oitemSubMenu.NOMBRESUBMENU + "</a></li>");
        //            }
        //            objstr.Append("</ul></i></a></li>");
        //            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = objstr.ToString();
                  
        //        }
        //    }

        //}

      

       
            


    }
}