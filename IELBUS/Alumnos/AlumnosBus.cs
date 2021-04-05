using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELENT;
using IELDAT;
using System.Data;

namespace IELBUS
{
   public class AlumnosBus
    {
       AlumnoDat oAlumno = new AlumnoDat();
       public List<AlumnoEnt> ListaAlumnos(AlumnoEnt oAlumnoEnt)
       {
           return oAlumno.ListaAlumnosDat(oAlumnoEnt);
       }
       public List<AlumnoEnt> ListaAlumnosGrupo(string idGrupo, string idGrado, string idCiclo)
       {
           return oAlumno.ListaAlumnosGrupoDat(idGrupo,idGrado,idCiclo);
       }
       public List<AlumnoEnt> ListaAlumnosGrupoAdd(string idGrado, string idCiclo)
       {
           return oAlumno.ListaAlumnosGrupoAddDat(idGrado,idCiclo);
       }

       public List<AlumnoEnt> ListaAlumnosSearch()
       {
           return oAlumno.ListaAlumnosSearchDat();
       }

       public AlumnoEnt ObtieneAlumno(string Alumno)
       {
           return oAlumno.ObtieneAlumnoDat(Alumno);
       }

       public AlumnoEnt ObtieneInfoAlumnoBus(string Alumno)
       {
           return oAlumno.ObtieneInfoAlumnoDat(Alumno);
       }
       public AlumnoEnt ObtieneAlumno2(string Alumno)
       {
           return oAlumno.ObtieneAlumno2Dat(Alumno);
       }

       public string fnRegistroAlumnosBus(AlumnoEnt AlumnoItem)
       {
           return oAlumno.fnRegistroAlumnoDat(AlumnoItem);
       }

       public DataSet ObtieneAlumnoRpt(string Matricula)
       {
           return oAlumno.ObtenerAlumnoRpt(Matricula);
       }

       public List<GradoEnt> ObtieneGrado(string Nivel)
       {
           return oAlumno.ObtieneGradoDat(Nivel);
       }

       public string AsignaAlumnoGrupo(string idAlumno,string grupo,string ciclo , string user)
       {
           return oAlumno.AsignaAlumnoGrupoDat(idAlumno,grupo,ciclo,user);
       }
       public List<PagosEnt> ListaPagosAlumno(string idAlumno)
       {
           return oAlumno.ListaPagosAlumnoDat(idAlumno);
       }
       public DataSet ObtieneRecibo(string Alumno)
       {
           return oAlumno.ObtenerReciboRpt(Alumno);
       }
       public DataSet ObtieneDeudoresRpt()
       {
           return oAlumno.ObtenerDeudoresRpt();
       }
       public DataSet ObtieneCredencialRpt(string Matriculas)
       {
           return oAlumno.ObtenerCredencialesRpt(Matriculas);
       }
    }
}
