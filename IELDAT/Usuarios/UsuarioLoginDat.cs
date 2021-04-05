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

   public class UsuarioLoginDat
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
       public string ObtieneUsuarioLogin(UsuarioEnt User)
       {
           string sRespuesta = string.Empty;
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
          
           try
           {

               dbCommand = new OleDbCommand();

               dbCommand.Parameters.Add("USER_LOGIN", OleDbType.VarChar).Value = User.psIDUsuario;
               dbCommand.Parameters.Add("USER_PASSWORD", OleDbType.VarChar).Value = User.psPassword;
              

               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);

               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "proc_USER_LOGIN";
               dbCommand.CommandType = CommandType.StoredProcedure;

               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();

               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {
                       sRespuesta = dbDataReader["nombre"].ToString();

                   }
               }
               else
               {
                   sRespuesta = "0";
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

               sRespuesta = "0";
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

           return sRespuesta;

       }

        public bool fnRegistroDat(UsuarioEnt User)
       {
           bool sRespuesta;
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
          
           try
           {

               dbCommand = new OleDbCommand();

               dbCommand.Parameters.Add("USER_LOGIN", OleDbType.VarChar).Value = User.psIDUsuario;
               dbCommand.Parameters.Add("USER_PASSWORD", OleDbType.VarChar).Value = User.psPassword;
               dbCommand.Parameters.Add("NOMBRE", OleDbType.VarChar).Value = User.psNombreUsuario;
               dbCommand.Parameters.Add("ACTIVO", OleDbType.VarChar).Value = User.psActivo;
               dbCommand.Parameters.Add("ADMINISTRACION", OleDbType.VarChar).Value = User.psAdministracion;
               dbCommand.Parameters.Add("ALUMNOS", OleDbType.VarChar).Value = User.psAlumnos;
              // dbCommand.Parameters.Add("PROFESORES", OleDbType.VarChar).Value = User.psProfesores;
               dbCommand.Parameters.Add("COBRANZA", OleDbType.VarChar).Value = User.psCobranza;
               //dbCommand.Parameters.Add("BLOG", OleDbType.VarChar).Value = User.psBlog;
               //dbCommand.Parameters.Add("AYUDA", OleDbType.VarChar).Value = User.psAyuda;
               //dbCommand.Parameters.Add("IMAGEN", OleDbType.VarChar).Value = User.psImagen;
               dbCommand.Parameters.Add("PAGO", OleDbType.VarChar).Value = User.psPago;


              

              // dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);

               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "proc_USERS";
               dbCommand.CommandType = CommandType.StoredProcedure;

               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();

              sRespuesta = true;

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

               sRespuesta = false;
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
               throw new Exception("Mensaje: DAT>UsuarioLoginDat>fnRegistraDat");
           }

           return sRespuesta;

       }

       
       public List<UsuarioEnt> ListaUsuariosDat()
       {
           List<UsuarioEnt> oUsuariosLista = new List<UsuarioEnt>();
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
           try
           {
               dbCommand = new OleDbCommand();
               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "SELECT user_login, nombre FROM users";
               dbCommand.CommandType = CommandType.Text;
               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {
                       UsuarioEnt item = new UsuarioEnt();
                       item.psIDUsuario = dbDataReader["user_login"].ToString();
                       item.psNombreUsuario = dbDataReader["nombre"].ToString();
                       oUsuariosLista.Add(item);

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

           return oUsuariosLista;

       }

       public UsuarioEnt ObtieneUsuarioDat(string Usuario)
       {
           UsuarioEnt item = new UsuarioEnt();
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;
           try
           {
               dbCommand = new OleDbCommand();
               //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "SELECT * FROM users where user_login = '" + Usuario +"'";
               dbCommand.CommandType = CommandType.Text;
               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               
               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {

                       item.psIDUsuario = dbDataReader["USER_LOGIN"].ToString();
                       item.psPassword = dbDataReader["USER_PASSWORD"].ToString();
                       item.psNombreUsuario = dbDataReader["NOMBRE"].ToString();
                       item.psActivo = dbDataReader["ACTIVO"].ToString();
                       item.psAdministracion = dbDataReader["ADMINISTRAR"].ToString();
                       item.psAlumnos = dbDataReader["ALUMNOS"].ToString();
                       item.psProfesores = dbDataReader["PROFESORES"].ToString();
                       item.psCobranza = dbDataReader["COBRANZA"].ToString();
                       item.psBlog = dbDataReader["BLOG"].ToString();
                       item.psAyuda = dbDataReader["AYUDA"].ToString();
                       item.psImagen = dbDataReader["IMAGEN"].ToString();
                       item.psPago = dbDataReader["PAGO"].ToString();
                       

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

           return item;

       }
      
    }
}
