
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using IELENT;
using IELENT.Security;
using IELBUS.Security;


namespace IELWEB.Aplicaciones
{
    public partial class AplicacionesLista : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage("Login.aspx");
            }
            else
            {
                try
                {
                    if (!Page.IsPostBack)
                    {
                        CargaGrid();
                       
                    }
                    RegisterGridpaging(GridView1); 
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void CargaGrid()
        {
            string idApp = string.Empty;
            List<AplicacionBE> oAplicaciones = new List<AplicacionBE>();
            SecurityBR oSec = new SecurityBR();
            oAplicaciones = oSec.getAplicaciones(idApp, string.Empty, long.Parse(ResIEL.IdApp));
            List<AplicacionBE> oAplicacionesLista = new List<AplicacionBE>();
            oAplicacionesLista = oAplicaciones;
            GridView1.DataSource = oAplicacionesLista;
            GridView1.DataBind();
           // GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        public void getAplicacion(string idApp)
        {
            List<AplicacionBE> oAplicaciones = new List<AplicacionBE>();
            SecurityBR oSec = new SecurityBR();
            EncryptionBE oEncrypt = new EncryptionBE();
            oAplicaciones = oSec.getAplicaciones(idApp, string.Empty, long.Parse(ResIEL.IdApp));

            oEncrypt = oSec.encryptDesEncrypt(2, oAplicaciones[0].PASSWORD.ToString(), long.Parse(ResIEL.IdApp));
            // txtPassword.Text = ResDesencriptaPass.Encriptacion.VALOROUT.ToString();
            // txtDescripcion.Text = resSeguridad.Aplicaciones[0].DESCRIPCION.ToString();
            lblIDAplicacion.Text = oAplicaciones[0].IDAPLICACION.ToString();
            txtDescripcion.Text = oAplicaciones[0].DESCRIPCION.ToString();
            txtPassword.Attributes.Add("value", oEncrypt.VALOROUT.ToString());
            //txtPassword.Text = ResDesencriptaPass.Encriptacion.VALOROUT.ToString();
            DetailsView1.DataSource = oAplicaciones;
            DetailsView1.DataBind();

        }

     

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            

            if (e.CommandName.Equals("detail"))
            {
               


                GridViewRow gvrow = GridView1.Rows[index];

                string item = GridView1.DataKeys[index].Value.ToString();
                getAplicacion(item);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#detailModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DetailModalScript", sb.ToString(), false);
            }
            else if (e.CommandName.Equals("editRecord"))
            {
                GridViewRow gvrow = GridView1.Rows[index];

                string item = GridView1.DataKeys[index].Value.ToString();
                getAplicacion(item);

              
                lblResult.Visible = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#editModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

            }
            else if (e.CommandName.Equals("deleteRecord"))
            {
                GridViewRow gvrow = GridView1.Rows[index];

                string item = GridView1.DataKeys[index].Value.ToString();
                getAplicacion(item);


                hfApp.Value = item;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$('#deleteModal').modal('show');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "DeleteModalScript", sb.ToString(), false);
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string item = lblIDAplicacion.Text;
            string Aplicacion = txtDescripcion.Text;
            string password = txtPassword.Text;
            executeUpdate(item, Aplicacion, password);
        }

        private void executeUpdate(string idApp, string Aplicacion, string password)
        {
            AplicacionBE App = new AplicacionBE();
            SecurityBR oSec = new SecurityBR();
            EncryptionBE oEncrypt = new EncryptionBE();
            bool upd;

            oEncrypt = oSec.encryptDesEncrypt( 1,password, long.Parse(ResIEL.IdApp));

            App.DESCRIPCION = Aplicacion;
            App.ACTIVO = true;
            App.IDAPLICACION = long.Parse(idApp);
            App.PASSWORD = oEncrypt.VALOROUT.ToString();
            upd = oSec.updAplicacion(App, long.Parse(ResIEL.IdApp));
            if (upd)
            {
                CargaGrid();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Se actualizo la Aplicacion');");
                sb.Append("$('#editModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditHideModalScript", sb.ToString(), false);
            }
            else
            {
                CargaGrid();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('No fue posible realizar la operacion, intente mas tarde.');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript2", sb.ToString(), false);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#addModal').modal('show');");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddShowModalScript", sb.ToString(), false);

        }

        protected void btnAddRecord_Click(object sender, EventArgs e)
        {

            string Aplicacion = txtAddDescripcion.Text;
            string Password = txtAddPassword.Text;
            executeAdd(Aplicacion, Password);
        }

        private void executeAdd(string Aplicacion, string password)
        {
            AplicacionBE App = new AplicacionBE();
            SecurityBR oSec = new SecurityBR();
            EncryptionBE oEncrypt = new EncryptionBE();
            bool upd;
            oEncrypt = oSec.encryptDesEncrypt( 1,password, long.Parse(ResIEL.IdApp));

            App.DESCRIPCION = Aplicacion;
            App.ACTIVO = true;
            App.PASSWORD = oEncrypt.VALOROUT.ToString();
            upd = oSec.addAplicacion(App, long.Parse(ResIEL.IdApp));
            if (upd)
            {
                CargaGrid();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Se agregó la aplicacion con exito');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript", sb.ToString(), false);
            }
            else
            {
                CargaGrid();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('No fue posible realizar la operacion, intente mas tarde.');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript2", sb.ToString(), false);
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string item = hfApp.Value;
            string Aplicacion = txtDescripcion.Text;
            string password = txtPassword.Text;
            executeDelete(item, Aplicacion, password);



        }

        private void executeDelete(string idApp, string Aplicacion, string password)
        {
            AplicacionBE App = new AplicacionBE();
          
            SecurityBR oSec = new SecurityBR();
            EncryptionBE oEncrypt = new EncryptionBE();
            bool upd;
            oEncrypt = oSec.encryptDesEncrypt(1, password, long.Parse(ResIEL.IdApp));

            App.DESCRIPCION = Aplicacion;
            App.ACTIVO = false;
            App.PASSWORD = oEncrypt.VALOROUT.ToString();
            upd = oSec.updAplicacion(App, long.Parse(ResIEL.IdApp));
            if (upd)
            {
                CargaGrid();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('Se elimino la Aplicacion correctamente');");
                sb.Append("$('#deleteModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "delHideModalScript", sb.ToString(), false);
            }
            else
            {
                CargaGrid();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("alert('No fue posible realizar la operacion, intente mas tarde.');");
                sb.Append("$('#addModal').modal('hide');");
                sb.Append(@"</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AddHideModalScript2", sb.ToString(), false);
            }
        }
       






    }
}