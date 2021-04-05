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
    public partial class Catalogos : System.Web.UI.Page
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
            sb.Append("#mdlCatalogo");
            sb.Append("').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

            CatGeneralesWUC.SetDdlCatalogos(1);

            lblTituloModal.Text = "Agregar Catálogo";

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(@"<script type='text/javascript'>");
            //sb.Append("$('#mdlCatalogo').modal('show');");
            //sb.Append(@"</script>");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ViewState["sEditar"].ToString()))
                AddCatGenerales();
            else
                SetCatGenerales();

            CatGeneralesWUC.ClearGatGenerales();
            CatGeneralesWUC.SetDdlCatalogos(1);

            ViewState["sEditar"] = string.Empty;
        }
        #endregion

        #region Carga Inicial
        private void VariablesViewState()
        {
            ViewState["lstGrdCatGenerales"] = new List<CatGeneralesBE>();
            ViewState["sEditar"] = string.Empty;
        }
        private void Cargainicial()
        {

        }
        private void CargaSiempre()
        {
            RegisterGridpaging(grdCatGenerales);
        }
        #endregion

        #region Grid
        private void SetGrid(bool bCargaInicial)
        {
            List<CatGeneralesBE> lstCatGenerales = new List<CatGeneralesBE>();

            if (bCargaInicial)
            {
                lstCatGenerales = GetCatGenerales();
                ViewState["lstCatGenerales"] = lstCatGenerales;
            }
            lstCatGenerales = (List<CatGeneralesBE>)ViewState["lstCatGenerales"];
            grdCatGenerales.DataSource = lstCatGenerales;
            grdCatGenerales.DataBind();


        }
        private void RegisterGridpaging(GridView grd)
        {
            if (grd.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(grd.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grd.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Propiedades", sQuery.ToString(), true);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<CatGeneralesBE> lstCatGenerales = (List<CatGeneralesBE>)ViewState["lstCatGenerales"];
            CatGeneralesBE item = new CatGeneralesBE();

            string sIdCatalogo = grdCatGenerales.DataKeys[index].Value.ToString();
            item = lstCatGenerales[int.Parse(sIdCatalogo) - 1];

            if (e.CommandName.Equals("AdmonCatalogo"))
            {
                GridViewRow gvrow = grdCatGenerales.Rows[index];

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlAdmon').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlAdmonScript", sb.ToString(), false);

                sMensajelbl.Append(" ADMINISTRAR CATALOGO ");
                sMensajelbl.Append(item.psNOMBRECATALOGO);

                lblAdministrar.Text = sMensajelbl.ToString();
                CatalogosWUC.SetGrid(sIdCatalogo, true);
                CatalogosWUC.RegisterGridpaging();
            }
            else if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = grdCatGenerales.Rows[index];
                sIdCatalogo = grdCatGenerales.DataKeys[index].Value.ToString();
                ViewState["sEditar"] = "1";


                //GridViewRow gvrow = GridView1.Rows[index];
                //lblIDAplicacion.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text).ToString();
                //txtDescripcion.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                //txtPassword.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

                //lblResult.Visible = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#mdlCatalogo').modal('show');");
                sb.Append(@"</script>");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mdlCatalogoScript", sb.ToString(), false);
                CatGeneralesWUC.SetDdlCatalogos(2);
                GetCatGenerales(sIdCatalogo);

                sMensajelbl.Append(" EDITAR CATALOGO ");
                sMensajelbl.Append(item.psNOMBRECATALOGO);

                lblTituloModal.Text = sMensajelbl.ToString();
            }
        }
        #endregion

        #region Catalogos
        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oCatBus = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            Respuesta = oCatBus.GetCatEspecifico(sIdCatalogo, sValorFiltro);

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
        #endregion

        #region ConexionInterna
        private List<CatGeneralesBE> GetCatGenerales(string sIdCatGenerales = null)
        {
            List<CatGeneralesBE> lstCatGenerales = new List<CatGeneralesBE>();
            CatalogosBR oCatBus = new CatalogosBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            CatGeneralesBE item = new CatGeneralesBE();


            item.psIDCATGENERALES = sIdCatGenerales;
            RespuestaComun = oCatBus.GetCatGenerales(item);

            if (RespuestaComun.itemError.pbFlag)
            {
                if (sIdCatGenerales == null)
                { ViewState["lstCatGenerales"] = RespuestaComun.lstCatGenerales; }
                else
                {
                    item.psNOMBRECATALOGO = RespuestaComun.lstCatGenerales[0].psNOMBRECATALOGO.ToString();
                    item.psIDCATALOGO = RespuestaComun.lstCatGenerales[0].psIDCATALOGO.ToString();
                    item.psFILTRO = RespuestaComun.lstCatGenerales[0].psFILTRO.ToString();
                    item.psDESCRIPCION = RespuestaComun.lstCatGenerales[0].psDESCRIPCION.ToString();
                    item.psACTIVO = RespuestaComun.lstCatGenerales[0].psACTIVO;

                    CatGeneralesWUC.SetCatGenerales(item);
                }


            }
            lstCatGenerales = RespuestaComun.lstCatGenerales;
            

            return lstCatGenerales;

        }
        private void AddCatGenerales()
        {
            CatalogosBR oCatBus = new CatalogosBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            CatGeneralesBE item = new CatGeneralesBE();

            item = CatGeneralesWUC.GetCatGenerales();

            RespuestaComun = oCatBus.AddCatGenerales(item);

           

            if (RespuestaComun.itemError.pbFlag)
            {
                SetGrid(true);
            }
        }
        private void SetCatGenerales()
        {
            CatalogosBR oCatBus = new CatalogosBR();
            RespuestaComunBE RespuestaComun = new RespuestaComunBE();
            CatGeneralesBE item = new CatGeneralesBE();

            item = CatGeneralesWUC.GetCatGenerales();

            RespuestaComun = oCatBus.SetCatGenerales(item);
            //RespuestaComun = oCommonServiceClient.AddCatGenerales(item);

            

            if (RespuestaComun.itemError.pbFlag)
            {
                SetGrid(true);
            }
        }
        #endregion


        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    CommonServiceClient oCommonServiceClient = new CommonServiceClient();
        //    RespuestaComunBE RespuestaComun = new RespuestaComunBE();
        //    CatGeneralesBE item = new CatGeneralesBE();

        //    //item = SetCatGeneralesItemEditar();

        //    //RespuestaComun = oCommonServiceClient.SetCatGenerales(item);
        //    //RespuestaComun = oCommonServiceClient.AddCatGenerales(item);

        //    if (RespuestaComun.itemError.pbFlag)
        //    {
        //        SetGrid(true);
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        sb.Append(@"<script type='text/javascript'>");
        //        sb.Append("alert('Se actualizo el catalogo');");
        //        sb.Append("$('#editModal').modal('hide');");
        //        sb.Append(@"</script>");
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
        //    }
        //    else
        //    {
        //        SetGrid(false);
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        sb.Append(@"<script type='text/javascript'>");
        //        sb.Append("alert('No fue posible realizar la operacion, intente mas tarde.');");
        //        sb.Append("$('#mdlCatalogo').modal('hide');");
        //        sb.Append(@"</script>");
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript2", sb.ToString(), false);
        //    }



        //}

        
    }
}










