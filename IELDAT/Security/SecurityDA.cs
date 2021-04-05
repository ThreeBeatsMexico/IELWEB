using IELENT.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IELDAT.LinQ;
using System.Diagnostics;
using System.Reflection;
using IELDAT.Common;
using IELENT.Common;
using System.Data.Common;

namespace IELDAT.Security
{
    public class SecurityDA
    {
        public AplicacionBE checkPermisoXAplicacion(Int64 App, string sPasswordApp)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            AplicacionBE PermisosXApp = new AplicacionBE();
            try
            {
                var lnqConsulta = dboSegLatino.sp_getPermisoXApp(App);

                foreach (var a in lnqConsulta)
                {
                    PermisosXApp.IDAPLICACION = a.IDAPLICACION;
                    PermisosXApp.DESCRIPCION = a.DESCRIPCION;
                    PermisosXApp.PASSWORD = a.PASSWORD;
                    PermisosXApp.ACTIVO = a.ACTIVO == null ? false : Boolean.Parse(a.ACTIVO.ToString());
                }
                return PermisosXApp;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<WCFMetodosBE> checkMetodoXApp(Int64 App, string sServiceName, string sMethodName)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<WCFMetodosBE> MetodosXApp = new List<WCFMetodosBE>();
            try
            {
                var lnqConsulta = dboSegLatino.sp_getMetodoXApp(App, sServiceName, sMethodName);
                foreach (var a in lnqConsulta)
                {
                    WCFMetodosBE MetodosBE = new WCFMetodosBE();
                    MetodosBE.IDMETODOS = a.IDMETODOS;
                    MetodosBE.IDAPLICACION = a.IDAPLICACION ?? 0;
                    MetodosBE.IDSERVICIOS = a.IDSERVICIOS ?? 0;
                    MetodosBE.NOMBREMETODO = a.NOMBREMETODO;
                    MetodosBE.RECURRENTE = a.RECURRENTE ?? false;
                    MetodosBE.ACTIVO = a.ACTIVO ?? false;
                    MetodosXApp.Add(MetodosBE);
                }
                return MetodosXApp;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisoXObjetosBE> getObjetosXAppRolPage(long Rol, string Pagina, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisoXObjetosBE> PermisoXObjetos = new List<PermisoXObjetosBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getObjetosXAppRolPage(App, Rol, Pagina);
                foreach (var a in lnqConsulta)
                {
                    PermisoXObjetosBE Permiso = new PermisoXObjetosBE();
                    Permiso.IDPERMISOSOBJ = a.IDPERMISOSOBJ;
                    Permiso.IDROL = a.IDROL ?? 0;
                    Permiso.PAGINA = a.PAGINA;
                    Permiso.NOMBREOBJETO = a.NOMBREOBJETO;
                    Permiso.TIPOOBJETO = a.TIPOOBJETO;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    PermisoXObjetos.Add(Permiso);
                }
                return PermisoXObjetos;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisoXElementosObjBE> getElementsObjectsXIdObj(long IdPermisosXObj, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisoXElementosObjBE> PermisoXElementosObj = new List<PermisoXElementosObjBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getElementsObjectsXIdObj(IdPermisosXObj);
                foreach (var a in lnqConsulta)
                {
                    PermisoXElementosObjBE Permiso = new PermisoXElementosObjBE();
                    Permiso.IDELEMENTOSXOBJ = a.IDELEMENTOSXOBJ;
                    Permiso.IDPERMISOSOBJ = a.IDPERMISOSOBJ ?? 0;
                    Permiso.ELEMENTO = a.ELEMENTO;
                    Permiso.TOOLTIP = a.TOOLTIP;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    PermisoXElementosObj.Add(Permiso);
                }
                return PermisoXElementosObj;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXMenuBE> getMenuXAppRol(long Rol, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getMenusXAppRol(App, Rol);
                foreach (var a in lnqConsulta)
                {
                    PermisosXMenuBE Permiso = new PermisosXMenuBE();
                    Permiso.IDPERMISOSMENU = a.IDPERMISOSMENU;
                    Permiso.IDROL = a.IDROL ?? 0;
                    Permiso.NOMBREMENU = a.NOMBREMENU;
                    Permiso.IMAGEN = a.IMAGEN;
                    Permiso.TIPOOBJETO = a.TIPOOBJETO;
                    Permiso.URL = a.URL;
                    Permiso.TOOLTIP = a.TOOLTIP;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    Permiso.ORDENMENU =  a.ORDEN ?? 0;
                    PermisosXMenu.Add(Permiso);
                }
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXMenuBE> getMenuXAppRolAdmin(long Rol, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisosXMenuBE> PermisosXMenu = new List<PermisosXMenuBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getMenusXAppRolAdmin(App, Rol);
                foreach (var a in lnqConsulta)
                {
                    PermisosXMenuBE Permiso = new PermisosXMenuBE();
                    Permiso.IDPERMISOSMENU = a.IDPERMISOSMENU;
                    Permiso.IDROL = a.IDROL ?? 0;
                    Permiso.NOMBREMENU = a.NOMBREMENU;
                    Permiso.IMAGEN = a.IMAGEN;
                    Permiso.TIPOOBJETO = a.TIPOOBJETO;
                    Permiso.URL = a.URL;
                    Permiso.TOOLTIP = a.TOOLTIP;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    Permiso.ORDENMENU = a.ORDEN ?? 0;
                    PermisosXMenu.Add(Permiso);
                }
                return PermisosXMenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXSubmenuBE> getSubMenuXIdMenu(long IdPermisoMenu, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisosXSubmenuBE> PermisosXSubmenu = new List<PermisosXSubmenuBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getSubMenusXIdMenu(IdPermisoMenu);
                foreach (var a in lnqConsulta)
                {
                    PermisosXSubmenuBE Permiso = new PermisosXSubmenuBE();
                    Permiso.IDPERMISOSXSUBMENU = a.IDPERMISOSXSUBMENU;
                    Permiso.IDPERMISOSMENU = a.IDPERMISOSMENU ?? 0;
                    Permiso.NOMBRESUBMENU = a.NOMBRESUBMENU;
                    Permiso.IMAGEN = a.IMAGEN;
                    Permiso.TIPOOBJETO = a.TIPOOBJETO;
                    Permiso.URL = a.URL;
                    Permiso.TOOLTIP = a.TOOLTIP;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    Permiso.ORDENSUBMENU = a.ORDEN ?? 0;
                    PermisosXSubmenu.Add(Permiso);
                }
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<PermisosXSubmenuBE> getSubMenuXIdMenuAdmin(long IdPermisoMenu, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<PermisosXSubmenuBE> PermisosXSubmenu = new List<PermisosXSubmenuBE>();
            try
            {

                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getSubMenusXIdMenuAdmin(IdPermisoMenu);
                foreach (var a in lnqConsulta)
                {
                    PermisosXSubmenuBE Permiso = new PermisosXSubmenuBE();
                    Permiso.IDPERMISOSXSUBMENU = a.IDPERMISOSXSUBMENU;
                    Permiso.IDPERMISOSMENU = a.IDPERMISOSMENU ?? 0;
                    Permiso.NOMBRESUBMENU = a.NOMBRESUBMENU;
                    Permiso.IMAGEN = a.IMAGEN;
                    Permiso.TIPOOBJETO = a.TIPOOBJETO;
                    Permiso.URL = a.URL;
                    Permiso.TOOLTIP = a.TOOLTIP;
                    Permiso.ACTIVO = a.ACTIVO ?? false;
                    Permiso.ORDENSUBMENU = a.ORDEN ?? 0;
                    PermisosXSubmenu.Add(Permiso);
                }
                return PermisosXSubmenu;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public List<AplicacionBE> getAplicaciones(string idAplicacion, string txtBusqueda, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            List<AplicacionBE> Aplicaciones = new List<AplicacionBE>();
            try
            {
                Int64 iApp = App;
                var lnqConsulta = dboSegLatino.sp_getAplicaciones(idAplicacion, txtBusqueda);
                foreach (var a in lnqConsulta)
                {
                    AplicacionBE Aplicacion = new AplicacionBE();
                    Aplicacion.IDAPLICACION = a.IDAPLICACION;
                    Aplicacion.DESCRIPCION = a.DESCRIPCION;
                    Aplicacion.PASSWORD = a.PASSWORD;
                    Aplicacion.ACTIVO = a.ACTIVO ?? false;
                    Aplicaciones.Add(Aplicacion);
                }
                return Aplicaciones;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool addAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insAplicacion(Aplicacion.DESCRIPCION, Aplicacion.PASSWORD, Aplicacion.ACTIVO);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool updAplicacion(AplicacionBE Aplicacion, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_updAplicacion(Aplicacion.IDAPLICACION,Aplicacion.DESCRIPCION, Aplicacion.PASSWORD, Aplicacion.ACTIVO);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st,"", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool updMenuxAppRol(Int64 idMenu,string Menu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_updMenuXAppRol(idMenu,Menu,Img,TpoObj,Url,Tool,Orden,Activo);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App);
                throw new Exception(ex.Message);
            }
        }
        public bool updSubMenuxAppRol(Int64 idPermisoMenu, Int64 IdPermisoSubmenu, string SumMenu, string Img, string TpoObj, string Url, string Tool, Int64 Orden, bool Activo, string App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_updSubMenuXAppRol(idPermisoMenu,IdPermisoSubmenu,SumMenu,Img,TpoObj,Url,Tool,Orden,Activo);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool addRolxApp(string Rol, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insRolXApp(Rol, App);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool addMetodo(List<WCFMetodosBE> lstMetodos, Int64 IdApp)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            DbTransaction scopeGrl;
            dboSegLatino.Connection.Open();
            scopeGrl = dboSegLatino.Connection.BeginTransaction();
            dboSegLatino.Transaction = scopeGrl;
            try
            {
                bool bFlag = true;
                foreach (var item in lstMetodos)
                {
                    dboSegLatino.sp_insMetodosxApp(item.IDMETODOS, item.IDAPLICACION, item.IDSERVICIOS, item.NOMBREMETODO, item.RECURRENTE, item.ACTIVO);
                }
                
                scopeGrl.Commit();

                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);
            }
            finally
            {
                scopeGrl.Dispose();
                dboSegLatino.Connection.Close();
                dboSegLatino.Connection.Dispose();
               
            }
        }
        public bool addServicio(string Servicio)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insServicioWCF(Servicio);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }
        public bool addSubMenuxAppRol(Int64 IdSubMenu, string SubMenu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insSubMenuXAppRol(IdSubMenu, SubMenu, Img, Obj, Url, Tool, Orden);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }
        public bool addMenuxAppRol(Int64 Rol, Int64 App,string Menu, string Img, string Obj, string Url, string Tool, Int64 Orden)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insMenuXAppRol(Rol, Menu, Img, Obj, Url, Tool, Orden);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }
        public bool addPermisosxObjeto(Int64 Rol, string Pagina, string Obj, string TipoObjeto, string Tool)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insPermisosxObjeto(Rol, Pagina,Obj,TipoObjeto,Tool);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }
        public bool addPermisosxElementoObjeto(Int64 PermisoObj, string Elemento, string Tool)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_insPermisosxElementoObjeto(PermisoObj, Elemento, Tool);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);
            }
        }

        public bool delMenu(Int64 idMenu, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_delMenusXAppRol(idMenu);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool delSubMenu(Int64 idSubMenu, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            try
            {
                bool bFlag = true;
                dboSegLatino.sp_delSubMenusXAppRol(idSubMenu);
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }
        public bool checkApp(string App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkXApp(App);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
              
            }

            return bFlag;
        } 


        public bool checkRol(string Rol, Int64 App)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkRolxApp(Rol, App);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }
        public bool checkMetodo(string Metodo, Int64 IdApp, Int64 Servicio)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkMetodo(Metodo,IdApp, Servicio);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }
        public bool checkServicio(string Servicio, Int64 IdApp)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkServicio(Servicio);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }
        public bool checkMenuxAppRol(string Menu, Int64 Rol, Int64 IdApp)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkMenuxAppRol(Menu, Rol);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", IdApp.ToString());
                throw new Exception(ex.Message);

            }

            return bFlag;
        }
        public bool checkSubMenuxAppRol(string SubMenu, Int64 PermisosMenu)
        {
            linqIELDataBaseDataContext dboSegLatino = new linqIELDataBaseDataContext();
            bool bFlag = false;
            try
            {
                var Cliente = dboSegLatino.sp_checkSubMenuxAppRol(SubMenu, PermisosMenu);
                if (Cliente.Count() > 0)
                {
                    foreach (var s in Cliente)
                    {
                        bFlag = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                CommonDA ComunDA = new CommonDA();
                ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", "");
                throw new Exception(ex.Message);

            }

            return bFlag;
        }
    }
}
