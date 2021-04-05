using IELWEB.Startup;
using IELBUS.Security;
using IELBUS.User;
using IELENT.Common;
using IELENT.Security;
using IELENT.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELWEB.Startup
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

            //lblMensaje.Text = "";

            if (fnLogin(txtUsername.Text, txtPassword.Text))
            {
                //correcto           
                FormsAuthentication.
                    RedirectFromLoginPage(txtUsername.Text, chkPersist.Checked);

            }
        }

        private bool fnLogin(string prmUserLogin, string prmPassword)
        {
            bool _return = false;
            string NUsuario = string.Empty;


            string parametros = string.Empty;
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMensaje.Text = "Ninguno de los campos puede estar vacío";
            }
            //else if (!ValidaExpresion(txtUsername.Text, @"^[a-zA-Z0-9]{0,10}$"))
            //{
            //    lblMensaje.Text = "El campo Email contiene caracteres no válidos,";
            //}
            else
            {

                UsersBR seguridad = new UsersBR();
                ReglasBE reglas = new ReglasBE();
                DatosUsuarioBE resUsuario = new DatosUsuarioBE();
                UsuariosBE itemSecurity = new UsuariosBE();
                SecurityBR SecBR = new SecurityBR();

                reglas.TIPOBUSQUEDA = 2;
                reglas.USUARIO = txtUsername.Text;
                reglas.IDAPP = long.Parse(ResIEL.IdApp);
                resUsuario = seguridad.getUsuarioFull(reglas, long.Parse(ResIEL.IdApp));



                if (resUsuario.Usuario.IDUSUARIO.ToString() == "0")
                {
                    lblMensaje.Text = "El Nombre de usuario no existe!";
                }
                else if (resUsuario.Usuario.ACTIVO == false)
                {
                    //  dvLogin.Attributes.Add("style", "display:none"); dvMensajeCliente.Attributes.Add("style", "display:block");
                    //Mensaje.setMensaje("El usuario se encuentra intactivo, debes activarlo desde tu cuenta correo registrada.", "Lo Sentimos", 2);

                    //Comun.Mensaje Men = new Comun.Mensaje();
                    //Men.setMensaje("HOLA", "LO SENTIMOS", 3);
                }
                else
                {
                     EncryptionBE oEncription = new EncryptionBE();
                     oEncription = SecBR.encryptDesEncrypt(2, resUsuario.Usuario.PASSWORD, long.Parse(ResIEL.IdApp));

                     if (ValidaPassword(txtPassword.Text, oEncription.VALOROUT.ToString()))
                    {
                        itemSecurity.NOMBRE = resUsuario.Usuario.NOMBRE;
                        itemSecurity.APATERNO = resUsuario.Usuario.APATERNO;
                        itemSecurity.AMATERNO = resUsuario.Usuario.AMATERNO;
                        itemSecurity.IDUSUARIOAPP = resUsuario.Usuario.IDUSUARIOAPP;
                        itemSecurity.IDUSUARIO = resUsuario.Usuario.IDUSUARIO;
                        itemSecurity.RUTAFOTOPERFIL = resUsuario.Usuario.RUTAFOTOPERFIL;
                        itemSecurity.IDTIPOUSUARIO = resUsuario.Usuario.IDTIPOUSUARIO;
                        itemSecurity.USUARIO = resUsuario.Usuario.USUARIO;
                        itemSecurity.IDAREA = resUsuario.Usuario.IDAREA;
                      
                        Session.Add("USER_SESSION", itemSecurity);
                        if (resUsuario.Contactos.Count() > 0)
                        {
                            foreach (var item in resUsuario.Contactos)
                            {
                                if (item.IDTIPOCONTACTO == 3)
                                { Session.Add("USER_EMAIL", item.VALOR); }
                            }
                        }
                        
                        _return = true;
                    }
                    else { lblMensaje.Text = "El Password es incorrecto!"; }
                }
            }




            return _return;
        }

        public bool ValidaExpresion(string sTexto, string sPatron)
        {
            bool iRespuesta = false;
            Match mExpresionMatch = default(Match);
            mExpresionMatch = Regex.Match(sTexto, sPatron);
            if (mExpresionMatch.Success)
            {
                iRespuesta = true;
            }
            return iRespuesta;
        }

        public bool ValidaPassword(string sPassword, string sPasswordBD)
        {
            bool iRespuesta = false;

            if (sPassword == sPasswordBD)
            {
                iRespuesta = true;
            }
            return iRespuesta;
        }
    }
}