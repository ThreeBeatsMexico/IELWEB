using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{
   
    public class PermisoXElementosObjBE
    {
        private Int64 iIDELEMENTOSXOBJ;
        
        public Int64 IDELEMENTOSXOBJ
        {
            get { return iIDELEMENTOSXOBJ; }
            set { iIDELEMENTOSXOBJ = value; }
        }

        private Int64 iIDPERMISOSOBJ;
        
        public Int64 IDPERMISOSOBJ
        {
            get { return iIDPERMISOSOBJ; }
            set { iIDPERMISOSOBJ = value; }
        }

        private String sELEMENTO;
        
        public String ELEMENTO
        {
            get { return sELEMENTO; }
            set { sELEMENTO = value; }
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
    }
}
