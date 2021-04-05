using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using IELENT.Security;
using IELBUS.Security;
using IELBUS.Common;
using IELENT.Common;



namespace IELWEB.Permisos.UserControls
{
    public partial class MetodosWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargaInicial();
            CargaSiempre();
        }
        private void CargaInicial()
        {
            SetDdlCatalogos(ddlAplicacion, "13");
            VariablesViewstate();
        }
        private void CargaSiempre()
        {
        }
        private void VariablesViewstate()
        {
            ViewState["lstMetodos"] = new List<WCFMetodosBE>();
            ViewState["RowIndex"] = string.Empty;
        }
        public void RegisterGridPaging()
        {
            if (grdMetodos.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(this.grdMetodos.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grdMetodos.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StylegrdMetodosWUC", sQuery.ToString(), true);
            }
        }
        public void SetGrid(bool bCargaInicial)
        {
            List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();
            if (bCargaInicial)
            {
                SecurityBR oSecurity = new SecurityBR();
                Int64 App = Int64.Parse(ddlAplicacion.SelectedValue);
                List<WCFMetodosBE> oMetodos = new List<WCFMetodosBE>();
               
                string sServiceName = ddlServicio.SelectedItem.ToString();

                oMetodos = oSecurity.checkMetodoXApp(App, sServiceName, "");
                ViewState["lstMetodos"] = oMetodos;
            }
            lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];

            grdMetodos.DataSource = lstMetodos;
            grdMetodos.DataBind();
        }
        private void SetMetodo(WCFMetodosBE item)
        {
            txtIdMetodo.Text = item.IDMETODOS.ToString();
            ddlAplicacion.SelectedValue = item.IDAPLICACION.ToString();
            ddlServicio.SelectedValue = item.IDSERVICIOS.ToString();
            txtNombre.Text = item.NOMBREMETODO;
            chkRecurrente.Checked = item.RECURRENTE;
            chkActivo.Checked = item.ACTIVO;
            ViewState["RowIndex"] = item.RowIndex;
        }
        private WCFMetodosBE GetMetodo()
        {
            WCFMetodosBE item = new WCFMetodosBE();

            item.IDMETODOS = long.Parse(string.IsNullOrEmpty(txtIdMetodo.Text) ? "0" : txtIdMetodo.Text);
            item.IDAPLICACION = long.Parse(ddlAplicacion.SelectedValue);
            item.IDSERVICIOS = long.Parse(ddlServicio.SelectedValue);
            item.NOMBREMETODO = txtNombre.Text;
            item.RECURRENTE = chkRecurrente.Checked;
            item.ACTIVO = chkActivo.Checked;
            item.RowIndex = ViewState["RowIndex"].ToString();

            return item;
        }
        private void ClearMetodos()
        {
            txtIdMetodo.Text = "0";
            ddlAplicacion.SelectedValue = "0";
            ddlServicio.SelectedValue = "0";
            txtNombre.Text = string.Empty;
            chkRecurrente.Checked = false;
            chkActivo.Checked = false;
            ViewState["RowIndex"] = string.Empty;
        }
        public List<WCFMetodosBE> GetMetodos()
        {
            List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();

            lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];

            return lstMetodos;
        }

        protected void ddlAplicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDdlCatalogos(ddlServicio, "12");
            RegisterGridPaging();
        }
        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGrid(true);
            RegisterGridPaging();
        }
        protected void btnAgregarMetodo_Click(object sender, EventArgs e)
        {
            List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();
            WCFMetodosBE item = new WCFMetodosBE();
            bool bExiste = false;

            lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];
            item = GetMetodo();

            foreach (var itemfor in lstMetodos)
            {
                if (itemfor.IDAPLICACION == item.IDAPLICACION && itemfor.IDSERVICIOS == item.IDSERVICIOS && item.IDMETODOS == 0)
                {
                    if (itemfor.NOMBREMETODO.ToLower() == item.NOMBREMETODO.ToLower())
                    {
                        bExiste = true;
                        break;
                    }
                }
            }

            if (bExiste)
            {
                RegisterGridPaging();
                Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                oMensajeWUC.SetMensaje("Ya se ha agragado un Servicio con las caracteristicas Agregadas", 5, "AlertAddMetodos");

                //RegisterExternarScripts();
                return;
            }


            if (item.IDMETODOS != 0)
            {
                //item.Actualizado = true;
                //Validar si no se ha agregado el registro Seleccionado
                lstMetodos.RemoveAt(int.Parse(item.RowIndex));
                item.Actualizado = true;
                lstMetodos.Add(item);
            }
            else
            {
                item.IDMETODOS = 0;
                lstMetodos.Add(item);
            }

            ViewState["lstDomicilio"] = lstMetodos;

            SetGrid(false);

            ClearMetodos();
            RegisterGridPaging();
        }
        protected void btnCancelarMetodo_Click(object sender, EventArgs e)
        {
            ClearMetodos();
            RegisterGridPaging();
        }
        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oComBus = new CatalogosBR(); ;
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            Respuesta = oComBus.GetCatEspecifico(sIdCatalogo, sValorFiltro);

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
        protected void grdMetodos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<WCFMetodosBE> lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];
            GridViewRow gvrow = grdMetodos.Rows[index];
            WCFMetodosBE item = new WCFMetodosBE();

            string sIdUsuario = grdMetodos.DataKeys[index].Value.ToString();

            if (e.CommandName.Equals("EditMetodo"))
            {
                lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];
                item = lstMetodos[index];
                item.RowIndex = index.ToString();
                SetMetodo(item);
            }

            RegisterGridPaging();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SecurityBR oSec = new SecurityBR();
            List<WCFMetodosBE> lstMetodos = new List<WCFMetodosBE>();
            List<WCFMetodosBE> lstFiltros = new List<WCFMetodosBE>();
            bool metodo;
            string sMensaje = string.Empty;

            lstMetodos = (List<WCFMetodosBE>)ViewState["lstMetodos"];

            lstFiltros.AddRange(lstMetodos.Where(Filtro => Filtro.Actualizado == true).ToList<WCFMetodosBE>());
            lstFiltros.AddRange(lstMetodos.Where(Filtro => Filtro.IDMETODOS == 0).ToList<WCFMetodosBE>());

            if (lstFiltros.Count > 0)
            {
                metodo = oSec.addMetodo(lstFiltros, long.Parse(ResIEL.IdApp));

                if (metodo)
                    sMensaje = "Se actualizaron los accesos a los metodos correctamemente";
                else
                    sMensaje = "Existió un error al actualizar los metodos";
            }
            else
                sMensaje = "No se modificó o agregó ningún registro";

            SetGrid(true);
            RegisterGridPaging();
            Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
            oMensajeWUC.SetMensaje(sMensaje, 5, "AlertAddMetodos");
        }
    }
}