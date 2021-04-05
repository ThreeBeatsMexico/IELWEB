using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.Security
{
   
    public class WCFMetodosBE
    {
        private Int64 iIDMETODOS;
        
        public Int64 IDMETODOS
        {
            get { return iIDMETODOS; }
            set { iIDMETODOS = value; }
        }

        private Int64 iIDAPLICACION;
        
        public Int64 IDAPLICACION
        {
            get { return iIDAPLICACION; }
            set { iIDAPLICACION = value; }
        }

        private Int64 iIDSERVICIOS;
        
        public Int64 IDSERVICIOS
        {
            get { return iIDSERVICIOS; }
            set { iIDSERVICIOS = value; }
        }

        private String sNOMBREMETODO;
        
        public String NOMBREMETODO
        {
            get { return sNOMBREMETODO; }
            set { sNOMBREMETODO = value; }
        }

        private bool bRECURRENTE;
        
        public bool RECURRENTE
        {
            get { return bRECURRENTE; }
            set { bRECURRENTE = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }

        
        public string RowIndex { get; set; }
        
        public bool Actualizado { get; set; }
    }
}
