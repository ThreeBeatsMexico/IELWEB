using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IELDAT.Security;
using IELENT.Security;
using IELENT.Common;
using IELDAT.Common;
using System.Configuration;

namespace IELBUS.Common
{
    public class CommonBR
    {
        public RespuestaComunBE GetDefinicionTabla(string sNombreTabla)
        {
            CommonDA oCommonDA = new CommonDA();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();
            List<CatalogosBE> lsCatalogos = new List<CatalogosBE>();


            string sConexionString = string.Empty;

            itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = oCommonDA.GetDefinicionTabla(sNombreTabla, sConexionString);

            return Respuesta;
        }
    }

}
