using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELENT.Common;
using IELBUS.Common;

namespace IELWEB.Common.UserControls
{
    public partial class CatGeneralesWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Carga el catalogo dependiento de la Operación
        /// </summary>
        /// <param name="dTipoOperacion">1.- Inserta, 2.- Actualiza</param>
        public void SetDdlCatalogos(int dTipoOperacion)
        {
            switch (dTipoOperacion)
            {
                case 1://Inserta
                    SetDdlCatalogos(ddlCatGenerales, "1");
                    break;
                case 2://Actualiza
                    SetDdlCatalogos(ddlCatGenerales, "2");
                    break;
                default:
                    SetDdlCatalogos(ddlCatGenerales, "1");
                    break;
            }

        }
        public void SetCatGenerales(CatGeneralesBE item)
        {
            txtColumnaId.Text = item.psIDCATALOGO.ToUpper();
            ddlCatGenerales.SelectedValue = item.psIDCATGENERALES.ToUpper();

            txtDescripcion.Text = item.psDESCRIPCION.ToUpper();
            txtFiltro.Text = item.psFILTRO.ToUpper();
            chkActivo.Checked = bool.Parse(item.psACTIVO);
        }

        public CatGeneralesBE GetCatGenerales()
        {
            CatGeneralesBE item = new CatGeneralesBE();
            item.psIDCATALOGO = txtColumnaId.Text.ToUpper();
            //item.psIDCATGENERALES = ddlCatGenerales.SelectedValue;
            item.psNOMBRECATALOGO = ddlCatGenerales.SelectedItem.ToString().ToUpper();
            if (chkPersonalizado.Checked)
                item.psNOMBRECATALOGO = txtCatGenerales.Text;
            item.psDESCRIPCION = txtDescripcion.Text.ToUpper();
            item.psFILTRO = txtFiltro.Text.ToUpper();
            item.psACTIVO = chkActivo.Checked == true ? "1" : "0";

            return item;
        }

        public void ClearGatGenerales()
        {
            SetDdlCatalogos(ddlCatGenerales, "2");
            ddlCatGenerales.SelectedValue = "0";
            txtCatGenerales.Text = string.Empty;
            txtColumnaId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtFiltro.Text = string.Empty;
            chkActivo.Checked = false;
        }

        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oBus = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();


            if (sIdCatalogo != "0")
                Respuesta = oBus.GetCatEspecifico(sIdCatalogo, sValorFiltro);
            else return;

            List<CatalogosBE> lstDdl = new List<CatalogosBE>();
            CatalogosBE item = new CatalogosBE();

            item.ID = "0";
            item.DESCRIPCION = "Seleccione Opción..";

            lstDdl.Add(item);
            lstDdl.AddRange(Respuesta.lstCatalogo);

            ddl.DataSource = lstDdl;
            ddl.DataValueField = "ID";
            ddl.DataTextField = "DESCRIPCION";

            ddl.DataBind();
        }

        protected void ddlCatGenerales_TextChanged(object sender, EventArgs e)
        {
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            CommonBR oBus = new CommonBR();
            string sNombreTabla = ddlCatGenerales.SelectedItem.ToString();

            Respuesta = oBus.GetDefinicionTabla(sNombreTabla);

            txtColumnaId.Text = Respuesta.psIdentityTabla;
            txtDescripcion.Text = Respuesta.psDescripcionTabla;

           
        }

        protected void chkPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            txtCatGenerales.Text = string.Empty;
            txtCatGenerales.Visible = chkPersonalizado.Checked;
            ddlCatGenerales.Visible = !chkPersonalizado.Checked;

            txtColumnaId.Enabled = chkPersonalizado.Checked;
            txtDescripcion.Enabled = chkPersonalizado.Checked;
            txtFiltro.Enabled = chkPersonalizado.Checked;

        }


    }
}