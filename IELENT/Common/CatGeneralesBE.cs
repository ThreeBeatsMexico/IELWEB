using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class CatGeneralesBE
    {
        
        public string psIDCATGENERALES { get; set; }
        
        public string psNOMBRECATALOGO { get; set; }
        
        public string psIDCATALOGO { get; set; }
        
        public string psDESCRIPCION { get; set; }
        
        public string psFILTRO { get; set; }
        
        public string psACTIVO { get; set; }
        
        public string psIDSUBCATALOGO { get; set; }
        
        public string psVALORFILTRO { get; set; }
    }
}
