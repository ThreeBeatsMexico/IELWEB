using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class ConfiguracionBE
    {
        
        public string psIDCONFIGAPP { get; set; }
        
        public string psIDCONFIGAPPNEW { get; set; }
        
        public string psDESCRIPCION { get; set; }
        
        public string psVALOR { get; set; }
        
        public string psACTIVO { get; set; }
    }
}
