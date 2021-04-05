using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IELENT.Common;
using IELDAT.Common;

namespace IELBUS.Common
{
    public class ConfiguracionBR
    {
        public RespuestaComunBE GetConfigAPP(ConfiguracionBE item)
        {
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            Respuesta = oConfiguracionDA.GetConfigAPP(item);

            return Respuesta;
        }
        public RespuestaComunBE AddConfigAPP(ConfiguracionBE item)
        {
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = oConfiguracionDA.AddConfigAPP(item, sConexionString);

            return Respuesta;
        }
        public RespuestaComunBE SetConfigAPP(ConfiguracionBE item)
        {
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = Respuesta.lstConfiguracion[0].psVALOR;

            Respuesta = oConfiguracionDA.SetConfigAPP(item, sConexionString);

            return Respuesta;
        }
    }
}
