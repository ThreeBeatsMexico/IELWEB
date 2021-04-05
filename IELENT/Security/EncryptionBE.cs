using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{

   
    public class EncryptionBE
    {
        private string sVALORIN;
        
        public string VALORIN
        {
            get { return sVALORIN; }
            set { sVALORIN = value; }
        }

        private string sVALOROUT;
        
        public string VALOROUT
        {
            get { return sVALOROUT; }
            set { sVALOROUT = value; }
        }
    }
}
