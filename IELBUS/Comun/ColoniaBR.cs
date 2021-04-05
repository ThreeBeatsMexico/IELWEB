using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELENT;
using IELDAT;

namespace IELBUS
{
   public class ColoniaBR
    {
        public List<ColoniaBE> ObtenerInformacionPorCP(string CodigoPostal)
        {
            CodigoPostalDAT oCodigoPostalDat = new CodigoPostalDAT();

            return oCodigoPostalDat.ObtenerInformacionPorCP(CodigoPostal);
        }
    }
}
