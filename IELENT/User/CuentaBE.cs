using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.User
{
    [Serializable]
    public class CuentaBE
    {
        
        public string IdCuenta { get; set; }
        
        public string IdAplicacion { get; set; }
        
        public string APaterno { get; set; }
        
        public string AMaterno { get; set; }
        
        public string Nombres { get; set; }
        
        public string RFCSiglas { get; set; }
        
        public string RFCFecha { get; set; }
        
        public string RFCHomo { get; set; }
        
        public string Activo { get; set; }
    }
}
