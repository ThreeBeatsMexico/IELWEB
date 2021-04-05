using IELENT.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IELWEB.Roles.UserControls
{
    public partial class AddMenuWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMenuInfo(PermisosXMenuBE item)
        {
            txtIDMenu.Text = item.IDPERMISOSMENU.ToString();
            txtNombreMenu.Text = item.NOMBREMENU;
            txtTipoObjeto.Text = item.TIPOOBJETO;
            txtUrl.Text = item.URL;
            txtOrdenMenu.Text = item.ORDENMENU.ToString();
            txtToolTip.Text = item.TOOLTIP;
            txtImagen.Text = item.IMAGEN;
            chkActivo.Checked = item.ACTIVO;
        }

        public PermisosXMenuBE GetMenuItem(Int64 idRol)
        {
            PermisosXMenuBE item = new PermisosXMenuBE();
            int idOrden = 0;
            long idMenu = 0;
            if (!String.IsNullOrEmpty(txtOrdenMenu.Text)) { idOrden = Convert.ToInt32(txtOrdenMenu.Text);}
            if (!String.IsNullOrEmpty(txtIDMenu.Text)) { idMenu = Convert.ToInt32(txtIDMenu.Text); }
            item.IDPERMISOSMENU = idMenu;
            item.IDROL = idRol;
            item.NOMBREMENU = txtNombreMenu.Text;
            item.TIPOOBJETO = txtTipoObjeto.Text;
            item.URL = txtUrl.Text;
            item.TOOLTIP = txtToolTip.Text;
            item.ORDENMENU = idOrden;
            item.IMAGEN = txtImagen.Text;
            item.ACTIVO = chkActivo.Checked;
            return item;
        }

        public void ClearMenuItem()
        {
            txtIDMenu.Text = string.Empty;
            txtNombreMenu.Text = string.Empty;
            txtTipoObjeto.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtToolTip.Text = string.Empty;
            txtOrdenMenu.Text = string.Empty;
            txtImagen.Text = string.Empty;
            chkActivo.Checked = false;
        }

    }
}