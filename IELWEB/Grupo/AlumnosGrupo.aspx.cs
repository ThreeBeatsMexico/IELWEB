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
using System.Xml.Linq;
using System.Threading;
using Telerik.Web.UI;
using IELENT.User;
namespace IELWEB.Grupo
{
    public partial class AlumnosGrupo : System.Web.UI.Page
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
                              IDGrado = Elemento.Element("IDGrado").Value,
                              Grado = Elemento.Element("Grado").Value,
                              Grupo = Elemento.Element("Grupo").Value,
                              IDCiclo = Elemento.Element("IDCiclo").Value

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDGrado"] = Elemento.IDGrado;
                ViewState["sIDGrupo"] = Elemento.IDGrupo;
                ViewState["sGrado"] = Elemento.Grado;
                ViewState["sGrupo"] = Elemento.Grupo;
                ViewState["sIDCiclo"] = Elemento.IDCiclo;

            }

            iRespuesta = 1;

            return iRespuesta;
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
                AlumnosBus oAlumnosBus = new AlumnosBus();
                List<AlumnoEnt> oAlumnos = new List<AlumnoEnt>();
                List<AlumnoEnt> oAlumnosSearch = new List<AlumnoEnt>();
                oAlumnos = oAlumnosBus.ListaAlumnosGrupo(ViewState["sIDGrupo"].ToString(), ViewState["sIDGrado"].ToString(), ViewState["sIDCiclo"].ToString());
                oAlumnosSearch = oAlumnosBus.ListaAlumnosGrupoAdd(ViewState["sIDGrado"].ToString(), ViewState["sIDCiclo"].ToString());
                rcAlumno.Items.Clear();
                rcAlumno.DataSource = oAlumnosSearch;
                rcAlumno.DataValueField = "sIdAlumno";
                rcAlumno.DataTextField = "sNombres";
                rcAlumno.DataBind();
            
                RadGrid1.DataSource = oAlumnos;
                RadGrid1.DataBind();
                lblGrupoInfo.Text = ViewState["sGrado"].ToString() + " - " + ViewState["sGrupo"].ToString();

            }
            catch (Exception ex)
            {
                // lblMessage.Text = ex.Message;
            }
        }


        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIDGrupo"] = string.Empty;
            ViewState["sIDGrado"] = string.Empty;
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
            sXML.Append("<IDGrupo>" + ViewState["sIDGrupo"].ToString() + "</IDGrupo>");
            sXML.Append("<IDAlumno>" + ViewState["sIdAlumno"].ToString() + "</IDAlumno>");

            sXML.Append("</APP>");

            sRespuesta = sXML.ToString();

            return sRespuesta;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["sIdGrupo"] = "0";
            Response.Redirect("Grupo.aspx?Token=" + CreaTokenPost());
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GruposLista.aspx");
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                GruposBus oGrupoBus = new GruposBus();
                GridDataItem item = (GridDataItem)e.Item;
                ViewState["sIdAlumno"] = item.GetDataKeyValue("sIdAlumno").ToString();

                if (e.CommandName == "VerPagos")
                {
                 


                     Response.Redirect("../Pagos/PagosAlumno.aspx?Token=" + CreaTokenPost());
              

                }
                if (e.CommandName == "EliminaGrupo")
                {

                    if (oGrupoBus.EliminaGrupo(ViewState["sIdGrupo"].ToString()) == "1")
                    { RadWindowManager1.RadAlert("El Grupo se ha eliminado", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/accept.png"); }
                    else
                    { RadWindowManager1.RadAlert("No se pudo Eliminar el Grupo", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/block.png"); }

               

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

        protected void btnAgregaAlumno_Click(object sender, EventArgs e)
        {
            AlumnosBus oAlumnosBus = new AlumnosBus();
            UsuariosBE oUser = new UsuariosBE();
            oUser = (UsuariosBE)Session["USER_SESSION"];




            string User = oUser.IDUSUARIOAPP.ToString();
            string grupo = ViewState["sIDGrupo"].ToString();
            string ciclo = ViewState["sIDCiclo"].ToString();
            

            oAlumnosBus.AsignaAlumnoGrupo(rcAlumno.SelectedValue.ToString(),grupo,ciclo,User);

            RadWindowManager1.RadAlert("Alumno Asignado !!", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/accept.png");
           // ReadData();



        }

    }
}