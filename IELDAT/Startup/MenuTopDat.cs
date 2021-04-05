using IELENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace IELDAT
{
   public class MenuTopDat
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
        public MenuTopEnt ObtieneMenuPrincipal(string dIDUsuario)
        {
            MenuTopEnt item = new MenuTopEnt();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;

            try
            {

                dbCommand = new OleDbCommand();

                dbCommand.Parameters.Add("USER_LOGIN", OleDbType.VarChar).Value = dIDUsuario.ToString();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);

                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "proc_USERS_PERMISOS_MOSTRAR";
                dbCommand.CommandType = CommandType.StoredProcedure;

                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        

                        item.psAdministrar = Convert.ToBoolean(dbDataReader["ADMINISTRAR"]);
                        item.psAlumnos = Convert.ToBoolean(dbDataReader["ALUMNOS"]);
                       
                        item.psCobranza = Convert.ToBoolean(dbDataReader["COBRANZA"]);
                   
                        item.psPago = Convert.ToBoolean(dbDataReader["PAGO"]);
                        
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
