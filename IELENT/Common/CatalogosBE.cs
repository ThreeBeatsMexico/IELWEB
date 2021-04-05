using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class CatalogosBE
    {
        private string sDESCRIPCION;
        
        public string DESCRIPCION
        {
            get { return sDESCRIPCION; }
            set { sDESCRIPCION = value; }
        }

        private string sID;
        
        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }

    }
}
