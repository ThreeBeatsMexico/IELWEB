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





namespace IELWEB.Alumnos
{
    public partial class Alumno : System.Web.UI.Page
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
                       
                        CargaInfoAlumno(ViewState["sIDAlumno"].ToString());

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
            ViewState["sIDAlumno"] = string.Empty;
            ViewState["banEntra"] = string.Empty;

        }

        private int ValidaToken(string sToken)
        {
            int iRespuesta = 0;

            XDocument xmlToken = XDocument.Parse(sToken);
            var Valores = from Elemento in xmlToken.Descendants("APP")
                          select new
                          {
                              IDAgente = Elemento.Element("IDAlumno").Value
                              
                          };

            foreach (var Elemento in Valores)
            {
                ViewState["sIDAlumno"] = Elemento.IDAgente;
               
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

        public void CargaInfoAlumno(string IDAlumno)
        {
            AlumnoEnt item = new AlumnoEnt();
            AlumnosBus oAlumnosBus = new AlumnosBus();
            item = oAlumnosBus.ObtieneAlumno(IDAlumno);
            txtMatricula.Text = item.sNumeroMatricula;
            txtPaterno.Text = item.sAPaterno;
            txtMaterno.Text = item.sAMaterno;
            txtNombres.Text = item.sNombres;
            FechaNacimiento.SelectedDate = Convert.ToDateTime(item.sFechaNacimiento);
            rcSexo.SelectedValue = item.sSexo;
            txtNacionalidad.Text = item.sNacionalidad;
            rcNivelAcademico.SelectedValue = item.sNivelAcademico;
            LLenaGrado(item.sNivelAcademico.ToString());

            rcGrado.SelectedValue = item.sGrado;


            txtEscuelaProcedencia.Text = item.sEscuelaProcedencia;
            rbHermanos.SelectedValue = item.sHermanos;
            txtGradoHermanos.Text = item.sGradoHermanos;
            txtCalle.Text = item.sCalle;
            txtNumero.Text = item.sNumero;
            txtColonia.Text = item.sColonia;
            txtDelegacion.Text = item.sDelegacion;
            txtEstado.Text = item.sEstado;
            txtCodigoPostal.Text = item.sCodigoPostal;
            txtTelefono.Text = item.sTelefono;
            txtEmail.Text = item.sEmail;
            txtTutor.Text = item.sTutor;
            txtCurp.Text = item.sCurp;
            txtAnos.Text = item.sEdadAnos;
            txtMeses.Text = item.sEdadMeses;
            imgAlumno.ImageUrl = item.sFoto;
            
            txtNombrePadreTutor.Text = item.sNombrePadreTutor;
            txtOcupacionPadre.Text = item.sOcupacionPadre;
            txtTelPadre.Text = item.sTelefonoPadre;
            txtTelPadreTrabajo.Text = item.sTelefonoTrabajoPadre;
            txtTelPadreCelular.Text = item.sCelularPadre;
            FechaNacimientoPadre.SelectedDate = Convert.ToDateTime(item.sFechaNacimientoPadre);
            txtSueldoPadre.Text = item.sSueldoPadre;
            txtNacionalidadPadre.Text = item.sNacionalidadPadre;
            txtNombreMadreTutor.Text = item.sNombreMadreTutor;
            txtOcupacionMadre.Text = item.sOcupacionMadre;
            txtTelMadre.Text = item.sTelefonoMadre;
            txtTelMadreTrabajo.Text = item.sTelefonoTrabajoMadre;
            txtTelMadreCel.Text = item.sCelularMadre;
            FechaNacimientoMadre.SelectedDate = Convert.ToDateTime(item.sFechaNacimientoMadre);
            txtSueldoMadre.Text = item.sSueldoMadre;
            txtNacionalidadMadre.Text = item.sNacionalidadMadre;
            txtNombreVecino.Text = item.sNombreFamVecino;
            txtTelVecino.Text = item.sTelefonoVecino;
            txtTelVecinoCel.Text = item.sTelefonoTrabajoVecino;
            txtTelVecinoCel.Text = item.sCelularVecino;
            rbEFisica.SelectedValue = item.sEducacionFisica;
            rbMedicamento.SelectedValue = item.sMedicamento;
            txtNombreMedicamento.Text = item.sNombreMedicamento;
            txtDosisMedicamento.Text = item.sDosisMedicamento;
            txtPeso.Text = item.sPeso;
            txtTalla.Text = item.sTalla;
            txtTipoSangre.Text = item.sTipoSangre;
            rbEnfermedad.SelectedValue = item.sEnfermedades;
            txtNombreEnfermedad.Text = item.sNombreEnfermedades;
            txtProcedimientoEnfermedad.Text = item.sProcedimientoCrisis;
            rbCertificado.SelectedValue = item.sCertificado;
            rbEnfermedadCert.SelectedValue = item.sEnfermedadCertificado;
            rbAlergia.SelectedValue = item.sAlergia;
            txtNombreAlergia.Text = item.sNombreAlergia;
            txtProcedimientoAlergia.Text = item.sProcedimintoCrisisAlergia;
            txtNombreAccidente.Text = item.sNombreAccidente;
            txtTelAccidente.Text = item.sTelefonoAccidente;
            txtIstitucion.Text = item.sNombreHospital;
            rbMedicoParticular.SelectedValue = item.sMedico;
            txtNombreMedico.Text = item.sNombreMedico;
            txtTelefonoMedico.Text = item.sTelefonoMedico;
            txtCedulaMedico.Text = item.sCedulaMedico;
            rbAutorizacion.SelectedValue = item.sAutorizaTraslado;
            txtProcedimientoAccidente.Text = item.sProcedimientoAccidente;
            txtBeca.Text = item.sBeca;
            rcFormaPago.SelectedValue = item.sFormaPago;

            ShowHidenRows();



        }

        public void ShowHidenRows()
        {
            if (rbHermanos.SelectedValue.ToString() == "1")
            { trHermanos.Attributes.Add("style", "display:table-row"); }
            if (rbMedicamento.SelectedValue.ToString() == "1")
            { trMedicamento.Attributes.Add("style", "display:table-row"); }
            if (rbEnfermedad.SelectedValue.ToString() == "1")
            { trEnfermedad1.Attributes.Add("style", "display:table-row"); trEnfermedad2.Attributes.Add("style", "display:table-row"); }
            if (rbAlergia.SelectedValue.ToString() == "1")
            { trAlergia1.Attributes.Add("style", "display:table-row"); trAlergia2.Attributes.Add("style", "display:table-row"); }
            if (rbCertificado.SelectedValue.ToString() == "1")
            { trEnfermedadCert.Attributes.Add("style", "display:table-row"); }
            if (rbEnfermedadCert.SelectedValue.ToString() == "1")
            { trMensajeCert.Attributes.Add("style", "display:table-row"); }
            if (rbMedicoParticular.SelectedValue.ToString() == "1")
            { trMedicoParticular.Attributes.Add("style", "display:table-row"); }
            if (rbAutorizacion.SelectedValue.ToString() == "1")
            { trProcedimientoAccidente.Attributes.Add("style", "display:table-row"); }



        }

 

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlumnosLista.aspx?Token=" + CreaTokenPost());
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                AlumnoEnt ItemGuardar = new AlumnoEnt();
                AlumnosBus oAlumnosBus = new AlumnosBus();
                string pathIn = Server.MapPath("~/Images/Temp/");
                string pathOut = Server.MapPath("~/Images/Alumnos/");
                ItemGuardar.sNumeroMatricula = txtMatricula.Text;
                ItemGuardar.sAPaterno = txtPaterno.Text;
                ItemGuardar.sAMaterno = txtMaterno.Text;
                ItemGuardar.sNombres = txtNombres.Text;
                ItemGuardar.sFechaNacimiento = FechaNacimiento.SelectedDate.Value.ToString("yyyy-MM-dd", null);
                ItemGuardar.sSexo = rcSexo.SelectedValue;
                ItemGuardar.sNacionalidad = txtNacionalidad.Text;
                ItemGuardar.sGrado = rcGrado.SelectedValue;
                ItemGuardar.sEscuelaProcedencia = txtEscuelaProcedencia.Text;
                ItemGuardar.sHermanos = rbHermanos.SelectedValue;
                ItemGuardar.sGradoHermanos = txtGradoHermanos.Text;
                ItemGuardar.sCalle = txtCalle.Text;
                ItemGuardar.sNumero = txtNumero.Text;
                ItemGuardar.sColonia = txtColonia.Text;
                ItemGuardar.sDelegacion = txtDelegacion.Text;
                ItemGuardar.sEstado = txtEstado.Text;
                ItemGuardar.sCodigoPostal = txtCodigoPostal.Text;
                ItemGuardar.sTelefono = txtTelefono.Text;
                ItemGuardar.sEmail = txtEmail.Text;
                ItemGuardar.sTutor = txtTutor.Text;
                ItemGuardar.sCurp = txtCurp.Text;
                ItemGuardar.sEdadAnos = txtAnos.Text;
                ItemGuardar.sEdadMeses = txtMeses.Text;
                ItemGuardar.sFoto = imgAlumno.ImageUrl;
                
                ItemGuardar.sNivelAcademico = rcNivelAcademico.SelectedValue;
                ItemGuardar.sNombrePadreTutor = txtNombrePadreTutor.Text;
                ItemGuardar.sOcupacionPadre = txtOcupacionPadre.Text;
                ItemGuardar.sTelefonoPadre = txtTelPadre.Text;
                ItemGuardar.sTelefonoTrabajoPadre = txtTelPadreTrabajo.Text;
                ItemGuardar.sCelularPadre = txtTelPadreCelular.Text;
                ItemGuardar.sFechaNacimientoPadre = FechaNacimientoPadre.SelectedDate.Value.ToString("yyyy-MM-dd",null);
                ItemGuardar.sSueldoPadre = txtSueldoPadre.Text;
                ItemGuardar.sNacionalidadPadre = txtNacionalidadPadre.Text;
                ItemGuardar.sNombreMadreTutor = txtNombreMadreTutor.Text;
                ItemGuardar.sOcupacionMadre = txtOcupacionMadre.Text;
                ItemGuardar.sTelefonoMadre = txtTelMadre.Text;
                ItemGuardar.sTelefonoTrabajoMadre = txtTelMadreTrabajo.Text;
                ItemGuardar.sCelularMadre = txtTelMadreCel.Text;
                ItemGuardar.sFechaNacimientoMadre = FechaNacimientoMadre.SelectedDate.Value.ToString("yyyy-MM-dd", null);
                ItemGuardar.sSueldoMadre = txtSueldoMadre.Text;
                ItemGuardar.sNacionalidadMadre = txtNacionalidadMadre.Text;
                ItemGuardar.sNombreFamVecino = txtNombreVecino.Text;
                ItemGuardar.sTelefonoVecino = txtTelVecino.Text;
                ItemGuardar.sTelefonoTrabajoVecino = txtTelVecinoCel.Text;
                ItemGuardar.sCelularVecino = txtTelVecinoCel.Text;
                ItemGuardar.sEducacionFisica = rbEFisica.SelectedValue;
                ItemGuardar.sMedicamento = rbMedicamento.SelectedValue;
                ItemGuardar.sNombreMedicamento = txtNombreMedicamento.Text;
                ItemGuardar.sDosisMedicamento = txtDosisMedicamento.Text;
                ItemGuardar.sPeso = txtPeso.Text;
                ItemGuardar.sTalla = txtTalla.Text;
                ItemGuardar.sTipoSangre = txtTipoSangre.Text;
                ItemGuardar.sEnfermedades = rbEnfermedad.SelectedValue;
                ItemGuardar.sNombreEnfermedades = txtNombreEnfermedad.Text;
                ItemGuardar.sProcedimientoCrisis = txtProcedimientoEnfermedad.Text;
                ItemGuardar.sCertificado = rbCertificado.SelectedValue;
                ItemGuardar.sEnfermedadCertificado = rbEnfermedadCert.SelectedValue;
                ItemGuardar.sAlergia = rbAlergia.SelectedValue;
                ItemGuardar.sNombreAlergia = txtNombreAlergia.Text;
                ItemGuardar.sProcedimintoCrisisAlergia = txtProcedimientoAlergia.Text;
                ItemGuardar.sNombreAccidente = txtNombreAccidente.Text;
                ItemGuardar.sTelefonoAccidente = txtTelAccidente.Text;
                ItemGuardar.sNombreHospital = txtIstitucion.Text;
                ItemGuardar.sMedico = rbMedicoParticular.SelectedValue;
                ItemGuardar.sNombreMedico = txtNombreMedico.Text;
                ItemGuardar.sTelefonoMedico = txtTelefonoMedico.Text;
                ItemGuardar.sCedulaMedico = txtCedulaMedico.Text;
                ItemGuardar.sAutorizaTraslado = rbAutorizacion.SelectedValue;
                ItemGuardar.sProcedimientoAccidente = txtProcedimientoAccidente.Text;
                ItemGuardar.sUsuario = Context.User.Identity.Name.ToString();
                ItemGuardar.sEstatus = rcEstatus.SelectedValue.ToString();
                ItemGuardar.sBeca = txtBeca.Text;
                ItemGuardar.sFormaPago = rcFormaPago.SelectedValue;
                if (txtMatricula.Text == "")
                { ItemGuardar.sServerPath = pathOut.ToString(); }
                else
                { ItemGuardar.sServerPath = pathOut.ToString() + txtMatricula.Text + ".jpg"; }
                
                string MATRICULA = oAlumnosBus.fnRegistroAlumnosBus(ItemGuardar);
                if (MATRICULA != "")
                {
                    
                   if(File.Exists(pathIn + "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + ".jpg"))
                   { 
                   System.IO.File.Copy(pathIn + "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + ".jpg", pathOut + MATRICULA + ".jpg",true);
                   System.IO.File.Delete(pathIn + "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + ".jpg");
                   }
                   Response.Redirect("AlumnosLista.aspx?Token=" + CreaTokenPost());
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }



       protected void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        { }
        protected void AsyncUpload1_FileUploaded2(object sender, FileUploadedEventArgs e)
        {
            try
            {

                string urlImage = string.Empty;
                imgAlumno.Dispose();
                string path = Server.MapPath("~/Images/Temp/");
                string fullpath = string.Empty;


                //if (txtMatricula.Text == string.Empty)
                //{
                fullpath = path + "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + e.File.GetExtension();
                urlImage = "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + e.File.GetExtension();
                //}
                //else
                //{
                //    fullpath = path + txtMatricula.Text.ToString() + e.File.GetExtension();
                //    urlImage = txtMatricula.Text.ToString() + e.File.GetExtension();
                //}


                e.File.SaveAs(fullpath, true);
                imgAlumno.ImageUrl = "../Images/Temp/" + urlImage;
                ViewState["banEntra"] = "1";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clearUpload", String.Format("$find('{0}').deleteAllFileInputs()", AsyncUpload1.ClientID), true);

            }
            catch(Exception oExeption)
            {
            
            }

                        
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {



            if (e.Argument == "CHANGEIMG")
            {

                string urlImage = string.Empty;
                imgAlumno.Dispose();
                string path = Server.MapPath("~/Images/Temp/");
                string fullpath = string.Empty;

                AsyncUpload1.UploadedFiles[0].FileName.ToString();
                
                //if (txtMatricula.Text == string.Empty)
                //{
                fullpath = path + "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + AsyncUpload1.UploadedFiles[0].GetExtension(); 
                urlImage = "tmpFotoAlumno_" + Context.User.Identity.Name.ToString() + AsyncUpload1.UploadedFiles[0].GetExtension(); 
                //}
                //else
                //{
                //    fullpath = path + txtMatricula.Text.ToString() + e.File.GetExtension();
                //    urlImage = txtMatricula.Text.ToString() + e.File.GetExtension();
                //}

                AsyncUpload1.UploadedFiles[0].SaveAs(fullpath, true);
               
                imgAlumno.ImageUrl = "../Images/Temp/" + urlImage;
            
            
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


       

         
    }
}