using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IELENT
{
   public class PagosEnt 
    {
        public string psIDPago { get; set; }
        public string psIDAlumno { get; set; }
        public string psConcepto { get; set; }
        public string psMontoTotal { get; set; }
        public string psMontoActual { get; set; }
        public string psIDEstaus { get; set; }
        public string psFechaMovimiento { get; set; }
        public string psEstado { get; set; }

        public string psMedioPago { get; set; }
      
        public string psReferencia { get; set; }
       
    }
}
