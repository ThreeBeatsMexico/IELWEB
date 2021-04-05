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
using System.Xml.Linq;
using System.Drawing;


namespace IELWEB.Pagos
{
    public partial class PagosAlumno : System.Web.UI.Page
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
                lblMessage.Text = ex.Message;
            }
        }
        void ReadData()
        {
            try
            {
                AlumnoEnt oAlumno = new AlumnoEnt();
                AlumnosBus oAlumnoBus = new AlumnosBus();
                oAlumno = oAlumnoBus.ObtieneAlumno2(ViewState["sIDAlumno"].ToString());
                lblNombreAlumno.Text = oAlumno.sNumeroMatricula + "-" + oAlumno.sNombres + " " + oAlumno.sAPaterno + " " + oAlumno.sAMaterno; 
                
                
                List<PagosEnt> oPagos = new List<PagosEnt>();
                PagosBus oPagosBus = new PagosBus();

                oPagos = oPagosBus.ListaPagosAlumno(ViewState["sIDAlumno"].ToString());
                RadGrid1.DataSource = oPagos;
                RadGrid1.DataBind();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
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
            ViewState["sIDGrupo"] = string.Empty;
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
                              IDGrupo = Elemento.Element("IDGrupo").Value,
                              IDAlumno = Elemento.Element("IDAlumno").Value
                            

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDGrupo"] = Elemento.IDGrupo;
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
                ViewState["sIDAlumno"] = item.GetDataKeyValue("psIDAlumno").ToString();
                ViewState["sIDPago"] = item.GetDataKeyValue("psIDPago").ToString();

                if (e.CommandName == "RegistraPago")
                {
                    if (item.GetDataKeyValue("psEstado").ToString() == "PAGADO")
                    {
                        RadWindowManager2.RadAlert("El Grupo ya existe, verifique !!", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/warning.png");

                    }
                    else
                    {



                        // RadAjaxManager.GetCurrent(Page).ResponseScripts.Add(@"openWin('RegistraPago.aspx','" + CreaTokenPost() + "','RadWindow1');");
                        RadAjaxManager.GetCurrent(Page).ResponseScripts.Add(@"openWin('RegistraPago.aspx','" + CreaTokenPost() + "','RadWindow1');");
                    }
                 //   Response.Redirect("RegistraPago.aspx?Token=" + CreaTokenPost());
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

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if(e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (item.GetDataKeyValue("psEstado").ToString() == "PAGADO")
                {
                    item["ESTATUS"].ForeColor = Color.Green; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
                }
                else if (item.GetDataKeyValue("psEstado").ToString() == "ABONADO")
                {
                    item["ESTATUS"].ForeColor = Color.Yellow; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
                }
                else if (item.GetDataKeyValue("psEstado").ToString() == "SIN PAGAR")
                {
                    item["ESTATUS"].ForeColor = Color.Red; // chanmge particuler cell
                    e.Item.BackColor = System.Drawing.Color.LightGoldenrodYellow; // for whole row
                }

            }
           
        }
    }
}