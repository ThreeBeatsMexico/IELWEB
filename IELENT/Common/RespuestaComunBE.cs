using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IELENT.Common
{
    [Serializable]
    public class RespuestaComunBE
    {
        
        public List<CatalogosBE> lstCatalogo { get; set; }
        
        public List<CatGeneralesBE> lstCatGenerales { get; set; }
        
        public List<ConfiguracionBE> lstConfiguracion { get; set; }
        
        public ErrorBE itemError { get; set; }
        
        public string psIDCONFIGAPP { get; set; }
        
        public string psIdentityTabla { get; set; }
        
        public string psDescripcionTabla { get; set; }
    }
}
