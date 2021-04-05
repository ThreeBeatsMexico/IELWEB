using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using IELENT;
using IELBUS;

namespace IELWEB.Pagos
{
    public partial class RegistraPago : System.Web.UI.Page
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
                        ReadData();
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

        }

        void ReadData()
        {
            try
            {
                DateTime factual = DateTime.Now;
                int dia = factual.Day;
                PagosEnt oPago = new PagosEnt();
                PagosBus oPagosBus = new PagosBus();

                oPago = oPagosBus.ObtienePago(ViewState["sIDPago"].ToString());
                string estatuspago = oPago.psEstado.ToString();
                if (estatuspago == "SIN PAGAR")
                {
                    if (dia > 10)
                    {
                        txtMonto.Text = (Convert.ToDouble(oPago.psMontoActual) * 1.1).ToString();
                    }
                    else
                    {
                        txtMonto.Text = oPago.psMontoActual;
                    }
                }
                else { txtMonto.Text = oPago.psMontoActual; }
                lblConcepto.Text = oPago.psConcepto;
               
                


            }
            catch (Exception ex)
            {
               
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GruposLista.aspx");
           
        }

        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIDAlumno"] = string.Empty;
            ViewState["sIDPago"] = string.Empty;
        }

        private void RequestQueryString()
        {
            ViewState["Token"] = String.IsNullOrEmpty(Request.QueryString["Token"]) ? string.Empty : Request.QueryString["Token"];
        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDGrupo = Elemento.Element("IDPago").Value,
                              IDAlumno = Elemento.Element("IDAlumno").Value


                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDPago"] = Elemento.IDGrupo;
                ViewState["sIDAlumno"] = Elemento.IDAlumno;


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
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            PagosEnt opago = new PagosEnt();
            PagosBus opagobus = new PagosBus();

            opago.psIDPago = ViewState["sIDPago"].ToString();
            opago.psIDAlumno = ViewState["sIDAlumno"].ToString();
            opago.psMontoActual = txtMonto.Text;
            opago.psIDEstaus = rbTipoPago.SelectedValue.ToString();
            opago.psMedioPago = rcMedioPago.SelectedValue.ToString ();
            opago.psReferencia = txtReferencia.Text;

            if (opagobus.RegistraPago(opago) == "1")
            {

                RadWindowManager3.RadAlert("Se Registro el Pago", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/accept.png");
               // Response.Redirect("PagosAlumno.aspx?Token=" + CreaTokenPost());
             
            }
            else
            {

            }




        }
    }
}