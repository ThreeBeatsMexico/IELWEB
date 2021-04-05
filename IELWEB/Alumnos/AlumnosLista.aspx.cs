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

namespace IELWEB.Alumnos
{
    public partial class AlumnosLista : System.Web.UI.Page
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
                AlumnoEnt oAlumnoEnt = new AlumnoEnt();
                List<AlumnoEnt> oAlumnos = new List<AlumnoEnt>();
                AlumnosBus oAlumnosBus = new AlumnosBus();

                oAlumnoEnt.sNombres = ViewState["sNombre"].ToString();
                oAlumnoEnt.sAPaterno = ViewState["sPaterno"].ToString();
                oAlumnoEnt.sAMaterno = ViewState["sMaterno"].ToString();
                oAlumnoEnt.sNumeroMatricula = ViewState["sMatricula"].ToString();
                oAlumnoEnt.sFechaNacimiento = ViewState["sFechaNacimiento"].ToString();
                oAlumnoEnt.sEstatus = ViewState["sEstatus"].ToString();


                oAlumnos = oAlumnosBus.ListaAlumnos(oAlumnoEnt);
                RadGrid1.DataSource = oAlumnos;
                RadGrid1.DataBind();

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
                ViewState["sIdAlumno"] = item.GetDataKeyValue("sNumeroMatricula").ToString();
                ViewState["sCredenciales"] = "'"+item.GetDataKeyValue("sNumeroMatricula").ToString() + "'";
                if (e.CommandName == "EditaAlumno")
                {

                    Response.Redirect("Alumno.aspx?Token=" + CreaTokenPost());
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "callJSFunction",
                    //                                      "setTabStrip('COTIZADOR','../COTIZADOR/Cotizador.aspx','" + CreaTokenPost() + "');", true);
                }
                if (e.CommandName == "VerFicha")
                {
                  //  RadAjaxManager1.ResponseScripts.Add(@"openWin('../REPORTES/CotizacionRpt.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");

                    RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");
                  //  RadAjaxManager1.ResponseScripts.Add(@"openPrint('../Reportes/AlumnoRpt.aspx','" + CreaTokenPost() + "','IMPRIME FICHA ALUMNO','RadWindow1');");


                }
                if (e.CommandName == "generaCredencial")
                {
                    //  RadAjaxManager1.ResponseScripts.Add(@"openWin('../REPORTES/CotizacionRpt.aspx','" + CreaTokenPost() + "','IMPRIME COTIZACION','RadWindow1');");

                    RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/Credencial.aspx','" + CreaTokenPost1() + "','CREDENCIAL','RadWindow1');");
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
            ViewState["sCredenciales"] = string.Empty;
        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              Matricula = Elemento.Element("Matricula").Value,
                              Nombre = Elemento.Element("Nombre").Value,
                              Paterno = Elemento.Element("Paterno").Value,
                              Materno = Elemento.Element("Materno").Value,
                              FechaNacimiento = Elemento.Element("FechaNacimiento").Value,
                              Estatus = Elemento.Element("Estatus").Value
                         
                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sMatricula"] = Elemento.Matricula;
                ViewState["sNombre"] = Elemento.Nombre;
                ViewState["sPaterno"] = Elemento.Paterno;
                ViewState["sMaterno"] = Elemento.Materno;
                ViewState["sFechaNacimiento"] = Elemento.FechaNacimiento;
                ViewState["sEstatus"] = Elemento.Estatus;
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
            sXML.Append("<IDAlumno>" + ViewState["sIdAlumno"].ToString() + "</IDAlumno>");
          
            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["sIdAlumno"] = "0";
            Response.Redirect("Alumno.aspx?Token=" + CreaTokenPost());
        }

        protected void btnImprimeCredenciales_Click(object sender, EventArgs e)
        {
            if (RadGrid1.SelectedItems.Count == 0)
            {
                RadWindowManager1.RadAlert("Debes Seleccionar al menos un Registro!!!", 270, 150, "Mensaje", "cerrar");
            }
            else
            {
                GeneraCredenciales();
            }
        }

        public void GeneraCredenciales()
        {
            GridItemCollection Seleccionados = RadGrid1.SelectedItems;
            StringBuilder certificados = new StringBuilder();
            StringBuilder certif = new StringBuilder();
            string bandera = string.Empty;

            if (RadGrid1.SelectedItems.Count == 1)
                foreach (GridDataItem item in Seleccionados)
                {
                    certif.Append("'" + item.GetDataKeyValue("sNumeroMatricula").ToString()+"'");
                   
                   
                }
            else
            {
                foreach (GridDataItem item in Seleccionados)
                {
                    certificados.Append("'"+ item.GetDataKeyValue("sNumeroMatricula").ToString()+ "'" + ",");


                 
                   

                }

                certif.Append(certificados.ToString().Trim().Substring(0, certificados.Length - 1));


            }


            ViewState["sCredenciales"] = certif.ToString();



            RadAjaxManager1.ResponseScripts.Add(@"openWin('../Reportes/Credencial.aspx','" + CreaTokenPost1() + "','CREDENCIALES','RadWindow1');");
           
        
        
        }

        private string CreaTokenPost1()
        {
            string sRespuesta = string.Empty;

            sRespuesta = EncriptaToken(TokenPostXML1());

            return sRespuesta;
        }

        private string TokenPostXML1()
        {
            string sRespuesta = string.Empty;

            StringBuilder sXML = new StringBuilder();

            sXML.Append("<APP>");
            sXML.Append("<IDCredenciales>" + ViewState["sCredenciales"].ToString() + "</IDCredenciales>");
            sXML.Append("</APP>");
            sRespuesta = sXML.ToString();

            return sRespuesta;

        }
       
    }
}