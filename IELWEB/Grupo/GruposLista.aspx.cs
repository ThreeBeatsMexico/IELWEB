using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using IELENT;
using IELBUS;
using System.Text;
using Telerik.Web.UI;

namespace IELWEB.Grupo
{
    public partial class GruposLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
            manager.AjaxRequest += new RadAjaxControl.AjaxRequestDelegate(manager_AjaxRequest);
         
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
        protected void manager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "RG")
            {
                Response.Redirect(Request.RawUrl);
            }
        } 
        void ReadData()
        {
            try
            {
                List<GrupoEnt> oGrupos = new List<GrupoEnt>();
                GruposBus oGruposBus = new GruposBus();

                oGrupos = oGruposBus.ListaGrupos();
                RadGrid1.DataSource = oGrupos;
                RadGrid1.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }


        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIdGrupo"] = string.Empty;
        }



        private string EncriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenGate = new TokenBus();
            sRespuesta = oTokenGate.EncriptaToken(sCadena);
            return sRespuesta;
        }

        private string DesencriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenGate = new TokenBus();
            sRespuesta = oTokenGate.DesencriptaToken(sCadena);
            return sRespuesta;
        }

        private string CreaTokenPost()
        {
            string sRespuesta = string.Empty;
            sRespuesta = EncriptaToken(TokenPostXML());
            return sRespuesta;
        }

        private string TokenPostXML()
        {
            string sRespuesta = string.Empty;

            StringBuilder sXML = new StringBuilder();

            sXML.Append("<APP>");
            sXML.Append("<IDGrupo>" + ViewState["sIdGrupo"].ToString() + "</IDGrupo>");
            sXML.Append("<IDGrado>" + ViewState["sIdGrado"].ToString() + "</IDGrado>");
            sXML.Append("<Grado>" + ViewState["sGrado"].ToString() + "</Grado>");
            sXML.Append("<Grupo>" + ViewState["sGrupo"].ToString() + "</Grupo>");
            sXML.Append("<IDCiclo>" + ViewState["sIDCiclo"].ToString() + "</IDCiclo>");

            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Grupo.aspx");
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                GruposBus oGrupoBus = new GruposBus();
                GridDataItem item = (GridDataItem)e.Item;
                
                

                if (e.CommandName == "VerAlumnos")
                {
                    ViewState["sIdGrado"] = item.GetDataKeyValue("psIDGrado").ToString();
                    ViewState["sGrado"] = item.GetDataKeyValue("psGrado").ToString();
                    ViewState["sGrupo"] = item.GetDataKeyValue("psNombreGrupo").ToString();
                    ViewState["sIdGrupo"] = item.GetDataKeyValue("psIdGrupo").ToString();
                    ViewState["sIDCiclo"] = item.GetDataKeyValue("psIDCiclo").ToString();
                   // RadAjaxManager.GetCurrent(Page.Master.).ResponseScripts.Add(@"openWin('AlumnosGrupo.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");
                    Response.Redirect("AlumnosGrupo.aspx?Token=" + CreaTokenPost());
                }
                if (e.CommandName == "EditaGrupo")
                {

                    Response.Redirect("Grupo.aspx?Token=" + CreaTokenPost());
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction",
                    //                                      "setTabStrip('COTIZADOR','../COTIZADOR/Cotizador.aspx','" + CreaTokenPost() + "');", true);
                }
                if (e.CommandName == "EliminaGrupo")
                {

                    if (oGrupoBus.EliminaGrupo(ViewState["sIdGrupo"].ToString()) == "1")
                   { RadWindowManager1.RadAlert("El Grupo se ha eliminado", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/accept.png"); }
                   else
                   { RadWindowManager1.RadAlert("No se pudo Eliminar el Grupo", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/block.png"); }
                    
                    //  RadAjaxManager1.ResponseScripts.Add(@"openWin('../REPORTES/CotizacionRpt.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");

                    // RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");
                    //  RadAjaxManager1.ResponseScripts.Add(@"openPrint('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            ReadData();
        }

        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            ReadData();
        }

        protected void RadGrid1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            ReadData();
        }

    
    }
}