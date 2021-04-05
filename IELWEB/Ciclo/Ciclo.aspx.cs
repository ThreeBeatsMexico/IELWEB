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
using System.Drawing;
using System.IO;

using System.Web.UI.HtmlControls;
using System.Text;

namespace IELWEB.Ciclo
{
    public partial class Ciclo : System.Web.UI.Page
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

                        CargaInfoCiclo(ViewState["sIDCiclo"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void RequestQueryString()
        {
            ViewState["Token"] = String.IsNullOrEmpty(Request.QueryString["Token"]) ? string.Empty : Request.QueryString["Token"];
        }


        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIDCiclo"] = string.Empty;
            ViewState["banEntra"] = string.Empty;

        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDAgente = Elemento.Element("IDCiclo").Value

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDCiclo"] = Elemento.IDAgente;

            }

            iRespuesta = 1;

            return iRespuesta;
        }




        private string DesencriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenBus = new TokenBus();

            sRespuesta = oTokenBus.DesencriptaToken(sCadena);

            return sRespuesta;
        }

        public void CargaInfoCiclo(string IDCiclo)
        {
            CicloEnt item = new CicloEnt();
            CiclosBus oCiclosBus = new CiclosBus();
            item = oCiclosBus.ObtieneCiclo(IDCiclo);
           
            FechaInicial.SelectedDate = Convert.ToDateTime(item.psFechaInicial);
            FechaFinal.SelectedDate = Convert.ToDateTime(item.psFechaFinal);
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CiclosLista.aspx");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                CicloEnt ItemGuardar = new CicloEnt();
                CiclosBus oCiclosBus = new CiclosBus();
                ItemGuardar.psIDCiclo = txtIDCiclo.Text;
                ItemGuardar.psNombreCiclo = txtCiclo.Text;
                ItemGuardar.psFechaInicial = FechaInicial.SelectedDate.ToString();
                ItemGuardar.psFechaFinal = FechaFinal.SelectedDate.ToString();
                ItemGuardar.psMontoInscripcion = txtInscripcion.Text;
                ItemGuardar.psMontoColegiatura = txtColegiatura.Text;
                if (chkEstatus.Checked == true)
                { ItemGuardar.psEstatus = "1"; }
                else { ItemGuardar.psEstatus = "0"; }
                               
                
                if (oCiclosBus.fnRegistroCicloBus(ItemGuardar) != "")
                {
                   
                    Response.Redirect("CiclosLista.aspx?Token=" + CreaTokenPost());
                }
            }
            catch (Exception ex)
            {
              Label2.Text = ex.Message;
                
               
            }
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
            sXML.Append("<Matricula></Matricula>");
            sXML.Append("<Nombre></Nombre>");
            sXML.Append("<Paterno></Paterno>");
            sXML.Append("<Materno></Materno>");
            sXML.Append("<FechaNacimiento></FechaNacimiento>");
            sXML.Append("<Estatus>-1</Estatus>");
            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }

        private string EncriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            TokenBus oTokenBus = new TokenBus();

            sRespuesta = oTokenBus.EncriptaToken(sCadena);

            return sRespuesta;
        }

    }
}