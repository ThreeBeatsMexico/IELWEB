using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELBUS;
using IELENT;
using System.IO;
using System.Collections;

namespace IELWEB.Administracion
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (!Context.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.RedirectToLoginPage("../Startup/login.aspx");
                    }
                    else
                    {



                        if (Request.Params["id"].ToString() == "0")
                        {
                            //Nuevo
                            //string selectedValue = ddlImage.SelectedValue;
                            //ShowImages();
                            //ddlImage.SelectedValue = selectedValue;
                            btnGrabar.Enabled = true;
                        }
                        else
                        {
                            //editar
                            txtUSER_LOGIN.Enabled = false;
                            //ShowImages();
                            ReadData(Request.Params["id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

        }


        void ReadData(string prmUSER_LOGIN)
        {
            try
            {
                UsuarioEnt oUsuario = new UsuarioEnt();
                UsuarioBus oUsuarioBus = new UsuarioBus();
                string img;
                oUsuario = oUsuarioBus.ObtieneUsuario(prmUSER_LOGIN);
                txtUSER_LOGIN.Text = prmUSER_LOGIN;
                txtUSER_PASSWORD.Text = oUsuario.psPassword;
                txtNOMBRE.Text = oUsuario.psNombreUsuario;
                chkACTIVO.Checked = Convert.ToBoolean(oUsuario.psActivo);
                chkADMINISTRACION.Checked = Convert.ToBoolean(oUsuario.psAdministracion);
                chkALUMNOS.Checked = Convert.ToBoolean(oUsuario.psAlumnos);
               // chkPROFESORES.Checked = Convert.ToBoolean(oUsuario.psProfesores);
                chkCOBRANZA.Checked = Convert.ToBoolean(oUsuario.psCobranza);
               // chkBLOG.Checked = Convert.ToBoolean(oUsuario.psBlog);
                chkPAGO.Checked = Convert.ToBoolean(oUsuario.psPago);
                //Image1.ImageUrl = "~/Images/Users/" + oUsuario.psImagen.ToString();
                img = oUsuario.psImagen.ToString();
                img = img.Substring(15, img.Length - 15);
                //ddlImage.SelectedValue = img;
              

            }
            catch(Exception E)
            { }
        }

      
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEnt UsuarioItem = new UsuarioEnt();
                UsuarioBus oUsuarioItemBus = new UsuarioBus();
                UsuarioItem.psIDUsuario = txtUSER_LOGIN.Text;
                UsuarioItem.psNombreUsuario = txtNOMBRE.Text;
                UsuarioItem.psPassword = txtUSER_PASSWORD.Text;
                UsuarioItem.psActivo = Convert.ToInt32(chkACTIVO.Checked).ToString();
                UsuarioItem.psAdministracion = Convert.ToInt32(chkADMINISTRACION.Checked).ToString();
                UsuarioItem.psAlumnos = Convert.ToInt32( chkALUMNOS.Checked).ToString();
               // UsuarioItem.psProfesores = Convert.ToInt32(chkPROFESORES.Checked).ToString();
                UsuarioItem.psCobranza = Convert.ToInt32(chkCOBRANZA.Checked).ToString();
                UsuarioItem.psPago = Convert.ToInt32(chkPAGO.Checked).ToString();
               // UsuarioItem.psBlog = Convert.ToInt32(chkBLOG.Checked).ToString();
               // UsuarioItem.psAyuda = Convert.ToInt32(chkAYUDA.Checked).ToString();
               // UsuarioItem.psImagen = ddlImage.SelectedValue.ToString();
                if (oUsuarioItemBus.fnRegistroBus(UsuarioItem))
                {
                    Response.Redirect("UsuariosLista.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        //private void ShowImages()
        //{
        //    //Get all filepaths
        //    string[] images = Directory.GetFiles(Server.MapPath("~/Images/Users/"));

        //    //Get all filenames and add them to an arraylist
        //    ArrayList imageList = new ArrayList();

        //    foreach (string image in images)
        //    {
        //        string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
        //        imageList.Add(imageName);
        //    }

        //    //Set the arrayList as the dropdownview's datasource and refresh
        //    ddlImage.DataSource = imageList;
        //    ddlImage.DataBind();

        //}

        //protected void btnUploadImage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string filename = Path.GetFileName(FileUpload1.FileName);
        //        FileUpload1.SaveAs(Server.MapPath("~/Images/Users/") + filename);
        //        lblMensaje.Text = "La imagen " + filename + " se cargó correctamente!";
        //        Page_Load(sender, e);
        //    }
        //    catch (Exception)
        //    {
        //        lblMensaje.Text = "Fallo la carga!";
        //    }
        //}

        //protected void ddlImage_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Image1.ImageUrl = "~/Images/Users/" + ddlImage.SelectedValue;
        //}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosLista.aspx");
        }
    }
}