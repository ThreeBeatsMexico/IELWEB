using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELENT;
using System.Data.OleDb;
using System.Data;

namespace IELDAT
{
   public class CodigoPostalDAT
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
        public List<ColoniaBE> ObtenerInformacionPorCP(string CodigoPostal)
        {
            List<ColoniaBE> oListaColonias = new List<ColoniaBE>();
            OleDbConnection myConn = null;
            OleDbCommand myComm = null;
            OleDbDataReader rsConsulta = null;

            try
            {
                //[10-06-14][DGRV][Se comento para que pudieramos realizar un union a la tabla alterna]
                //sSQL.Append(" SELECT ");
                //sSQL.Append(" * ");
                //sSQL.Append(" FROM ");
                //sSQL.Append(" COLONIAS");
                //sSQL.Append(" WHERE");
                //sSQL.Append(" CODIGOPOSTAL = '" + CodigoPostal + "'");
                //myComm = new OleDbCommand(myConn);
                ////using (myConn = new OleDbConnection(ConfigurationManager.ConnectionStrings["connStringCodigoPostal"].ConnectionString))
                using (myConn = new OleDbConnection(constring))
                {
                    using (myComm = new OleDbCommand("sp_getInfoXCP", myConn))
                    {
                        myComm.CommandType = CommandType.StoredProcedure;
                        myComm.Parameters.AddWithValue("CodigoPostal", CodigoPostal.Trim());
                        myConn.Open();
                        rsConsulta = myComm.ExecuteReader();

                        while (rsConsulta.Read())
                        {
                            ColoniaBE item = new ColoniaBE();

                            item.ClaveCiudad = rsConsulta["ClaveCiudad"].ToString();
                            item.NombreMunicpio = rsConsulta["Municipio"].ToString();
                            item.NombreEstado = rsConsulta["NombreEstado"].ToString();
                            item.ClaveMunicipio = rsConsulta["ClaveMunicipio"].ToString();
                            item.ClaveEntidad = rsConsulta["ClaveEntidad"].ToString();
                            item.CodigoPostal = rsConsulta["CodigoPostal"].ToString();
                            item.NombreColonia = rsConsulta["NombreColonia"].ToString();
                            item.ClaveColonia = rsConsulta["ClaveColonia"].ToString();
                            item.CodigoPostalAdmon = rsConsulta["CodigoPostalAdministracion"].ToString();
                            item.ClaveTipoAsenta = rsConsulta["ClaveTipoAsentamiento"].ToString();
                            item.TipoAsenta = rsConsulta["TipoAsentamiento"].ToString();
                            item.ClaveCiudad = rsConsulta["ClaveCiudad"].ToString();
                            item.NombreCiudad = rsConsulta["Municipio"].ToString();
                            item.Zona = rsConsulta["Zona"].ToString();
                            
                            item.ORIGINAL = bool.Parse(rsConsulta["ORIGINAL"].ToString());
                          

                            oListaColonias.Add(item);
                        }
                    }
                }

                myConn.Close();
                myConn.Dispose();
                myConn = null;
                myComm.Dispose();
                myComm = null;
                rsConsulta.Close();
                rsConsulta.Dispose();
                rsConsulta = null;

            }
            catch (Exception oException)
            {
                oListaColonias.Clear();

                if (myComm != null)
                {
                    myComm.Dispose();
                    myComm = null;
                }

                if (myConn.State == ConnectionState.Open)
                {
                    rsConsulta = null;
                    myConn.Close();
                    myConn.Dispose();
                    myConn = null;
                }
                else
                {
                    rsConsulta = null;
                    myConn.Dispose();
                    myConn = null;
                }
                throw new Exception("Mensaje: DAT>CodigoPostalDat>ObtenerInformacionPorCP");
            }

            return oListaColonias;
        }
    }
}
