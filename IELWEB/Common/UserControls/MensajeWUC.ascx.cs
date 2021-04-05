using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELWEB.Common.UserControls
{
    public partial class MensajeWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        /// <summary>
        /// Metodo para mostrar y setear los valores de la ventana que se quiere mostrar
        /// </summary>
        /// <param name="sMensaje">Mensaje que se quiere mostrar al Usuario</param>
        /// <param name="dTipoMensaje">1.- Error,2.-Warnning, 3.-Success,4.-Default</param>
        public void SetMensaje(string sMensaje, int dTipoMensaje, string sIdScript)
        {
            lblMensaje.Text = sMensaje;
            bool bAlert = false;

            switch (dTipoMensaje)
            {
                case 1://Error
                    divModal.Attributes.CssStyle.Add("class", "modal modal-danger");
                    imgTituloModal.Attributes.Add("class", "");
                    lblTituloModal.Text = "Error de sistema";
                    break;
                case 2://Warning
                    divModal.Attributes.CssStyle.Add("class", "modal modal-warning");
                    imgTituloModal.Attributes.CssStyle.Add("class", "");
                    lblTituloModal.Text = "Alerta";
                    break;
                case 3://Success
                    divModal.Attributes.CssStyle.Add("class", "modal modal-success");
                    imgTituloModal.Attributes.CssStyle.Add("class", "Success");
                    lblTituloModal.Text = "Error de sistema";
                    break;
                case 4://Default
                    divModal.Attributes.CssStyle.Add("class", "modal modal-dialog");
                    imgTituloModal.Attributes.CssStyle.Add("class", "");
                    lblTituloModal.Text = "Error de sistema";
                    break;
                case 5:
                    bAlert = true;
                    break;
                default:
                    divModal.Attributes.CssStyle.Add("class", "modal modal-dialog");
                    imgTituloModal.Attributes.CssStyle.Add("class", "");
                    lblTituloModal.Text = "Error de sistema";
                    break;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (!bAlert)
            {
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('");
                sb.Append("#mdlModal");
                sb.Append("').modal('show');");
                sb.Append(@"</script>");
            }
            else
            {
                sb.Append(@"<script type='text/javascript'>");
       
                sb.Append("alert('");
                sb.Append(sMensaje);
                sb.Append("');");
                sb.Append(@"</script>");
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), sIdScript, sb.ToString(), false);
        }
    }
}