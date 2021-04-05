using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IELENT.Common;
using IELBUS.Common;

namespace IELWEB.Common
{
    public partial class Configuracion : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VariablesViewState();
                SetGrid(true);
            }
            CargaSiempre();
        }
        protected void btnShowAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('");
            sb.Append("#mdlConfiguracion");
            sb.Append("').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

            lblTituloModal.Text = "Agregar Parametro de Configuración";

            ConfiguracionWUC.ClearConfiguracion();
            ViewState["sEditar"] = string.Empty;
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewState["sEditar"].ToString()))
                AddConfiguracion();
            else
                SetConfiguracion();

            ConfiguracionWUC.ClearConfiguracion();

            ViewState["sEditar"] = string.Empty;

            CargaSiempre();
        }
        #endregion

        #region Carga Inicial
        private void VariablesViewState()
        {
            ViewState["lstConfiguracion"] = new List<ConfiguracionBE>();
            ViewState["sEditar"] = string.Empty;
        }
        private void Cargainicial()
        {

        }
        private void CargaSiempre()
        {
            RegisterGridpaging(grdConfiguracion);
        }
        #endregion

        #region Grid
        private void SetGrid(bool bCargaInicial)
        {
            List<ConfiguracionBE> lstConfiguracion = new List<ConfiguracionBE>();

            if (bCargaInicial)
            {
                lstConfiguracion = GetConfiguracion();
                ViewState["lstConfiguracion"] = lstConfiguracion;
            }
            lstConfiguracion = (List<ConfiguracionBE>)ViewState["lstConfiguracion"];
            grdConfiguracion.DataSource = lstConfiguracion;
            grdConfiguracion.DataBind();


        }
        private void RegisterGridpaging(GridView grd)
        {
            if (grd.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(grd.ClientID);
                sQuery.Append("').dataTable({");
                sQuery.Append("'bPaginate': true,");
                sQuery.Append("'bLengthChange': true,");
                sQuery.Append("'bFilter': true,");
                sQuery.Append("'bSort': true,");
                sQuery.Append("'bInfo': true,");
                sQuery.Append("'bAutoWidth': false");
                sQuery.Append("});});");


                grd.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Propiedades", sQuery.ToString(), true);
            }
        }
        protected void grdConfiguracion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<ConfiguracionBE> lstConfiguracion = (List<ConfiguracionBE>)ViewState["lstConfiguracion"];
            ConfiguracionBE item = new ConfiguracionBE();

            string sIdCatalogo = grdConfiguracion.DataKeys[index].Value.ToString();
            item = lstConfiguracion[int.Parse(sIdCatalogo) - 1];

            if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdConfiguracion.Rows[index];
                sIdCatalogo = grdConfiguracion.DataKeys[index].Value.ToString();
                ViewState["sEditar"] = "1";


                //GridViewRow gvrow = GridView1.Rows[index];
                //lblIDAplicacion.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                //txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                //txtPassword.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

                //lblResult.Visible = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlConfiguracion').modal('show');");
                sb.Append(@"</script>");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlConfiguracionScript", sb.ToString(), false);
                GetConfiguracion(sIdCatalogo);

                sMensajelbl.Append(" EDITAR Configuración ");
                sMensajelbl.Append(item.psDESCRIPCION);

                lblTituloModal.Text = sMensajelbl.ToString();
            }
        }
        #endregion

        #region ConexionInterna
        private List<ConfiguracionBE> GetConfiguracion(string sIdConfiguracion = null)
        {
            List<ConfiguracionBE> lstConfiguracion = new List<ConfiguracionBE>();
            ConfiguracionBR oConBus = new ConfiguracionBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            ConfiguracionBE item = new ConfiguracionBE();


            item.psIDCONFIGAPP = sIdConfiguracion;
            RespuestaComun = oConBus.GetConfigAPP(item);

            if (RespuestaComun.itemError.pbFlag)
            {
                if (sIdConfiguracion == null)
                { ViewState["lstCatGenerales"] = RespuestaComun.lstConfiguracion; }
                else
                {
                    item.psIDCONFIGAPP = RespuestaComun.lstConfiguracion[0].psIDCONFIGAPP.ToString();
                    item.psDESCRIPCION = RespuestaComun.lstConfiguracion[0].psDESCRIPCION.ToString();
                    item.psVALOR = RespuestaComun.lstConfiguracion[0].psVALOR.ToString();
                    item.psACTIVO = RespuestaComun.lstConfiguracion[0].psACTIVO;

                    ConfiguracionWUC.SetConfiguracion(item);
                }

            }
            lstConfiguracion = RespuestaComun.lstConfiguracion;
           

            return lstConfiguracion;

        }

        private void AddConfiguracion()
        {
            ConfiguracionBR oConBus = new ConfiguracionBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            ConfiguracionBE item = new ConfiguracionBE();

            item = ConfiguracionWUC.GetConfiguracion();

            RespuestaComun = oConBus.AddConfigAPP(item);


           

            if (RespuestaComun.itemError.pbFlag)
            {
                SetGrid(true);
            }
        }
        private void SetConfiguracion()
        {
            ConfiguracionBR oconBus = new ConfiguracionBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            ConfiguracionBE item = new ConfiguracionBE();

            item = ConfiguracionWUC.GetConfiguracion();

            RespuestaComun = oconBus.SetConfigAPP(item);

           
            oconBus = null;

            if (RespuestaComun.itemError.pbFlag)
            {
                SetGrid(true);
            }
        }
        #endregion
    }
}