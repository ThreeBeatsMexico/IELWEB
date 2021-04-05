using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IELENT.User;
using IELBUS.Common;
using IELENT.Common;


namespace IELWEB.Usuarios.UserControls
{
    public partial class ContactoWUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargaInicial();
            //CargarSiempre();
        }
        private void CargaInicial()
        {
            VariablesViewState();
            SetDdlCatalogos(ddlTipoContacto, "9");
            SetValidationExpresion();
        }
        private void VariablesViewState()
        {
            ViewState["lstContactos"] = new List<ContactoBE>();
            ViewState["RowIndex"] = string.Empty;
        }
        private void CargarSiempre()
        {
            List<ContactoBE> lstContacto = new List<ContactoBE>();
            lstContacto = (List<ContactoBE>)ViewState["lstContactos"];
            //ClearGrid();
            SetGrid(lstContacto, true);
        }
        private void SetDdlCatalogos(DropDownList ddl, string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosBR oCommonServiceClient = new CatalogosBR();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            Respuesta = oCommonServiceClient.GetCatEspecifico(sIdCatalogo, sValorFiltro);

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
        public void RegisterGridpaging()
        {
            if (grdContacto.Rows.Count > 0)
            {
                StringBuilder sQuery = new StringBuilder(string.Empty);
                sQuery.Append("$(function () {$('#");
                sQuery.Append(this.grdContacto.ClientID);
                sQuery.Append("').dataTable({");
                //sQuery.Append("'sScrollX':'300px',");
                sQuery.Append("'bStateSave': true");
                sQuery.Append("});});");




                grdContacto.HeaderRow.TableSection = TableRowSection.TableHeader;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StylegrdContactoWUC", sQuery.ToString(), true);
            }
        }
        public List<ContactoBE> GetContactos()
        {
            List<ContactoBE> lstContactos = new List<ContactoBE>();

            lstContactos = (List<ContactoBE>)ViewState["lstContactos"];

            return lstContactos;
        }
        public void ClearContacto()
        {
            txtIdContacto.Text = string.Empty;
            txtValor.Text = string.Empty;
            ddlTipoContacto.SelectedValue = "0";
            txtIdContacto.Text = string.Empty;
        }
        public void ClearGrid()
        {
            ViewState["lstContactos"] = new List<ContactoBE>();
            grdContacto.DataSource = null;
            grdContacto.DataBind();
        }
        private ContactoBE GetContacto()
        {
            ContactoBE item = new ContactoBE();

            item.IDTIPOCONTACTO = int.Parse(ddlTipoContacto.SelectedValue);
            item.TIPOCONTACTO = ddlTipoContacto.SelectedItem.ToString();
            item.VALOR = txtValor.Text;
            item.IDCONTACTO = string.IsNullOrEmpty(txtIdContacto.Text) ? 0 : long.Parse(txtIdContacto.Text);
            item.RowIndex = ViewState["RowIndex"].ToString();
            return item;
        }
        public void SetContacto(ContactoBE item)
        {
            ddlTipoContacto.SelectedValue = item.IDTIPOCONTACTO.ToString();
            SetValidationExpresion();
            txtValor.Text = item.VALOR;
            txtIdContacto.Text = item.IDCONTACTO.ToString();
            ViewState["RowIndex"] = item.RowIndex;

        }
        public void SetGrid(List<ContactoBE> lstContactos, bool bCargaInicial = false)
        {
            if (bCargaInicial)
                ViewState["lstContactos"] = lstContactos;

            lstContactos = (List<ContactoBE>)ViewState["lstContactos"];
            grdContacto.DataSource = lstContactos;
            grdContacto.DataBind();
        }

        protected void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            List<ContactoBE> lstContacto = new List<ContactoBE>();
            ContactoBE item = new ContactoBE();
            bool bExiste = false;

            lstContacto = (List<ContactoBE>)ViewState["lstContactos"];

            item = GetContacto();

            foreach (var itemFor in lstContacto)
            {
                if (item.IDTIPOCONTACTO == itemFor.IDTIPOCONTACTO && item.IDCONTACTO == 0)
                {
                    bExiste = true;
                    break;
                }
            }

            if (bExiste)
            {
                Common.UserControls.MensajeWUC oMensajeWUC = this.Parent.FindControl("MensajeWUC") as Common.UserControls.MensajeWUC;
                oMensajeWUC.SetMensaje("Ya se ha agragado un contacto del tipo que selecciono", 5, "AlertContacto");
                RegisterGridpaging();
                RegisterExternarScripts();
                return;
            }

            if (item.IDCONTACTO != 0)
            {
                item.Actualizado = true;
                lstContacto.RemoveAt(int.Parse(item.RowIndex));
                lstContacto.Add(item);
            }
            else
            {
                item.IDCONTACTO = 0;
                lstContacto.Add(item);
            }
            ViewState["lstDomicilio"] = lstContacto;

            SetGrid(lstContacto);

            ClearContacto();
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void grdContacto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sMensajelbl = new StringBuilder(string.Empty);
            List<ContactoBE> lstContactos = (List<ContactoBE>)ViewState["lstContactos"];
            GridViewRow gvrow = grdContacto.Rows[index];
            ContactoBE item = new ContactoBE();

            string sIdUsuario = grdContacto.DataKeys[index].Value.ToString();

            if (e.CommandName.Equals("EditContacto"))
            {

                lstContactos = (List<ContactoBE>)ViewState["lstContactos"];
                item = lstContactos[index];
                item.RowIndex = index.ToString();
                SetContacto(item);
            }
            else if (e.CommandName.Equals("DeleteContacto"))
            {
                lstContactos = (List<ContactoBE>)ViewState["lstContactos"];
                item = lstContactos[index];

                if (item.IDCONTACTO.ToString() != "0")
                {
                    //MensajeWUC.SetMensaje("No puede eliminar contactos existentes.", 2);
                    RegisterGridpaging();
                    RegisterExternarScripts();
                    return;
                }

                lstContactos.RemoveAt(index);
                SetGrid(lstContactos, true);
            }

            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void btnCancelarContactos_Click(object sender, EventArgs e)
        {
            ClearContacto();
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        protected void ddlTipoContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValidationExpresion();
            RegisterGridpaging();
            RegisterExternarScripts();
        }
        private void SetValidationExpresion()
        {
            int dIdTipoContacto = int.Parse(ddlTipoContacto.SelectedValue);
            string sRegularExpresion = string.Empty;

            switch (dIdTipoContacto)
            {
                case 0:
                    reqValor.Enabled = false;
                    break;
                case 1:
                case 2:
                    sRegularExpresion = @"\d+";
                    reqValor.Enabled = true;
                    break;
                case 3:
                    sRegularExpresion = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    reqValor.Enabled = true;
                    break;
                case 4:
                    sRegularExpresion = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                    reqValor.Enabled = true;
                    break;
                default:
                    sRegularExpresion = @"\d+";
                    reqValor.Enabled = true;
                    break;
            }

            rexValor.ValidationExpression = sRegularExpresion;
        }
        private void RegisterExternarScripts()
        {
            Usuarios.UserControls.DomicilioWUC oDomicilioWUC = this.Parent.FindControl("DomicilioWUC") as Usuarios.UserControls.DomicilioWUC;
            if (oDomicilioWUC != null)
                oDomicilioWUC.RegisterGridpaging();

            Usuarios.UserControls.UserWUC oUserWUC = this.Parent.FindControl("UserWUC") as Usuarios.UserControls.UserWUC;
            if (oUserWUC != null)
                oUserWUC.RegisterFileUpload();

            Usuarios.UserControls.PermisosWUC oPermisosWUC = this.Parent.FindControl("PermisosWUC") as Usuarios.UserControls.PermisosWUC;
            if (oPermisosWUC != null)
                oPermisosWUC.RegisterGridpaging();

            
        }

    }
}