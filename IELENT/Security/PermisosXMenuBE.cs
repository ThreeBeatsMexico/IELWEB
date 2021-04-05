using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{
   
    public class PermisosXMenuBE
    {
        private Int64 iIDPERMISOSMENU;
        
        public Int64 IDPERMISOSMENU
        {
            get { return iIDPERMISOSMENU; }
            set { iIDPERMISOSMENU = value; }
        }

        private Int64 iIDROL;
        
        public Int64 IDROL
        {
            get { return iIDROL; }
            set { iIDROL = value; }
        }

        private String sNOMBREMENU;
        
        public String NOMBREMENU
        {
            get { return sNOMBREMENU; }
            set { sNOMBREMENU = value; }
        }

        private String sIMAGEN;
        
        public String IMAGEN
        {
            get { return sIMAGEN; }
            set { sIMAGEN = value; }
        }

        private String sTIPOOBJETO;
        
        public String TIPOOBJETO
        {
            get { return sTIPOOBJETO; }
            set { sTIPOOBJETO = value; }
        }

        private String sURL;
        
        public String URL
        {
            get { return sURL; }
            set { sURL = value; }
        }

        private String sTOOLTIP;
        
        public String TOOLTIP
        {
            get { return sTOOLTIP; }
            set { sTOOLTIP = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }

        private Int32 iORDENMENU;
        
        public Int32 ORDENMENU
        {
            get { return iORDENMENU; }
            set { iORDENMENU = value; }
        }
    }

}
