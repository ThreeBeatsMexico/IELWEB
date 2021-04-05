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
    public partial class Recibos : System.Web.UI.Page
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
                            AbrirRecibo(base.ViewState["sIDAlumno"].ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void AbrirRecibo(string sMatricula)
        {
            AlumnosBus alumnosBus;
            ReciboRpt reciboRpt;
            DataSet dataSet;
            alumnosBus = new AlumnosBus();
            reciboRpt = new ReciboRpt();
            dataSet = new DataSet();
            try
            {
                dataSet = alumnosBus.ObtieneRecibo(sMatricula);
                reciboRpt.SetDataSource(dataSet);
                reciboRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, base.Response, false, "Recibo");
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
            ViewState["sIDAlumno"] = string.Empty;


        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDMatricula = Elemento.Element("IDAlumno").Value

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sNumeroMatricula"] = Elemento.IDMatricula;

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