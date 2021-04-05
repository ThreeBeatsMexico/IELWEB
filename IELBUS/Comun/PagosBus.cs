using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELDAT;
using IELENT;
using System.Data;


namespace IELBUS
{
   public class PagosBus
    {
       PagosDat oPagosDat = new PagosDat();
      public List<PagosEnt> ListaPagosAlumno(string idAlumno)
       {
           return oPagosDat.ListaPagosAlumno(idAlumno);
       }

      public List<PagosEnt> ListaPagosAlumnoMatricula(string sMatricula)
      {
          return oPagosDat.ListaPagosAlumnoMatricula(sMatricula);
      }

      public PagosEnt ObtienePago(string idPago)
      {
          return oPagosDat.ObtienePago(idPago);
      }

      public string RegistraPago(PagosEnt itemPago)
      {
          return oPagosDat.RegistraPago(itemPago);
      }


      public List<TransaccionEnt> ConsultaTransaccionesPago(string idPago, string idAlumno)
      {
          return oPagosDat.ListraTransaccionesPago(idPago, idAlumno);
      }

      public DataSet ObtieneReportePagosRpt(string FechaInicial, string FechaFinal)
      {
          return oPagosDat.ObtieneReportePagosDat(FechaInicial, FechaFinal);
      }

    }
}
