using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IELENT.User;
using IELBUS;
using IELENT;


namespace IELWEB.Usuarios.UserControls
{
    public partial class DomicilioWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaInicial();
            }
        }
        private void CargaInicial()
        {
            VariablesViewState();
        }
        private void VariablesViewState()
        {
            ViewState["lstDomicilio"] = new List<DomicilioBE>();
            ViewState["RowIndex"] = string.Empty;
        }
        private void CargarSiempre()
        {
            List<DomicilioBE> lstDomicilio = new List<DomicilioBE>();
            lstDomicilio = (List<DomicilioBE>)ViewState["lstDomicilio"];
            SetGrid(lstDomicilio, true);
        }
        public void RegisterGridpaging()
        {
            if (grdDomicilio.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(this.grdDomicilio.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");

                grdDomicilio.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StylegrdDomicilioWUC", sQuery.ToString(), true);
            }
        }
        public List<DomicilioBE> GetDomicilios()
        {
            List<DomicilioBE> lstDomicilios = new List<DomicilioBE>();

            lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];

            return lstDomicilios;
        }
        public void ClearDomicilio()
        {
            txtIdDomicilio.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtNumeroExterior.Text = string.Empty;
            txtNumerointerior.Text = string.Empty;
            ddlColonia.DataSource = new List<string>();
            ddlColonia.DataBind();
            ddlEstado.DataSource = new List<string>();
            ddlEstado.DataBind();
            ddlMunicipio.DataSource = new List<string>();
            ddlMunicipio.DataBind();
            txtIdDomicilio.Text = string.Empty;
        }
        public void ClearGrid()
        {
            ViewState["lstDomicilio"] = new List<DomicilioBE>();
            grdDomicilio.DataSource = null;
            grdDomicilio.DataBind();
        }
        public void SetGrid(List<DomicilioBE> lstDomicilios, bool bCargaInicial = false)
        {
            if (bCargaInicial)
                ViewState["lstDomicilio"] = lstDomicilios;

            lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];
            grdDomicilio.DataSource = lstDomicilios;
            grdDomicilio.DataBind();
        }
        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            List<DomicilioBE> lstDomicilios = new List<DomicilioBE>();
            DomicilioBE item = new DomicilioBE();

            lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];
            item = GetDomicilio();
            if (item.IDDOMICILIO != 0)
            {
                item.Actualizado = true;
                lstDomicilios.RemoveAt(int.Parse(item.RowIndex));
                lstDomicilios.Add(item);
            }
            else
            {
                item.IDDOMICILIO = 0;
                lstDomicilios.Add(item);
            }

            ViewState["lstDomicilio"] = lstDomicilios;

            SetGrid(lstDomicilios);

            ClearDomicilio();
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        private DomicilioBE GetDomicilio()
        {
            DomicilioBE item = new DomicilioBE();

            item.CALLE = txtCalle.Text;
            item.NUMEXT = txtNumeroExterior.Text;
            item.NUMINT = txtNumerointerior.Text;
            item.CP = txtCP.Text;
            item.COLONIA = ddlColonia.SelectedItem.ToString();
            item.IDCOLONIA = ddlColonia.SelectedValue.ToString();
            item.MUNICIPIO = ddlMunicipio.SelectedItem.ToString();
            item.IDMUNICIPIO = ddlMunicipio.SelectedValue.ToString();
            item.ESTADO = ddlEstado.SelectedItem.ToString();
            item.IDESTADO = ddlEstado.SelectedValue.ToString();
            item.IDDOMICILIO = string.IsNullOrEmpty(txtIdDomicilio.Text) ? 0 : long.Parse(txtIdDomicilio.Text);
            item.RowIndex = ViewState["RowIndex"].ToString();

            return item;
        }
        private void SetDomicilio(DomicilioBE item)
        {
            txtCalle.Text = item.CALLE;
            txtNumeroExterior.Text = item.NUMEXT;
            txtNumerointerior.Text = item.NUMINT;
            txtCP.Text = item.CP;
            //SetCP();
            ddlEstado.SelectedValue = item.IDESTADO.ToString();
            ddlColonia.SelectedValue = item.IDCOLONIA.ToString();
            ddlMunicipio.SelectedValue = item.IDMUNICIPIO.ToString();
            txtIdDomicilio.Text = item.IDDOMICILIO.ToString();
            ViewState["RowIndex"] = item.RowIndex;
        }
        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
           // SetCP();
        }
        private void SetCP()
        {
            if (!string.IsNullOrEmpty(txtCP.Text))
            {
                ColoniaBR oCPServiceClient = new ColoniaBR();
                List<ColoniaBE> lstColonia = new List<ColoniaBE>();
                ColoniaBE itemInicial = new ColoniaBE();

                string sRegistroInicial = "Seleccione Opción";

                itemInicial.ClaveEntidad = "0";
                itemInicial.NombreEstado = sRegistroInicial;
                itemInicial.ClaveMunicipio = "0";
                itemInicial.NombreMunicpio = sRegistroInicial;
                itemInicial.ClaveColonia = "0";
                itemInicial.NombreColonia = sRegistroInicial;

                lstColonia.Add(itemInicial);

                lstColonia.AddRange(oCPServiceClient.ObtenerInformacionPorCP(txtCP.Text));

                if (lstColonia.Count > 1)
                {
                    ddlEstado.DataValueField = "ClaveEntidad";
                    ddlEstado.DataTextField = "NombreEstado";
                    ddlEstado.DataSource = lstColonia;
                    ddlEstado.DataBind();
                    ddlEstado.SelectedIndex = 1;
                    ddlEstado.Enabled = false;

                    ddlMunicipio.DataValueField = "ClaveMunicipio";
                    ddlMunicipio.DataTextField = "NombreMunicpio";
                    ddlMunicipio.DataSource = lstColonia;
                    ddlMunicipio.DataBind();
                    ddlMunicipio.SelectedIndex = 1;
                    ddlMunicipio.Enabled = false;

                    ddlColonia.DataValueField = "ClaveColonia";
                    ddlColonia.DataTextField = "NombreColonia";
                    ddlColonia.DataSource = lstColonia;
                    ddlColonia.DataBind();
                    ddlColonia.SelectedIndex = 0;
                }
            }
        }
        protected void btnCancelarDomicilios_Click(object sender, EventArgs e)
        {
            ClearDomicilio();
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void grdDomicilio_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<DomicilioBE> lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];
            GridViewRow gvrow = grdDomicilio.Rows[index];
            DomicilioBE item = new DomicilioBE();

            string sIdUsuario = grdDomicilio.DataKeys[index].Value.ToString();

            if (e.CommandName.Equals("EditDomicilio"))
            {

                lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];
                item = lstDomicilios[index];
                item.RowIndex = index.ToString();
                SetDomicilio(item);
            }
            else if (e.CommandName.Equals("DeleteDomicilio"))
            {
                lstDomicilios = (List<DomicilioBE>)ViewState["lstDomicilio"];
                item = lstDomicilios[index];
                
                if (item.IDDOMICILIO.ToString() !="0")
                {
                    Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                    oMensajeWUC.SetMensaje("No puede eliminar domicilio existentes.", 2, "mdlMensaje");
                    RegisterGridpaging();
                    RegisterExternarScripts();
                    return;
                }

                lstDomicilios.RemoveAt(index);
                SetGrid(lstDomicilios,true);
            }

            RegisterGridpaging();
            RegisterExternarScripts();
        }

        private void RegisterExternarScripts()
        {
            Usuarios.UserControls.PermisosWUC oPermisosWUC = this.Parent.FindControl("PermisosWUC") as Usuarios.UserControls.PermisosWUC;
            if (oPermisosWUC != null)
                oPermisosWUC.RegisterGridpaging();

            Usuarios.UserControls.UserWUC oUserWUC = this.Parent.FindControl("UserWUC") as Usuarios.UserControls.UserWUC;
            if (oUserWUC != null)
                oUserWUC.RegisterFileUpload();

            Usuarios.UserControls.ContactoWUC oContactoWUC = this.Parent.FindControl("ContactoWUC") as Usuarios.UserControls.ContactoWUC;
            if (oContactoWUC != null)
                oContactoWUC.RegisterGridpaging();


        }
    }
}