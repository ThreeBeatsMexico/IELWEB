using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{
   
    public class PermisosXSubmenuBE
    {

        private Int64 iIDPERMISOSXSUBMENU;
        
        public Int64 IDPERMISOSXSUBMENU
        {
            get { return iIDPERMISOSXSUBMENU; }
            set { iIDPERMISOSXSUBMENU = value; }
        }

        private Int64 iIDPERMISOSMENU;
        
        public Int64 IDPERMISOSMENU
        {
            get { return iIDPERMISOSMENU; }
            set { iIDPERMISOSMENU = value; }
        }

        private String sNOMBRESUBMENU;
        
        public String NOMBRESUBMENU
        {
            get { return sNOMBRESUBMENU; }
            set { sNOMBRESUBMENU = value; }
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

        private Int32 iORDENSUBMENU;
        
        public Int32 ORDENSUBMENU
        {
            get { return iORDENSUBMENU; }
            set { iORDENSUBMENU = value; }
        }
    }
}
