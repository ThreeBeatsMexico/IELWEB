using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELENT;
using System.Data.OleDb;
using System.Data;
using IELENT.Reportes;

namespace IELDAT
{
   public class PagosDat
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;

      public List<PagosEnt> ListaPagosAlumno(string idAlumo)
       {
           List<PagosEnt> oPagosLista = new List<PagosEnt>();
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
           try
           {
               dbCommand = new OleDbCommand();
               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               dbCommand.Connection = dbConnection;
               dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar).Value = idAlumo.ToString();
              
               dbCommand.CommandText = "proc_LISTA_PAGOS_ALUMNO";
               dbCommand.CommandType = CommandType.StoredProcedure;
               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {
                       PagosEnt item = new PagosEnt();
                       item.psIDPago = dbDataReader["ID"].ToString();
                       item.psConcepto = dbDataReader["CONCEPTO"].ToString();
                       item.psMontoActual = dbDataReader["MONTOACTUAL"].ToString();
                       item.psEstado = dbDataReader["ESTATUS"].ToString();
                       item.psIDAlumno = dbDataReader["IDALUMNO"].ToString();
                       item.psFechaMovimiento = dbDataReader["FECHAMOVIMIENTO"].ToString();
                       oPagosLista.Add(item);

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
               throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
           }

           return oPagosLista;
       
       }

      public PagosEnt ObtienePago(string idPago)
      {
          PagosEnt oPagosEnt = new PagosEnt();
          OleDbConnection dbConnection = null;
          OleDbCommand dbCommand = null;
          OleDbDataReader dbDataReader = null;
          try
          {
              dbCommand = new OleDbCommand();
              //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
              dbConnection = new OleDbConnection(constring);
              dbCommand.Connection = dbConnection;
              dbCommand.Parameters.Add("IDPAGO", OleDbType.VarChar).Value = idPago.ToString();

              dbCommand.CommandText = "proc_OBTIENE_PAGO";
              dbCommand.CommandType = CommandType.StoredProcedure;
              dbConnection.Open();
              dbDataReader = dbCommand.ExecuteReader();
              if (dbDataReader.HasRows)
              {
                  while (dbDataReader.Read())
                  {

                      oPagosEnt.psIDPago = dbDataReader["ID"].ToString();
                      oPagosEnt.psConcepto = dbDataReader["CONCEPTO"].ToString();
                      oPagosEnt.psMontoActual = dbDataReader["MONTOACTUAL"].ToString();
                      oPagosEnt.psEstado = dbDataReader["ESTATUS"].ToString();
                      oPagosEnt.psIDAlumno = dbDataReader["IDALUMNO"].ToString();
                      oPagosEnt.psFechaMovimiento = dbDataReader["FECHAMOVIMIENTO"].ToString();
                      

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
              throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
          }

          return oPagosEnt;

      }

      public string RegistraPago(PagosEnt itemPago)
      {
          string respuesta = string.Empty;
          OleDbConnection dbConnection = null;
          OleDbCommand dbCommand = null;
          OleDbDataReader dbDataReader = null;
          try
          {


              dbCommand = new OleDbCommand();
              //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
              dbConnection = new OleDbConnection(constring);
              dbCommand.Connection = dbConnection;
              dbCommand.Parameters.Add("IDPAGO", OleDbType.VarChar).Value = itemPago.psIDPago.ToString();
              dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar).Value = itemPago.psIDAlumno.ToString();
              dbCommand.Parameters.Add("MONTO", OleDbType.VarChar).Value = itemPago.psMontoActual.ToString();
              dbCommand.Parameters.Add("REFERENCIA", OleDbType.VarChar).Value = itemPago.psReferencia.ToString();
              dbCommand.Parameters.Add("MEDIOPAGO", OleDbType.VarChar).Value = itemPago.psMedioPago.ToString();
               dbCommand.Parameters.Add("ESTATUS", OleDbType.VarChar).Value = itemPago.psIDEstaus.ToString();

              dbCommand.CommandText = "proc_REGISTRA_PAGO";
              dbCommand.CommandType = CommandType.StoredProcedure;
              dbConnection.Open();
              dbDataReader = dbCommand.ExecuteReader();
              respuesta = "1";


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

              respuesta = "0";
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
              throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
          }

          return respuesta;

      }


      public List<PagosEnt> ListaPagosAlumnoMatricula(string sMatricula)
      {
          List<PagosEnt> oPagosLista = new List<PagosEnt>();
          OleDbConnection dbConnection = null;
          OleDbCommand dbCommand = null;
          OleDbDataReader dbDataReader = null;
          try
          {
              dbCommand = new OleDbCommand();
              //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
              dbConnection = new OleDbConnection(constring);
              dbCommand.Connection = dbConnection;
              dbCommand.Parameters.Add("MATRICULA", OleDbType.VarChar).Value = sMatricula.ToString();

              dbCommand.CommandText = "proc_LISTA_PAGOS_ALUMNO_MATRICULA";
              dbCommand.CommandType = CommandType.StoredProcedure;
              dbConnection.Open();
              dbDataReader = dbCommand.ExecuteReader();
              if (dbDataReader.HasRows)
              {
                  while (dbDataReader.Read())
                  {
                      PagosEnt item = new PagosEnt();
                      item.psIDPago = dbDataReader["ID"].ToString();
                      item.psConcepto = dbDataReader["CONCEPTO"].ToString();
                      item.psMontoActual = dbDataReader["MONTOACTUAL"].ToString();
                      item.psEstado = dbDataReader["ESTATUS"].ToString();
                      item.psIDAlumno = dbDataReader["IDALUMNO"].ToString();
                      item.psFechaMovimiento = dbDataReader["FECHAMOVIMIENTO"].ToString();
                      oPagosLista.Add(item);

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
              throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
          }

          return oPagosLista;

      }

      public List<TransaccionEnt> ListraTransaccionesPago(string idPago, string idAlumno)
      {
          List<TransaccionEnt> oTransaccionesPago = new List<TransaccionEnt>();
          OleDbConnection dbConnection = null;
          OleDbCommand dbCommand = null;
          OleDbDataReader dbDataReader = null;
          try
          {
              dbCommand = new OleDbCommand();
              //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
              dbConnection = new OleDbConnection(constring);
              dbCommand.Connection = dbConnection;
              dbCommand.Parameters.Add("IDPAGO", OleDbType.VarChar).Value = idPago.ToString();
              dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar).Value = idAlumno.ToString();

              dbCommand.CommandText = "proc_LISTA_PAGOS_TRANSACCIONES";
              dbCommand.CommandType = CommandType.StoredProcedure;
              dbConnection.Open();
              dbDataReader = dbCommand.ExecuteReader();
              if (dbDataReader.HasRows)
              {
                  while (dbDataReader.Read())
                  {
                      TransaccionEnt item = new TransaccionEnt();
                      item.psIDPago = dbDataReader["IDPAGO"].ToString();
                      item.psConcepto = dbDataReader["CONCEPTO"].ToString();
                      item.psMonto = dbDataReader["MONTO"].ToString();
                      item.psFormaPago = dbDataReader["DESCFORMAPAGO"].ToString();
                      item.psReferencia = dbDataReader["REFERENCIA"].ToString();
                      item.psFechaTransaccion = dbDataReader["FECHATRANSACCION"].ToString().Substring(1,10);
                      oTransaccionesPago.Add(item);

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
              throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
          }

          return oTransaccionesPago;

      }

      public TransaccionesDs ObtieneReportePagosDat(string FechaInicial, string FechaFinal)
      {
         
          OleDbConnection dbConnection = null;
          OleDbCommand dbCommand = null;
          OleDbDataReader dbDataReader = null;
          TransaccionesDs dsTransacciones = new TransaccionesDs();
          try
          {
              dbCommand = new OleDbCommand();
              //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
              dbConnection = new OleDbConnection(constring);
              dbCommand.Connection = dbConnection;
              dbCommand.Parameters.Add("FECHA_INI", OleDbType.VarChar).Value = FechaInicial.ToString();
              dbCommand.Parameters.Add("FECHA_FIN", OleDbType.VarChar).Value = FechaFinal.ToString();

              dbCommand.CommandText = "proc_RPT_PAGOS";
              dbCommand.CommandType = CommandType.StoredProcedure;

              OleDbDataAdapter sqlDateAdapter = new OleDbDataAdapter(dbCommand);
              sqlDateAdapter.Fill(dsTransacciones, "dtPagos");


              dbCommand.Dispose();
              dbCommand = null;
              dbConnection.Close();
              dbConnection.Dispose();
              dbConnection = null;

              

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
                 
                  dbConnection.Close();
                  dbConnection.Dispose();
                  dbConnection = null;
              }
              else
              {
                 
                  dbConnection.Dispose();
                  dbConnection = null;
              }
              throw new Exception("Mensaje: DAT>MenuTopDat>ObtieneMenuPrincipal");
          }

          return dsTransacciones;

      }


    }
}
