using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IELENT.User
{
    [Serializable]
    public class DatosUsuarioBE
    {
        
        public UsuariosBE Usuario = new UsuariosBE();
        
        public List<DomicilioBE> Domicilios = new List<DomicilioBE>();
        
        public List<ContactoBE> Contactos = new List<ContactoBE>();
        
        public List<RolesXUsuarioBE> RolesXUsuario = new List<RolesXUsuarioBE>();
        
        public List<RolesXUsuarioBE> RolesVSUsuario = new List<RolesXUsuarioBE>();
        
        public List<UsuariosBE> Usuarios = new List<UsuariosBE>();
    }
}
