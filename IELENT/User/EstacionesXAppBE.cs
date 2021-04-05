using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.User
{
    [Serializable]
    public class EstacionesXAppBE
    {
        //Propiedades de Domicilio:
        private Int64 iIDESTACIONXAPP;
        
        public Int64 IDESTACIONXAPP
        {
            get { return iIDESTACIONXAPP; }
            set { iIDESTACIONXAPP = value; }
        }

        private Int64 iIDAPLICACION;
        
        public Int64 IDAPLICACION
        {
            get { return iIDAPLICACION; }
            set { iIDAPLICACION = value; }
        }

        private Int32 iIDESTACION;
        
        public Int32 IDESTACION
        {
            get { return iIDESTACION; }
            set { iIDESTACION = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }

    }
}
