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
    public class GrupoDat
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
        public List<GrupoEnt> ListaGruposDat()
        {
            List<GrupoEnt> oGruposLista = new List<GrupoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "SELECT G.idGRUPO,G.NOMBREGRUPO, GR.IDGrado, CASE G.IDNIVEL WHEN 0 THEN 'KINDER' WHEN 1 THEN 'PRIMARIA' WHEN 2 THEN 'MATERNAL' END AS NIVEL, " +
                    " GR.DESCRIPCIONGRADO, C.NOMBRECICLO, C.id FROM GRUPO G, GRADO GR , CICLO C WHERE G.IDNIVEL = GR.IDNivel AND G.IDGrado = GR.IDGrado AND C.id = G.IDCiclo";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        GrupoEnt item = new GrupoEnt();
                        item.psIDGrupo = dbDataReader["idGrupo"].ToString();
                        item.psNombreCiclo = dbDataReader["NOMBRECICLO"].ToString();
                        item.psNombreGrupo = dbDataReader["NOMBREGRUPO"].ToString();
                        item.psNivelAcademico = dbDataReader["NIVEL"].ToString();
                        item.psGrado = dbDataReader["DESCRIPCIONGRADO"].ToString();
                        item.psIDGrado = dbDataReader["IDGrado"].ToString();
                        item.psIDCiclo = dbDataReader["id"].ToString();
                        



                        oGruposLista.Add(item);

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
                throw new Exception("Mensaje: DAT>GruposDat>ListaGruposDat");
            }

            return oGruposLista;

        }

        public GrupoEnt ObtieneGruposDat(string Grupo)
        {
            GrupoEnt item = new GrupoEnt();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "select * from Grupo where idGrupo = '" + Grupo + "'";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        item.psIDNivelAcademico = dbDataReader["IDNivel"].ToString();
                        item.psIDGrado = dbDataReader["IDGrado"].ToString();
                        item.psIDCiclo = dbDataReader["IDCiclo"].ToString();
                        item.psIDGrupo = dbDataReader["NombreGrupo"].ToString();
                     


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
                throw new Exception("Mensaje: DAT>GruposDat>ObtieneInformacionGrupo");
            }

            return item;

        }

        public string fnRegistroGrupoDat(GrupoEnt item)
        {
            string sRespuesta = "";
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;

            try
            {

                dbCommand = new OleDbCommand();
                dbCommand.Parameters.Add("ID", OleDbType.VarChar).Value = item.psIDGrupo.ToString();
                dbCommand.Parameters.Add("IDNIVEL", OleDbType.VarChar).Value = item.psIDNivelAcademico.ToString();
                dbCommand.Parameters.Add("IDGRADO", OleDbType.VarChar).Value = item.psIDGrado.ToString();
                dbCommand.Parameters.Add("IDCICLO", OleDbType.VarChar).Value = item.psIDCiclo.ToString();
                dbCommand.Parameters.Add("NOMBREGRUPO", OleDbType.VarChar).Value = item.psNombreGrupo.ToString();





                dbConnection = new OleDbConnection(constring);
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);

                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "proc_Grupos";
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
                throw new Exception("Mensaje: DAT>GrupoDat>RegistraGrupoDat");
            }

            return sRespuesta;

        }

        public string ValidaGrupo(GrupoEnt item)
        {
            string sRespuesta = "";
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;

            try
            {

                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);

                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "SELECT * FROM GRUPO WHERE IDNIVEL="+item.psIDNivelAcademico.ToString() +
                                        " AND IDGRADO=" + item.psIDGrado.ToString() +  
                                        " AND IDCICLO=" + item.psIDCiclo.ToString() +
                                        " AND NOMBREGRUPO='"+ item.psNombreGrupo.ToString() + "'";
                dbCommand.CommandType = CommandType.Text;

                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    sRespuesta = "1";
                }
                else { sRespuesta = "0"; }
                
               // dbCommand.Dispose();
               // dbCommand = null;
                dbConnection.Close();
                dbConnection.Dispose();
                dbConnection = null;

               // dbDataReader.Close();
                //dbDataReader.Dispose();
               // dbDataReader = null;

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
                throw new Exception("Mensaje: DAT>GrupoDat>RegistraGrupoDat");
            }

            return sRespuesta;

        }


        public string EliminaGrupo(string idGrupo)
        {
            string sRespuesta = "";
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;

            try
            {

                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);

                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "DELETE GRUPO WHERE IDGRUPO='" + idGrupo + "'";
                                       
                dbCommand.CommandType = CommandType.Text;

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
                throw new Exception("Mensaje: DAT>GrupoDat>RegistraGrupoDat");
            }

            return sRespuesta;

        }
    }
}
