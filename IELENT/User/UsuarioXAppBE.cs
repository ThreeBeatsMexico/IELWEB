using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.User
{
    [Serializable]
    public class UsuarioXAppBE
    {
        
        public string IDUSRSXAPP { get; set; }
        
        public string IDAPLICACION { get; set; }
        
        public string IDUSUARIO { get; set; }
        
        public string DESCRIPCION { get; set; }
        
        public string URLINICIO { get; set; }
        
        public string ACTIVO { get; set; }


    }
}
