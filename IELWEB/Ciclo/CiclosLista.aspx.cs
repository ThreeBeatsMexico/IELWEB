using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using IELENT;
using IELBUS;
using System.Text;


namespace IELWEB.Ciclo
{
    public partial class CiclosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        void ReadData()
        {
            try
            {
                List<CicloEnt> oCiclos = new List<CicloEnt>();
                CiclosBus oUsuariosBus = new CiclosBus();

                oCiclos = oUsuariosBus.ListaCiclos();
                
                RadGrid1.DataSource = oCiclos;
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
            ViewState["sIdCiclo"] = string.Empty;
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
            sXML.Append("<IDCiclo>" + ViewState["sIdCiclo"].ToString() + "</IDCiclo>");

            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["sIdCiclo"] = "0";
            Response.Redirect("Ciclo.aspx?Token=" + CreaTokenPost());
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                GridDataItem item = (GridDataItem)e.Item;
                ViewState["sIdCiclo"] = item.GetDataKeyValue("psIdCiclo").ToString();

                if (e.CommandName == "EditaCiclo")
                {

                    Response.Redirect("Ciclo.aspx?Token=" + CreaTokenPost());
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction",
                    //                                      "setTabStrip('COTIZADOR','../COTIZADOR/Cotizador.aspx','" + CreaTokenPost() + "');", true);
                }
                if (e.CommandName == "VerFicha")
                {
                    //  RadAjaxManager1.ResponseScripts.Add(@"openWin('../REPORTES/CotizacionRpt.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");

                   // RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");
                    //  RadAjaxManager1.ResponseScripts.Add(@"openPrint('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");


                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}