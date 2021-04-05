using CrystalDecisions.Shared;
using IELBUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IELWEB.Reportes
{
    public partial class ReporteDeudores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RadAsyncUpload1.FileUploaded += new Telerik.Web.UI.FileUploadedEventHandler(RadAsyncUpload1_FileUploaded);
            //RadButton1.Click += new EventHandler(RadButton1_Click);
            try
            {
                if (!Context.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage("../Startup/login.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {

                        AbrirReporte();
                        

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AbrirReporte()
        {
            AlumnosBus alumnosBus;
            DeudoresRpt deudoresRpt;
            DataSet dataSet;
            alumnosBus = new AlumnosBus();
            deudoresRpt = new DeudoresRpt();
            dataSet = new DataSet();
            try
            {
                dataSet = alumnosBus.ObtieneDeudoresRpt();
                deudoresRpt.SetDataSource(dataSet);
                deudoresRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, base.Response, false, "Reporte");
            }
            catch
            {
            }
        }
    }
}