using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IELENT.Common;
using IELBUS.Common;

namespace IELWEB.Common.UserControls
{
    public partial class CatalogosWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
            CargaSiempre();
        }
        private void CargaInicial()
        {
            txtDescripcion.Text = string.Empty;
            VariablesViewState();
        }
        private void CargaSiempre()
        {
            ClearGrid();
        }
        public void RegisterGridpaging()
        {
            if (grdAdmonCatalogos.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(this.grdAdmonCatalogos.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grdAdmonCatalogos.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StylegrdCatalogosWUC", sQuery.ToString(), true);
            }
        }
        private void VariablesViewState()
        {
            ViewState["lstCatalogo"] = new List<CatalogosBE>();
            ViewState["sIdCatalogo"] = string.Empty;
        }
        public void SetGrid(string sIdCatalogo, bool bCargaInicial = false)
        {
            List<CatalogosBE> lstCatalogo = new List<CatalogosBE>();
            txtDescripcion.Text = string.Empty;
            ViewState["sIdCatalogo"] = sIdCatalogo;
            if (bCargaInicial)
            {
                CatalogosBR oBus = new CatalogosBR();
               
                RespuestaComunBE Respuesta = new RespuestaComunBE();

                Respuesta = oBus.GetCatEspecifico(sIdCatalogo, "");
                ViewState["lstCatalogo"] = Respuesta.lstCatalogo;

                Respuesta = null;
               
            }

            lstCatalogo = (List<CatalogosBE>)ViewState["lstCatalogo"];
            grdAdmonCatalogos.DataSource = lstCatalogo;
            grdAdmonCatalogos.DataBind();
        }
        public void ClearGrid()
        {
            grdAdmonCatalogos.DataSource = null;
            grdAdmonCatalogos.DataBind();
        }
        protected void grdAdmonCatalogos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void btnAddCatEspecifico_Click(object sender, EventArgs e)
        {
            CatalogosBR oBus = new CatalogosBR();
            string sDescripcion = txtDescripcion.Text.ToUpper();
            string sIdCatalogo = ViewState["sIdCatalogo"].ToString();

            oBus.AddCatEspecifico(sIdCatalogo, sDescripcion);

            
            SetGrid(sIdCatalogo, true);
            RegisterGridpaging();
        }

    }
}