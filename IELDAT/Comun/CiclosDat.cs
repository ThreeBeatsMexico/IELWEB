using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using IELENT;


namespace IELDAT
{
   public class CiclosDat
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
       public List<CicloEnt> ListaCiclosDat()
       {
           List<CicloEnt> oCilosLista = new List<CicloEnt>();
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
           try
           {
               dbCommand = new OleDbCommand();
               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "SELECT CASE ESTATUS WHEN 1 THEN 'ACTIVO' WHEN 0 THEN 'INACTIVO' END AS DESCESTATUS, * FROM CICLO";
               dbCommand.CommandType = CommandType.Text;
               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {
                       CicloEnt item = new CicloEnt();
                       item.psIDCiclo = dbDataReader["id"].ToString();
                       item.psNombreCiclo = dbDataReader["NombreCiclo"].ToString();
                       item.psFechaInicial = dbDataReader["FechaInicio"].ToString();
                       item.psFechaFinal = dbDataReader["FechaFin"].ToString();
                       item.psEstatus = dbDataReader["Estatus"].ToString();
                       item.psEstatusDesc = dbDataReader["DESCESTATUS"].ToString();



                       oCilosLista.Add(item);

                   }
               }


               dbCommand.Dispose();
               dbCommand = null;
               dbConnection.Close();
               dbConnection.Dispose();
               dbConnection = null;

               dbDataReader.Close();
               dbDataReader.Dispose();
               dbDataReader = null;

           }
           catch (Exception oException)
           {


               if (dbCommand != null)
               {
                   dbCommand.Dispose();
                   dbCommand = null;
               }

               if (dbConnection.State == ConnectionState.Open)
               {
                   dbDataReader = null;
                   dbConnection.Close();
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               else
               {
                   dbDataReader = null;
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               throw new Exception("Mensaje: DAT>CiclosDat>ListaCiclosDat");
           }

           return oCilosLista;

       }

       public CicloEnt ObtieneCicloDat(string Ciclo)
       {
           CicloEnt item = new CicloEnt();
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
           try
           {
               dbCommand = new OleDbCommand();
               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "select * from Ciclo where id = '" + Ciclo + "'";
               dbCommand.CommandType = CommandType.Text;
               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();

               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {

                       item.psIDCiclo = dbDataReader["Id"].ToString();
                       item.psNombreCiclo = dbDataReader["NombreCiclo"].ToString();
                       item.psFechaInicial = dbDataReader["FechaInicio"].ToString();
                       item.psFechaFinal = dbDataReader["FechaFin"].ToString();
                       item.psMontoInscripcion = dbDataReader["MontoInscripcion"].ToString();
                       item.psMontoColegiatura = dbDataReader["MontoColegiatura"].ToString();
                       item.psEstatus = dbDataReader["Estatus"].ToString();
                      

                   }
               }


               dbCommand.Dispose();
               dbCommand = null;
               dbConnection.Close();
               dbConnection.Dispose();
               dbConnection = null;

               dbDataReader.Close();
               dbDataReader.Dispose();
               dbDataReader = null;

           }
           catch (Exception oException)
           {


               if (dbCommand != null)
               {
                   dbCommand.Dispose();
                   dbCommand = null;
               }

               if (dbConnection.State == ConnectionState.Open)
               {
                   dbDataReader = null;
                   dbConnection.Close();
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               else
               {
                   dbDataReader = null;
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               throw new Exception("Mensaje: DAT>CiclosDat>ObtieneInformacionCiclo");
           }

           return item;

       }

       public string fnRegistroCicloDat(CicloEnt item)
       {
           string sRespuesta = "";
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;

           try
           {

               dbCommand = new OleDbCommand();
               dbCommand.Parameters.Add("id", OleDbType.VarChar).Value = item.psIDCiclo.ToString();
               dbCommand.Parameters.Add("NombreCiclo", OleDbType.VarChar).Value = item.psNombreCiclo.ToString();
               dbCommand.Parameters.Add("FechaInicial", OleDbType.VarChar).Value = item.psFechaInicial;
               dbCommand.Parameters.Add("FechaFinal", OleDbType.VarChar).Value = item.psFechaFinal;
               dbCommand.Parameters.Add("MontoInscripcion", OleDbType.VarChar).Value = item.psMontoInscripcion.ToString();
               dbCommand.Parameters.Add("MontoColegiatura", OleDbType.VarChar).Value = item.psMontoColegiatura.ToString();
               dbCommand.Parameters.Add("Estatus", OleDbType.VarChar).Value = item.psEstatus.ToString();




               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);

               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "proc_CICLOS";
               dbCommand.CommandType = CommandType.StoredProcedure;

               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               sRespuesta = "1";
               
               dbCommand.Dispose();
               dbCommand = null;
               dbConnection.Close();
               dbConnection.Dispose();
               dbConnection = null;

               dbDataReader.Close();
               dbDataReader.Dispose();
               dbDataReader = null;

           }
           catch (Exception oException)
           {

               sRespuesta = "";
               if (dbCommand != null)
               {
                   dbCommand.Dispose();
                   dbCommand = null;
               }

               if (dbConnection.State == ConnectionState.Open)
               {
                   dbDataReader = null;
                   dbConnection.Close();
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               else
               {
                   dbDataReader = null;
                   dbConnection.Dispose();
                   dbConnection = null;
               }
               throw new Exception("Mensaje: DAT>AlumnoDat>RegistraAlumnosDat");
           }

           return sRespuesta;

       }

    }
}
