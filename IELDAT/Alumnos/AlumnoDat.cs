using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using IELENT;
using IELENT.Reportes;
using System.Configuration;

namespace IELDAT
{
   public class AlumnoDat
    {
       string constring = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;
       public string fnRegistroAlumnoDat(AlumnoEnt item)
       {
           string sRespuesta = "";
           OleDbConnection dbConnection = null;
           OleDbCommand dbCommand = null;
           OleDbDataReader dbDataReader = null;

           try
           {

               dbCommand = new OleDbCommand();
               dbCommand.Parameters.Add("NumeroMatricula", OleDbType.VarChar).Value = item.sNumeroMatricula;
               dbCommand.Parameters.Add("APaterno", OleDbType.VarChar).Value = item.sAPaterno;
               dbCommand.Parameters.Add("AMaterno", OleDbType.VarChar).Value = item.sAMaterno;
               dbCommand.Parameters.Add("Nombres", OleDbType.VarChar).Value = item.sNombres;
               dbCommand.Parameters.Add("FechaNacimiento", OleDbType.VarChar).Value = item.sFechaNacimiento;
               dbCommand.Parameters.Add("Sexo", OleDbType.VarChar).Value = item.sSexo;
               dbCommand.Parameters.Add("Nacionalidad", OleDbType.VarChar).Value = item.sNacionalidad;
               dbCommand.Parameters.Add("Grado", OleDbType.VarChar).Value = item.sGrado;
               dbCommand.Parameters.Add("EscuelaProcedencia", OleDbType.VarChar).Value = item.sEscuelaProcedencia;
               dbCommand.Parameters.Add("Hermanos", OleDbType.VarChar).Value = item.sHermanos;
               dbCommand.Parameters.Add("GradoHermanos", OleDbType.VarChar).Value = item.sGradoHermanos;
               dbCommand.Parameters.Add("Calle", OleDbType.VarChar).Value = item.sCalle;
               dbCommand.Parameters.Add("Numero", OleDbType.VarChar).Value = item.sNumero;
               dbCommand.Parameters.Add("Colonia", OleDbType.VarChar).Value = item.sColonia;
               dbCommand.Parameters.Add("Delegacion", OleDbType.VarChar).Value = item.sDelegacion;
               dbCommand.Parameters.Add("Estado", OleDbType.VarChar).Value = item.sEstado;
               dbCommand.Parameters.Add("CodigoPostal", OleDbType.VarChar).Value = item.sCodigoPostal;
               dbCommand.Parameters.Add("Telefono", OleDbType.VarChar).Value = item.sTelefono;
               dbCommand.Parameters.Add("Email", OleDbType.VarChar).Value = item.sEmail;
               dbCommand.Parameters.Add("Curp", OleDbType.VarChar).Value = item.sCurp;
               dbCommand.Parameters.Add("EdadAnos", OleDbType.VarChar).Value = item.sEdadAnos;
               dbCommand.Parameters.Add("EdadMeses", OleDbType.VarChar).Value = item.sEdadMeses;
               dbCommand.Parameters.Add("Foto", OleDbType.VarChar).Value = item.sFoto;
               dbCommand.Parameters.Add("NivelAcademico", OleDbType.VarChar).Value = item.sNivelAcademico;
               dbCommand.Parameters.Add("NombrePadreTutor", OleDbType.VarChar).Value = item.sNombrePadreTutor;
               dbCommand.Parameters.Add("OcupacionPadre", OleDbType.VarChar).Value = item.sOcupacionPadre;
               dbCommand.Parameters.Add("TelefonoPadre", OleDbType.VarChar).Value = item.sTelefonoPadre;
               dbCommand.Parameters.Add("TelefonoTrabajoPadre", OleDbType.VarChar).Value = item.sTelefonoTrabajoPadre;
               dbCommand.Parameters.Add("CelularPadre", OleDbType.VarChar).Value = item.sCelularPadre;
               dbCommand.Parameters.Add("FechaNacimientoPadre", OleDbType.VarChar).Value = item.sFechaNacimientoPadre;
               dbCommand.Parameters.Add("SueldoPadre", OleDbType.VarChar).Value = item.sSueldoPadre;
               dbCommand.Parameters.Add("NacionalidadPadre", OleDbType.VarChar).Value = item.sNacionalidadPadre;
               dbCommand.Parameters.Add("NombreMadreTutor", OleDbType.VarChar).Value = item.sNombreMadreTutor;
               dbCommand.Parameters.Add("OcupacionMadre", OleDbType.VarChar).Value = item.sOcupacionMadre;
               dbCommand.Parameters.Add("TelefonoMadre", OleDbType.VarChar).Value = item.sTelefonoMadre;
               dbCommand.Parameters.Add("TelefonoTrabajoMadre", OleDbType.VarChar).Value = item.sTelefonoTrabajoMadre;
               dbCommand.Parameters.Add("CelularMadre", OleDbType.VarChar).Value = item.sCelularMadre;
               dbCommand.Parameters.Add("FechaNacimientoMadre", OleDbType.VarChar).Value = item.sFechaNacimientoMadre;
               dbCommand.Parameters.Add("SueldoMadre", OleDbType.VarChar).Value = item.sSueldoMadre;
               dbCommand.Parameters.Add("NacionalidadMadre", OleDbType.VarChar).Value = item.sNacionalidadMadre;
               dbCommand.Parameters.Add("NombreFamVecino", OleDbType.VarChar).Value = item.sNombreFamVecino;
               dbCommand.Parameters.Add("TelefonoVecino", OleDbType.VarChar).Value = item.sTelefonoVecino;
               dbCommand.Parameters.Add("TelefonoTrabajoVecino", OleDbType.VarChar).Value = item.sTelefonoTrabajoVecino;
               dbCommand.Parameters.Add("CelularVecino", OleDbType.VarChar).Value = item.sCelularVecino;
               dbCommand.Parameters.Add("EducacionFisica", OleDbType.VarChar).Value = item.sEducacionFisica;
               dbCommand.Parameters.Add("Medicamento", OleDbType.VarChar).Value = item.sMedicamento;
               dbCommand.Parameters.Add("NombreMedicamento", OleDbType.VarChar).Value = item.sNombreMedicamento;
               dbCommand.Parameters.Add("DosisMedicamento", OleDbType.VarChar).Value = item.sDosisMedicamento;
               dbCommand.Parameters.Add("Peso", OleDbType.VarChar).Value = item.sPeso;
               dbCommand.Parameters.Add("Talla", OleDbType.VarChar).Value = item.sTalla;
               dbCommand.Parameters.Add("TipoSangre", OleDbType.VarChar).Value = item.sTipoSangre;
               dbCommand.Parameters.Add("Enfermedades", OleDbType.VarChar).Value = item.sEnfermedades;
               dbCommand.Parameters.Add("NombreEnfermedades", OleDbType.VarChar).Value = item.sNombreEnfermedades;
               dbCommand.Parameters.Add("ProcedimientoCrisis", OleDbType.VarChar).Value = item.sProcedimientoCrisis;
               dbCommand.Parameters.Add("Certificado", OleDbType.VarChar).Value = item.sCertificado;
               dbCommand.Parameters.Add("EnfermedadCertificado", OleDbType.VarChar).Value = item.sEnfermedadCertificado;
               dbCommand.Parameters.Add("Alergia", OleDbType.VarChar).Value = item.sAlergia;
               dbCommand.Parameters.Add("NombreAlergia", OleDbType.VarChar).Value = item.sNombreAlergia;
               dbCommand.Parameters.Add("ProcedimintoCrisisAlergia", OleDbType.VarChar).Value = item.sProcedimintoCrisisAlergia;
               dbCommand.Parameters.Add("NombreAccidente", OleDbType.VarChar).Value = item.sNombreAccidente;
               dbCommand.Parameters.Add("TelefonoAccidente", OleDbType.VarChar).Value = item.sTelefonoAccidente;
               dbCommand.Parameters.Add("NombreHospital", OleDbType.VarChar).Value = item.sNombreHospital;
               dbCommand.Parameters.Add("Medico", OleDbType.VarChar).Value = item.sMedico;
               dbCommand.Parameters.Add("NombreMedico", OleDbType.VarChar).Value = item.sNombreMedico;
               dbCommand.Parameters.Add("TelefonoMedico", OleDbType.VarChar).Value = item.sTelefonoMedico;
               dbCommand.Parameters.Add("CedulaMedico", OleDbType.VarChar).Value = item.sCedulaMedico;
               dbCommand.Parameters.Add("AutorizaTraslado", OleDbType.VarChar).Value = item.sAutorizaTraslado;
               dbCommand.Parameters.Add("ProcedimientoAccidente", OleDbType.VarChar).Value = item.sProcedimientoAccidente;
               dbCommand.Parameters.Add("NombreUsuario", OleDbType.VarChar).Value = item.sUsuario;
               dbCommand.Parameters.Add("Tutor", OleDbType.VarChar).Value = item.sTutor;
               dbCommand.Parameters.Add("Estatus", OleDbType.VarChar).Value = item.sEstatus;
               dbCommand.Parameters.Add("ServerPath", OleDbType.VarChar).Value = item.sServerPath;
               dbCommand.Parameters.Add("Beca", OleDbType.VarChar).Value = item.sBeca;
               dbCommand.Parameters.Add("FormaPago", OleDbType.VarChar).Value = item.sFormaPago;
               
             
             //  dbConnection = new OleDbConnection(ConexionString.connStringIEL);
               dbConnection = new OleDbConnection(constring);
               

               dbCommand.Connection = dbConnection;
               dbCommand.CommandText = "proc_ALUMNOS";
               dbCommand.CommandType = CommandType.StoredProcedure;

               dbConnection.Open();
               dbDataReader = dbCommand.ExecuteReader();
               if (dbDataReader.HasRows)
               {
                   while (dbDataReader.Read())
                   {

                       sRespuesta = dbDataReader["MATRICULA"].ToString();
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


        public List<AlumnoEnt> ListaAlumnosDat(AlumnoEnt oAlumnoEnt)
        {
            List<AlumnoEnt> oAlumnosLista = new List<AlumnoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
               // dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.Parameters.Add("MATRICULA", OleDbType.VarChar).Value = oAlumnoEnt.sNumeroMatricula;
                dbCommand.Parameters.Add("NOMBRES", OleDbType.VarChar).Value = oAlumnoEnt.sNombres;
                dbCommand.Parameters.Add("APATERNO", OleDbType.VarChar).Value = oAlumnoEnt.sAPaterno;
                dbCommand.Parameters.Add("AMATERNO", OleDbType.VarChar).Value = oAlumnoEnt.sAMaterno;
                dbCommand.Parameters.Add("FECHANACIMIENTO", OleDbType.VarChar).Value = oAlumnoEnt.sFechaNacimiento;
                dbCommand.Parameters.Add("ESTATUS", OleDbType.VarChar).Value = oAlumnoEnt.sEstatus;
                dbCommand.CommandText = "proc_LISTA_ALUMNOS";
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        AlumnoEnt item = new AlumnoEnt();
                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sNombres = dbDataReader["Nombres"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        item.sFechaNacimiento = dbDataReader["FechaNacimiento"].ToString();
                        item.sEstado = dbDataReader["DESCESTATUS"].ToString();
                        oAlumnosLista.Add(item);     

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

            return oAlumnosLista;

        }

        public List<AlumnoEnt> ListaAlumnosGrupoDat(string idGrupo,string idGrado, string idCiclo)
        {
            List<AlumnoEnt> oAlumnosLista = new List<AlumnoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
               // dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.Parameters.Add("IDGRADO", OleDbType.VarChar).Value = idGrado;
                dbCommand.Parameters.Add("IDGRUPO", OleDbType.VarChar).Value = idGrupo;
                dbCommand.Parameters.Add("IDCICLO", OleDbType.VarChar).Value = idCiclo;
                dbCommand.CommandText = "proc_LISTA_ALUMNOS_GRUPO";
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        AlumnoEnt item = new AlumnoEnt();
                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sNombres = dbDataReader["Nombres"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        item.sGrado = dbDataReader["Grado"].ToString();
                        item.sGrupo = dbDataReader["Grupo"].ToString();
                        item.sCiclo = dbDataReader["idCiclo"].ToString();
                        oAlumnosLista.Add(item);

                    }
                }
      
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
                throw new Exception("Mensaje: DAT>AlumnoDat>ListarAlumnosGrupo");
            }

            return oAlumnosLista;

        }

        public List<AlumnoEnt> ListaAlumnosGrupoAddDat(string idGrado, string idCiclo)
        {
            List<AlumnoEnt> oAlumnosLista = new List<AlumnoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.Parameters.Add("IDGRADO", OleDbType.VarChar).Value = idGrado;
              //  dbCommand.Parameters.Add("IDCICLO", OleDbType.VarChar).Value = idCiclo;
                dbCommand.CommandText = "proc_LISTA_ALUMNOS_GRUPO_ADD";
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        AlumnoEnt item = new AlumnoEnt();
                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sNombres = dbDataReader["NumeroMatricula"].ToString() + " - " + dbDataReader["Nombres"].ToString() + " " + dbDataReader["APaterno"].ToString() + " " + dbDataReader["AMaterno"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        oAlumnosLista.Add(item);

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
                throw new Exception("Mensaje: DAT>AlumnoDat>ListarAlumnosGrupo");
            }

            return oAlumnosLista;

        }

        public AlumnoEnt ObtieneAlumnoDat(string Alumno)
        {
            AlumnoEnt item = new AlumnoEnt();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "select a.*,b.* from Alumnos a, InfoAlumnos b where a.NumeroMatricula = b.NumeroMatricula and a.NumeroMatricula = '" + Alumno + "'";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {

                       item.sIdAlumno =  dbDataReader["IdAlumno"].ToString();
                       item.sNumeroMatricula =  dbDataReader["NumeroMatricula"].ToString();
                       item.sAPaterno = dbDataReader["APaterno"].ToString();
                       item.sAMaterno = dbDataReader["AMaterno"].ToString();
                       item.sNombres = dbDataReader["Nombres"].ToString();
                       item.sFechaNacimiento = dbDataReader["FechaNacimiento"].ToString();
                       item.sSexo = dbDataReader["Sexo"].ToString();
                       item.sNacionalidad = dbDataReader["Nacionalidad"].ToString();
                       item.sGrado = dbDataReader["Grado"].ToString();
                       item.sGrupo = dbDataReader["Grupo"].ToString();
                       item.sNumeroLista = dbDataReader["NumeroLista"].ToString();
                       item.sEscuelaProcedencia = dbDataReader["EscuelaProcedencia"].ToString();
                       item.sHermanos = dbDataReader["Hermanos"].ToString();
                       item.sGradoHermanos = dbDataReader["GradoHermanos"].ToString();
                       item.sCalle = dbDataReader["Calle"].ToString();
                       item.sNumero = dbDataReader["Numero"].ToString();
                       item.sColonia = dbDataReader["Colonia"].ToString();
                       item.sDelegacion = dbDataReader["Delegacion"].ToString();
                       item.sEstado = dbDataReader["Estado"].ToString();
                       item.sCodigoPostal = dbDataReader["CodigoPostal"].ToString();
                       item.sTelefono = dbDataReader["Telefono"].ToString();
                       item.sEmail = dbDataReader["Email"].ToString();
                       item.sCurp = dbDataReader["Curp"].ToString();
                       item.sEdadAnos = dbDataReader["EdadAnos"].ToString();
                       item.sEdadMeses = dbDataReader["EdadMeses"].ToString();
                       item.sFoto = dbDataReader["Foto"].ToString();
                       item.sNivelAcademico = dbDataReader["NivelAcademico"].ToString();
                       item.sEstatus = dbDataReader["Estatus"].ToString();
                       item.sNombrePadreTutor = dbDataReader["NombrePadreTutor"].ToString();
                       item.sOcupacionPadre = dbDataReader["OcupacionPadre"].ToString();
                       item.sTelefonoPadre = dbDataReader["TelefonoPadre"].ToString();
                       item.sTelefonoTrabajoPadre = dbDataReader["TelefonoTrabajoPadre"].ToString();
                       item.sCelularPadre = dbDataReader["CelularPadre"].ToString();
                       item.sFechaNacimientoPadre = dbDataReader["FechaNacimientoPadre"].ToString();
                       item.sSueldoPadre = dbDataReader["SueldoPadre"].ToString();
                       item.sNacionalidadPadre = dbDataReader["NacionalidadPadre"].ToString();
                       item.sNombreMadreTutor = dbDataReader["NombreMadreTutor"].ToString();
                       item.sOcupacionMadre = dbDataReader["OcupacionMadre"].ToString();
                       item.sTelefonoMadre = dbDataReader["TelefonoMadre"].ToString();
                       item.sTelefonoTrabajoMadre = dbDataReader["TelefonoTrabajoMadre"].ToString();
                       item.sCelularMadre = dbDataReader["CelularMadre"].ToString();
                       item.sFechaNacimientoMadre = dbDataReader["FechaNacimientoMadre"].ToString();
                       item.sSueldoMadre = dbDataReader["SueldoMadre"].ToString();
                       item.sNacionalidadMadre = dbDataReader["NacionalidadMadre"].ToString();
                       item.sNombreFamVecino = dbDataReader["NombreFamVecino"].ToString();
                       item.sTelefonoVecino = dbDataReader["TelefonoVecino"].ToString();
                       item.sTelefonoTrabajoVecino = dbDataReader["TelefonoTrabajoVecino"].ToString();
                       item.sCelularVecino = dbDataReader["CelularVecino"].ToString();
                       item.sEducacionFisica = dbDataReader["EducacionFisica"].ToString();
                       item.sMedicamento = dbDataReader["Medicamento"].ToString();
                       item.sMedico = dbDataReader["NombreMedicamento"].ToString();
                       item.sDosisMedicamento = dbDataReader["DosisMedicamento"].ToString();
                       item.sAlimentoProhibido = dbDataReader["AlimentoProhibido"].ToString();
                       item.sPeso = dbDataReader["Peso"].ToString();
                       item.sTalla = dbDataReader["Talla"].ToString();
                       item.sTipoSangre = dbDataReader["TipoSangre"].ToString();
                       item.sEnfermedades = dbDataReader["Enfermedades"].ToString();
                       item.sNombreEnfermedades = dbDataReader["NombreEnfermedades"].ToString();
                       item.sProcedimientoCrisis = dbDataReader["ProcedimientoCrisis"].ToString();
                       item.sCertificado = dbDataReader["Certificado"].ToString();
                       item.sEnfermedadCertificado = dbDataReader["EnfermedadCertificado"].ToString();
                       item.sAlergia = dbDataReader["Alergia"].ToString();
                       item.sNombreAlergia = dbDataReader["NombreAlergia"].ToString();
                       item.sProcedimintoCrisisAlergia = dbDataReader["ProcedimintoCrisisAlergia"].ToString();
                       item.sNombreAccidente = dbDataReader["NombreAccidente"].ToString();
                       item.sTelefonoAccidente = dbDataReader["TelefonoAccidente"].ToString();
                       item.sNombreHospital = dbDataReader["NombreHospital"].ToString();
                       item.sMedico = dbDataReader["Medico"].ToString();
                       item.sNombreMedico = dbDataReader["NombreMedico"].ToString();
                       item.sTelefonoMedico = dbDataReader["TelefonoMedico"].ToString();
                       item.sCedulaMedico = dbDataReader["CedulaMedico"].ToString();
                       item.sAutorizaTraslado = dbDataReader["AutorizaTraslado"].ToString();
                       item.sProcedimientoAccidente = dbDataReader["ProcedimientoAccidente"].ToString();
                       item.sTutor = dbDataReader["Tutor"].ToString();
                       item.sBeca = dbDataReader["Beca"].ToString();
                       item.sFormaPago = dbDataReader["FormaPago"].ToString();

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

        public AlumnoEnt ObtieneAlumno2Dat(string Alumno)
        {
            AlumnoEnt item = new AlumnoEnt();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "select NumeroMatricula, idAlumno,Apaterno,Amaterno,Nombres from Alumnos where idAlumno = '" + Alumno + "'";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {

                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        item.sNombres = dbDataReader["Nombres"].ToString();
                       

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


        public AlumnoDs ObtenerAlumnoRpt(string sMatricula)
        {
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            AlumnoDs dsAlumno = new AlumnoDs();
           
            //DataSet oDataSet = new DataSet();
            try
            {

                dbCommand = new OleDbCommand();
                dbCommand.Parameters.Add("MATRICULA", OleDbType.VarChar, 50).Value = sMatricula;
                //dbCommand.Parameters.Add("NumeroPoliza", OleDbType.Integer).Value = sNumeroPoliza;
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);

                dbCommand.Connection = dbConnection;

                dbCommand.CommandType = CommandType.StoredProcedure;

                dbCommand.CommandText = "proc_RPT_ALUMNO";
                OleDbDataAdapter sqlDateAdapter = new OleDbDataAdapter(dbCommand);
                sqlDateAdapter.Fill(dsAlumno, "dtAlumno");

               
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {

                dbConnection.Dispose();

            }

            return dsAlumno;
        }


        public List<GradoEnt> ObtieneGradoDat(string Nivel)
        {
            List<GradoEnt> oGradoLista = new List<GradoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.Parameters.Add("NIVEL", OleDbType.VarChar).Value = Nivel;
                dbCommand.CommandText = "proc_LISTA_GRADO";
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        GradoEnt item = new GradoEnt();
                        item.sIDGrado = dbDataReader["IDGRADO"].ToString();
                        item.sDescripcionGrado = dbDataReader["DESCRIPCIONGRADO"].ToString();
                        oGradoLista.Add(item);
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
                throw new Exception("Mensaje: DAT>AlumnoDAt>ObtieneGradoLista");
            }

            return oGradoLista;

        }

        public string AsignaAlumnoGrupoDat(string idAlumno, string grupo, string ciclo, string user)
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
                dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar).Value = idAlumno;
                dbCommand.Parameters.Add("IDGRUPO", OleDbType.VarChar).Value = grupo;
                dbCommand.Parameters.Add("IDCICLO", OleDbType.VarChar).Value = ciclo;
                dbCommand.Parameters.Add("USUARIO", OleDbType.VarChar).Value = user;
                dbCommand.CommandText = "proc_ASIGNA_ALUMNO_GRUPO";
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
                throw new Exception("Mensaje: DAT>AlumnoDAt>AsignaAlumnoGrupoDat");
            }

            return respuesta;

        }

        public List<AlumnoEnt> ListaAlumnosSearchDat()
        {
            List<AlumnoEnt> oAlumnosLista = new List<AlumnoEnt>();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
               // dbCommand.Parameters.Add("IDGRADO", OleDbType.VarChar).Value = idGrado;
                //  dbCommand.Parameters.Add("IDCICLO", OleDbType.VarChar).Value = idCiclo;


                dbCommand.CommandText = "select * from alumnos";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        AlumnoEnt item = new AlumnoEnt();
                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sNombres = dbDataReader["NumeroMatricula"].ToString() + " - " + dbDataReader["Nombres"].ToString() + " " + dbDataReader["APaterno"].ToString() + " " + dbDataReader["AMaterno"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        oAlumnosLista.Add(item);

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
                throw new Exception("Mensaje: DAT>AlumnoDat>ListarAlumnosGrupo");
            }

            return oAlumnosLista;

        }

        public List<PagosEnt> ListaPagosAlumnoDat(string Alumno)
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
                dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar).Value = Alumno;
                dbCommand.CommandText = "proc_LISTA_PAGOS_ALUMNO";
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();
                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {
                        PagosEnt item = new PagosEnt();
                        //item.sIDGrado = dbDataReader["IDGRADO"].ToString();
                        //item.sDescripcionGrado = dbDataReader["DESCRIPCIONGRADO"].ToString();
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
                throw new Exception("Mensaje: DAT>AlumnoDAt>ObtieneGradoLista");
            }

            return oPagosLista;

        }

        public AlumnoEnt ObtieneInfoAlumnoDat(string Alumno)
        {
            AlumnoEnt item = new AlumnoEnt();
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            OleDbDataReader dbDataReader = null;
            try
            {
                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Connection = dbConnection;
                dbCommand.CommandText = "select A.idAlumno, A.NumeroMatricula, A.APaterno, A.AMaterno , A.Nombres, " +
                                        "G.DescripcionGrado, GR.NombreGrupo from Alumnos A, GRUPO GR, GRADO G where NumeroMatricula='" + Alumno + "'" +
                                        " AND G.IDGrado = a.Grado and A.Grupo = gr.IDGrupo";
                dbCommand.CommandType = CommandType.Text;
                dbConnection.Open();
                dbDataReader = dbCommand.ExecuteReader();

                if (dbDataReader.HasRows)
                {
                    while (dbDataReader.Read())
                    {

                        item.sIdAlumno = dbDataReader["IdAlumno"].ToString();
                        item.sNumeroMatricula = dbDataReader["NumeroMatricula"].ToString();
                        item.sAPaterno = dbDataReader["APaterno"].ToString();
                        item.sAMaterno = dbDataReader["AMaterno"].ToString();
                        item.sNombres = dbDataReader["Nombres"].ToString();
                    
                        item.sGrado = dbDataReader["DescripcionGrado"].ToString();
                        item.sGrupo = dbDataReader["NombreGrupo"].ToString();

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

        public ReciboDS ObtenerReciboRpt(string sAlumno)
        {
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            ReciboDS dsRecibo = new ReciboDS();

            //DataSet oDataSet = new DataSet();
            try
            {

                dbCommand = new OleDbCommand();
                dbCommand.Parameters.Add("IDALUMNO", OleDbType.VarChar, 50).Value = sAlumno;
                //dbCommand.Parameters.Add("NumeroPoliza", OleDbType.Integer).Value = sNumeroPoliza;
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);

                dbCommand.Connection = dbConnection;

                dbCommand.CommandType = CommandType.StoredProcedure;

                dbCommand.CommandText = "proc_RPT_RECIBO";
                OleDbDataAdapter sqlDateAdapter = new OleDbDataAdapter(dbCommand);
                sqlDateAdapter.Fill(dsRecibo, "dtRecibo");
                dbCommand.CommandText = "proc_RPT_RECIBO_ALUMNO";
                OleDbDataAdapter sqlDateAdapter2 = new OleDbDataAdapter(dbCommand);
                sqlDateAdapter.Fill(dsRecibo, "dtReciboAlumno");


            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {

                dbConnection.Dispose();

            }

            return dsRecibo;
        }

        public DeudoresDs ObtenerDeudoresRpt()
        {
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            DeudoresDs dsDeudores = new DeudoresDs();

            //DataSet oDataSet = new DataSet();
            try
            {

                dbCommand = new OleDbCommand();

                dbConnection = new OleDbConnection(constring);
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);

                dbCommand.Connection = dbConnection;

                dbCommand.CommandType = CommandType.StoredProcedure;

                dbCommand.CommandText = "proc_LISTA_DEUDORES";
                OleDbDataAdapter sqlDateAdapter = new OleDbDataAdapter(dbCommand);
                sqlDateAdapter.Fill(dsDeudores, "dtDeudores");


            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {

                dbConnection.Dispose();

            }

            return dsDeudores;
        }


        public CredencialDS ObtenerCredencialesRpt(string Matricula)
        {
            OleDbConnection dbConnection = null;
            OleDbCommand dbCommand = null;
            CredencialDS dsCredencial = new CredencialDS();

            //DataSet oDataSet = new DataSet();
            try
            {

                dbCommand = new OleDbCommand();
                //dbConnection = new OleDbConnection(ConexionString.connStringIEL);
                dbConnection = new OleDbConnection(constring);
                dbCommand.Parameters.Add("MATRICULA", OleDbType.VarChar, 300).Value = Matricula;
                dbCommand.Connection = dbConnection;

                dbCommand.CommandType = CommandType.StoredProcedure;

                dbCommand.CommandText = "proc_RPT_CREDENCIAL";
                OleDbDataAdapter sqlDateAdapter = new OleDbDataAdapter(dbCommand);
                sqlDateAdapter.Fill(dsCredencial, "dtCredencial");


            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {

                dbConnection.Dispose();

            }

            return dsCredencial;
        }
      



    }
}
