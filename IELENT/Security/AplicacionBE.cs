using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{
   
    public class AplicacionBE
    {
        private Int64 iIDAPLICACION;
        
        public Int64 IDAPLICACION
        {
            get { return iIDAPLICACION; }
            set { iIDAPLICACION = value; }
        }

        private Int64 iIDUSRSXAPP;
        
        public Int64 IDUSRSXAPP
        {
            get { return iIDUSRSXAPP; }
            set { iIDUSRSXAPP = value; }
        }

        private Int64 iIDUSUARIO;
        
        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private String sDESCRIPCION;
        
        public String DESCRIPCION
        {
            get { return sDESCRIPCION; }
            set { sDESCRIPCION = value; }
        }

        private String sURLINICIO;
        
        public String URLINICIO
        {
            get { return sURLINICIO; }
            set { sURLINICIO = value; }
        }
        private String sPASSWORD;
        
        public String PASSWORD
        {
            get { return sPASSWORD; }
            set { sPASSWORD = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }

    }
}
