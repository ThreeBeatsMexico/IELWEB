using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IELENT.Common
{
    [Serializable]
    public class RespuestaGralBE
    {

        private bool bFLAG;
        
        public bool FLAG
        {
            get { return bFLAG; }
            set { bFLAG = value; }
        }

        private string sERRORMESSAGE;
        
        public string ERRORMESSAGE
        {
            get { return sERRORMESSAGE; }
            set { sERRORMESSAGE = value; }
        }

        private string sTRACE;
        
        public string TRACE
        {
            get { return sTRACE; }
            set { sTRACE = value; }
        }
    }
}
