using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class Cat_GralsBE
    {
        private Int64 iIDCATGRAL;
        
        public Int64 IDCATGRAL
        {
            get { return iIDCATGRAL; }
            set { iIDCATGRAL = value; }
        }

        private string sNOMBRETABLA;
        
        public string NOMBRETABLA
        {
            get { return sNOMBRETABLA; }
            set { sNOMBRETABLA = value; }
        }

        private string sIDTABLA;
        
        public string IDTABLA
        {
            get { return sIDTABLA; }
            set { sIDTABLA = value; }
        }

        private string sDESCRIPCIONTABLA;
        
        public string DESCRIPCIONTABLA
        {
            get { return sDESCRIPCIONTABLA; }
            set { sDESCRIPCIONTABLA = value; }
        }

        private string sIDFILTRO;
        
        public string IDFILTRO
        {
            get { return sIDFILTRO; }
            set { sIDFILTRO = value; }
        }
    }
}
