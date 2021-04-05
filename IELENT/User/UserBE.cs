using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IELENT.User
{
     [Serializable]
   public class UserBE
    {

        private UsuariosBE iUSUARIOS;

        public UsuariosBE USUARIOS
        {
            get { return iUSUARIOS; }
            set { iUSUARIOS = value; }
        }

        private DatosUsuarioBE iDATOSUSUARIO;

        public DatosUsuarioBE DATOSUSUARIO
        {
            get { return iDATOSUSUARIO; }
            set { iDATOSUSUARIO = value; }
        }
        private List<DomicilioBE> iDOMICILIO;

        public List<DomicilioBE> DOMICILIOS
        {
            get { return iDOMICILIO; }
            set { iDOMICILIO = value; }
        }

        private List<ContactoBE> iCONTACTOS;

        public List<ContactoBE> CONTACTOS
        {
            get { return iCONTACTOS; }
            set { iCONTACTOS = value; }
        }

        private List<RolesXUsuarioBE> iROLESXUSUARIO;

        public List<RolesXUsuarioBE> ROLESXUSUARIO
        {
            get { return iROLESXUSUARIO; }
            set { iROLESXUSUARIO = value; }
        }

       
    }
}
