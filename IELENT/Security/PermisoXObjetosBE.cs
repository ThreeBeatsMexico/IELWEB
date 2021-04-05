using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{    
   
    public class PermisoXObjetosBE
    {
        private Int64 iIDPERMISOSOBJ;
        
        public Int64 IDPERMISOSOBJ
        {
            get { return iIDPERMISOSOBJ; }
            set { iIDPERMISOSOBJ = value; }
        }

        private Int64 iIDROL;
        
        public Int64 IDROL
        {
            get { return iIDROL; }
            set { iIDROL = value; }
        }

        private String sPAGINA;
        
        public String PAGINA
        {
            get { return sPAGINA; }
            set { sPAGINA = value; }
        }

        private String sNOMBREOBJETO;
        
        public String NOMBREOBJETO
        {
            get { return sNOMBREOBJETO; }
            set { sNOMBREOBJETO = value; }
        }

        private String sTIPOOBJETO;
        
        public String TIPOOBJETO
        {
            get { return sTIPOOBJETO; }
            set { sTIPOOBJETO = value; }
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
