using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using IELBUS;
using IELENT;
using System.Text;

namespace IELWEB.Pagos
{
    public partial class PagosBusqueda : System.Web.UI.Page
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

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "setUrl('ContentPanePagos','PagosLista.aspx','" + CreaTokenPost() + "');", true);
            }
            catch (Exception E)
            {

                throw new Exception("Mensaje:BuscarDocumentos>BuscarDocumentos>Click");
            }
        }



        private void RequestQueryString()
        {
            ViewState["Token"] = String.IsNullOrEmpty(Request.QueryString["Token"]) ? string.Empty : Request.QueryString["Token"];
        }


        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIDAgente"] = string.Empty;
            ViewState["sIDPromotor"] = string.Empty;
            ViewState["sIDProducto"] = string.Empty;
            ViewState["sNombreProducto"] = string.Empty;

        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDAgente = Elemento.Element("IDAgente").Value,
                              IDProducto = Elemento.Element("IDProducto").Value,
                              Producto = Elemento.Element("Producto").Value,
                              IDPromotor = Elemento.Element("IDPromotor").Value
                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDAgente"] = Elemento.IDAgente;
                ViewState["sIDPromotor"] = Elemento.IDPromotor;
                ViewState["sIDProducto"] = Elemento.IDProducto;
                ViewState["sNombreProducto"] = Elemento.Producto;
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
            sXML.Append("<Matricula>" + txtMatricula.Text + "</Matricula>");
            
            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
    }
}