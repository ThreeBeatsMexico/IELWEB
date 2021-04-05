
using IELENT.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELWEB.Roles.UserControls
{
    public partial class AddSubMenuWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetSubMenuInfo(PermisosXSubmenuBE item)
        {
            txtIDMenu.Text = item.IDPERMISOSMENU.ToString();
            txtIDSubMenu.Text = item.IDPERMISOSXSUBMENU.ToString();
            txtNombreSubMenu.Text = item.NOMBRESUBMENU;
            txtTipoObjeto.Text = item.TIPOOBJETO;
            txtUrl.Text = item.URL;
            txtOrdenSubMenu.Text = item.ORDENSUBMENU.ToString();
            txtToolTip.Text = item.TOOLTIP;
            txtImagen.Text = item.IMAGEN;
            chkActivo.Checked = item.ACTIVO;
        }

        public PermisosXSubmenuBE GetSubMenuItem()
        {
            PermisosXSubmenuBE item = new PermisosXSubmenuBE();
            item.IDPERMISOSXSUBMENU = long.Parse(txtIDSubMenu.Text);
            item.IDPERMISOSMENU = long.Parse(txtIDMenu.Text);
            item.NOMBRESUBMENU = txtNombreSubMenu.Text;
            item.TIPOOBJETO = txtTipoObjeto.Text;
            item.URL = txtUrl.Text;
            item.TOOLTIP = txtToolTip.Text;
            item.ORDENSUBMENU = Convert.ToInt32(txtOrdenSubMenu.Text);
            item.IMAGEN = txtImagen.Text;
            item.ACTIVO = chkActivo.Checked;
            return item;
        }

        public void ClearSubMenuItem()
        {
            txtIDMenu.Text = string.Empty;
            txtIDSubMenu.Text = string.Empty;
            txtNombreSubMenu.Text = string.Empty;
            txtTipoObjeto.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtToolTip.Text = string.Empty;
            txtOrdenSubMenu.Text = string.Empty;
            txtImagen.Text = string.Empty;
            chkActivo.Checked = false;
        }
    }
}