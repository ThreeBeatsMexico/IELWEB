using CrystalDecisions.Shared;
using IELBUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace IELWEB.Reportes
{
    public partial class Transacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadAsyncUpload1.FileUploaded += new Telerik.Web.UI.FileUploadedEventHandler(RadAsyncUpload1_FileUploaded);
            //RadButton1.Click += new EventHandler(RadButton1_Click);
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
                        if (iRespuestaValidaToken == 1)
                        {
                            AbrirFicha(base.ViewState["sFechaInicial"].ToString(), base.ViewState["sFechaFinal"].ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void AbrirFicha(string FechaInicial, string FechaFinal)
        {
            PagosBus pagosBus;
            PagosRpt pagosRpt;
            DataSet dataSet;
            pagosBus = new PagosBus();
            pagosRpt = new PagosRpt();
            dataSet = new DataSet();
            try
            {
                dataSet = pagosBus.ObtieneReportePagosRpt(FechaInicial, FechaFinal);
                pagosRpt.SetDataSource(dataSet);
                pagosRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, base.Response, false, "Reporte de Pagos");
            }
            catch
            {
            }
        }
        private void RequestQueryString()
        {
            ViewState["Token"] = String.IsNullOrEmpty(Request.QueryString["Token"]) ? string.Empty : Request.QueryString["Token"];
        }


        private void VariablesViewState()
        {
            ViewState["sFechaInicial"] = string.Empty;
            ViewState["sFechaFinal"] = string.Empty;


        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              FechaInicial = Elemento.Element("FechaInicial").Value,
                              FechaFinal = Elemento.Element("FechaFinal").Value

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sFechaInicial"] = Elemento.FechaInicial;
                ViewState["sFechaFinal"] = Elemento.FechaFinal;

            }

            iRespuesta = 1;

            return iRespuesta;
        }
        private string EncriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenBus = new TokenBus();

            sRespuesta = oTokenBus.EncriptaToken(sCadena);

            return sRespuesta;
        }


        private string DesencriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenBus = new TokenBus();

            sRespuesta = oTokenBus.DesencriptaToken(sCadena);

            return sRespuesta;
        }
    }
}