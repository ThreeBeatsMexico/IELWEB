using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IELSECVB;

namespace IELBUS
{
   public class TokenBus
    {
        public string EncriptaToken(string sCadena)
        {
            string sRespuesta = string.Empty;
            //string sRespuesta2 = string.Empty;
            EncryptDecryptSecVb oEncryptDecryptSecVB = new EncryptDecryptSecVb();

            sRespuesta = oEncryptDecryptSecVB.EncryptString(sCadena, "599E9A82");

            //sRespuesta2 = oEncryptDecryptSecVB.DecryptString("D200BE4C5BB5E656", "llave");

            return sRespuesta;
        }

        public string DesencriptaToken(string sCadena)
        {
            string sResputesta = string.Empty;
            EncryptDecryptSecVb oEncryptDecryptSecVB = new EncryptDecryptSecVb();
            sResputesta = oEncryptDecryptSecVB.DecryptString(sCadena, "599E9A82");

            return sResputesta;
        }
    }
}
