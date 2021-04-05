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
using Telerik.Web.UI;

namespace IELWEB.Grupo
{
    public partial class Grupo : System.Web.UI.Page
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
                        //    VariablesViewState();
                        //    RequestQueryString();
                        //    string sToken = string.Empty;
                        //    sToken = DesencriptaToken(ViewState["Token"].ToString());
                        //    int iRespuestaValidaToken = 0;
                        //    iRespuestaValidaToken = ValidaToken(sToken);
                        CargaCiclo();
                        //CargaInfoGrupo(ViewState["sIDGrupo"].ToString());

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

        protected void rcNivelAcademico_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LLenaGrado(rcNivelAcademico.SelectedValue.ToString());
        }
        public void LLenaGrado(string NAcademico)
        {
            AlumnosBus oListaGrado = new AlumnosBus();
            List<GradoEnt> oGradoList = new List<GradoEnt>();
            oGradoList = oListaGrado.ObtieneGrado(NAcademico);
            rcGrado.DataValueField = "sIDGrado";
            rcGrado.DataTextField = "sDescripcionGrado";
            rcGrado.DataSource = oGradoList;
            rcGrado.DataBind();
            rcGrado.Enabled = true;
        }
        private void CargaCiclo()
        {
            List<CicloEnt> oListaCiclo = new List<CicloEnt>();
            CiclosBus oCicloBus = new CiclosBus();
            oListaCiclo =  oCicloBus.ListaCiclos();
            rcCiclo.DataValueField = "psIDCiclo";
            rcCiclo.DataTextField = "psNombreCiclo";
            rcCiclo.DataSource = oListaCiclo;
            rcCiclo.DataBind();
            rcCiclo.Enabled = true;

        
        }

        private void VariablesViewState()
        {
            ViewState["Token"] = string.Empty;
            ViewState["sIDGrupo"] = string.Empty;
            ViewState["banEntra"] = string.Empty;

        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDAgente = Elemento.Element("IDGrupo").Value

                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDGrupo"] = Elemento.IDAgente;

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

        //public void CargaInfoGrupo(string IDGrupo)
        //{
        //    GrupoEnt oGrupo = new GrupoEnt();
        //    GruposBus oGrupoBus = new GruposBus();
        //    oGrupo = oGrupoBus.ObtieneGrupo(IDGrupo.ToString());

        //    rcNivelAcademico.SelectedValue = oGrupo.psIDNivelAcademico;
        //    LLenaGrado(oGrupo.psNivelAcademico);
        //    rcGrado.SelectedValue = oGrupo.psIDGrado;
        //    rcGrupo.SelectedValue = oGrupo.psIDGrupo;
        //    rcCiclo.SelectedValue = oGrupo.psIDCiclo;
            
            
        //}


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GruposLista.aspx");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                GrupoEnt ItemGuardar = new GrupoEnt();
                GruposBus oGruposBus = new GruposBus();
                ItemGuardar.psIDGrupo = txtIDGrupo.Text;
                ItemGuardar.psNombreGrupo = rcGrupo.SelectedValue.ToString();
                ItemGuardar.psIDNivelAcademico = rcNivelAcademico.SelectedValue.ToString();
                ItemGuardar.psIDCiclo = rcCiclo.SelectedValue.ToString();
                ItemGuardar.psIDGrado = rcGrado.SelectedValue.ToString();
                if (oGruposBus.ValidaGrupoBus(ItemGuardar) == "1")
                {
                    RadWindowManager1.RadAlert("El Grupo ya existe, verifique !!", 270, 150, "Mensaje", "refreshGrid", "../IMAGES/warning.png");
                }
                else
                {
                    if (oGruposBus.fnRegistroGrupoBus(ItemGuardar) != "")
                    {

                        Response.Redirect("GruposLista.aspx?Token=" + CreaTokenPost());
                    }
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