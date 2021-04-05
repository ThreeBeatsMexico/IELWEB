using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELBUS.Common;
using IELENT.Common;

namespace IELWEB.Common.UserControls
{
    public partial class ConfiguracionWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void SetConfiguracion(ConfiguracionBE item)
        {
            txtIdConfiguracion.Text = item.psIDCONFIGAPP.ToUpper();
            txtDescripcion.Text = item.psDESCRIPCION.ToUpper();
            txtValor.Text = item.psVALOR;
            chkActivo.Checked = bool.Parse(item.psACTIVO);
        }

        public ConfiguracionBE GetConfiguracion()
        {
            ConfiguracionBE item = new ConfiguracionBE();
            item.psIDCONFIGAPP = txtIdConfiguracion.Text.ToUpper();
            item.psDESCRIPCION = txtDescripcion.Text.ToUpper();
            item.psVALOR = txtValor.Text;
            item.psACTIVO = chkActivo.Checked == true ? "1" : "0";

            return item;
        }

        public void ClearConfiguracion()
        {
            txtIdConfiguracion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtValor.Text = string.Empty;
            chkActivo.Checked = false;
        }
    }
}