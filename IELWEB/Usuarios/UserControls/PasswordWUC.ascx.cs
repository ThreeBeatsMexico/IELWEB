using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IELWEB.Usuarios.UserControls
{
    public partial class PasswordWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string GetNewPass()
        {
            string sPassword = string.Empty;

            sPassword = txtPassConfirma.Text;

            return sPassword;
        }
    }
}