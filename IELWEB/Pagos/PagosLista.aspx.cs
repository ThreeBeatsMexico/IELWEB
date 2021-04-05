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
using System.Xml.Linq;
using System.Text;
using System.Drawing;

namespace IELWEB.Pagos
{
    public partial class PagosLista : System.Web.UI.Page
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
                        VariablesViewState();
                        RequestQueryString();
                        string sToken = string.Empty;
                        sToken = DesencriptaToken(ViewState["Token"].ToString());
                        int iRespuestaValidaToken = 0;
                        iRespuestaValidaToken = ValidaToken(sToken);
                        CargaGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                // lblMessage.Text = ex.Message;
            }
        }
        void CargaGrid()
        {
            try
            {
                List<PagosEnt> oPagos = new List<PagosEnt>();
                PagosBus oPagosBus = new PagosBus();
                AlumnosBus oAlumnosBus = new AlumnosBus();
                AlumnoEnt oAlumnoEnt = new AlumnoEnt();
                oPagos = oPagosBus.ListaPagosAlumnoMatricula(ViewState["sMatricula"].ToString());
                RadGrid1.DataSource = oPagos;
                RadGrid1.DataBind();
                oAlumnoEnt = oAlumnosBus.ObtieneInfoAlumnoBus(ViewState["sMatricula"].ToString());
                ViewState["sIDAlumno"] = oAlumnoEnt.sIdAlumno;
                ViewState["sIDPago"] = "0";
                lblAlumnoInfo.Text = oAlumnoEnt.sAPaterno + " " + oAlumnoEnt.sAMaterno + " " + oAlumnoEnt.sNombres + " - [ " + oAlumnoEnt.sGrado + " " + oAlumnoEnt.sGrupo + " ]"; 

            }
            catch (Exception ex)
            {
                // lblMessage.Text = ex.Message;
            }
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                GridDataItem item = (GridDataItem)e.Item;
                ViewState["sIDAlumno"] = item.GetDataKeyValue("psIDAlumno").ToString();
                ViewState["sIDPago"] = item.GetDataKeyValue("psIDPago").ToString();

                if (e.CommandName == "RegistrarPago")
                {
                    RadAjaxManager1.ResponseScripts.Add(@"openWin('RegistraPago.aspx','" + CreaTokenPost() + "','REGISTRAR PAGO','RadWindowPago');");
                  
                    //Response.Redirect("Alumno.aspx?Token=" + CreaTokenPost());
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction",
                    //                                      "setTabStrip('COTIZADOR','../COTIZADOR/Cotizador.aspx','" + CreaTokenPost() + "');", true);
                }
                if (e.CommandName == "VerFicha")
                {
                    //  RadAjaxManager1.ResponseScripts.Add(@"openWin('../REPORTES/CotizacionRpt.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");

                    RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");
                    //  RadAjaxManager1.ResponseScripts.Add(@"openPrint('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            CargaGrid();
        }

        protected void RadGrid1_PageSizeChanged(object sender, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
        {
            CargaGrid();
        }

        protected void RadGrid1_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            CargaGrid();
        }

        private void RequestQueryString()
        {
            ViewState["Token"] = String.IsNullOrEmpty(Request.QueryString["Token"]) ? string.Empty : Request.QueryString["Token"];
        }


        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIdAlumno"] = string.Empty;
        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              Matricula = Elemento.Element("Matricula").Value
                              

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sMatricula"] = Elemento.Matricula;
                
            }
            iRespuesta = 1;
            return iRespuesta;
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
            sXML.Append("<IDAlumno>" + ViewState["sIDAlumno"].ToString() + "</IDAlumno>");
            sXML.Append("<IDPago>" + ViewState["sIDPago"].ToString() + "</IDPago>");

            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/Recibos.aspx','" + CreaTokenPost() + "','IMPRIME RECIBO','RadWindow2');");
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
           if (e.Item is GridDataItem && e.Item.OwnerTableView.Name == "Master")
            {
                GridDataItem item = e.Item as GridDataItem;
                if (item.GetDataKeyValue("psEstado").ToString() == "PAGADO")
                {
                    item["ESTATUS"].ForeColor = Color.Green; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightGreen; // for whole row
                    item["RegistraPago"].Enabled = false;
                }
                else if (item.GetDataKeyValue("psEstado").ToString() == "ABONADO")
                {
                    item["ESTATUS"].ForeColor = Color.Purple; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
                }
                else if (item.GetDataKeyValue("psEstado").ToString() == "SIN PAGAR")
                {
                    item["ESTATUS"].ForeColor = Color.Red; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightCoral; // for whole row
                }

            }

        }

        protected void RadGrid1_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            //GridDataItem parentItem = e.DetailTableView.ParentItem as GridDataItem;

            GridDataItem parentItem = (GridDataItem)e.DetailTableView.ParentItem;
            switch (e.DetailTableView.Name)
            {
                case "Pagos":
                    {
                        string psIDPago = parentItem.GetDataKeyValue("psIDPago").ToString();
                        string psIDAlumno = parentItem.GetDataKeyValue("psIDAlumno").ToString();
                        List<TransaccionEnt> oListaTransaccion = new List<TransaccionEnt>();
                        PagosBus oConsultaTransaccionesPago = new PagosBus();
                        oListaTransaccion = oConsultaTransaccionesPago.ConsultaTransaccionesPago(psIDPago, psIDAlumno);
                        e.DetailTableView.DataSource = oListaTransaccion;
                        break;

                    }

            }


        }

        protected void manager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument == "RG")
            {
                Response.Redirect(Request.RawUrl);
            }
        }

       
    }
}