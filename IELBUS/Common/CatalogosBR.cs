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
    public class CatalogosBR
    {
        public RespuestaComunBE GetCatGenerales(CatGeneralesBE item)
        {
            CatalogosDA oCatalogosDA = new CatalogosDA();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA(); 
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;

            Respuesta = oCatalogosDA.GetCatGenerales(item, sConexionString);

            return Respuesta;
        }
        public RespuestaComunBE AddCatGenerales(CatGeneralesBE item)
        {
            CatalogosDA oCatalogosDA = new CatalogosDA();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;

            Respuesta = oCatalogosDA.AddCatGenerales(item, sConexionString);

            return Respuesta;
        }
        public RespuestaComunBE SetCatGenerales(CatGeneralesBE item)
        {
            CatalogosDA oCatalogosDA = new CatalogosDA();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();

            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;

            Respuesta = oCatalogosDA.SetCatGenerales(item, sConexionString);

            return Respuesta;
        }


        public RespuestaComunBE GetCatEspecifico(string sIdCatalogo, string sValorFiltro = "")
        {
            CatalogosDA oCatalogosDA = new CatalogosDA();
            CatGeneralesBE item = new CatGeneralesBE();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();
            

            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString; 

            item.psIDCATGENERALES = sIdCatalogo;
            
            Respuesta = GetCatGenerales(item);

            item = Respuesta.lstCatGenerales[0];
            item.psVALORFILTRO = sValorFiltro;

            Respuesta = oCatalogosDA.GetCatEspecifico(Respuesta.lstCatGenerales[0], sConexionString);

            return Respuesta;
        }
        public RespuestaComunBE AddCatEspecifico(string sIdCatalogo, string sDescripcion)
        {
            CatalogosDA oCatalogosDA = new CatalogosDA();
            CatGeneralesBE item = new CatGeneralesBE();
            ConfiguracionDA oConfiguracionDA = new ConfiguracionDA();
            RespuestaComunBE Respuesta = new RespuestaComunBE();
            ConfiguracionBE itemConfig = new ConfiguracionBE();


            string sConexionString = string.Empty;

            //itemConfig.psIDCONFIGAPP =  ConfigurationSettings.AppSettings["IELDBConn"].ToString();

            //Respuesta = oConfiguracionDA.GetConfigAPP(itemConfig);
            sConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["IELDBConn"].ConnectionString;

            item.psIDCATGENERALES = sIdCatalogo;

            Respuesta = GetCatGenerales(item);


            Respuesta = oCatalogosDA.AddCatEspecifico(Respuesta.lstCatGenerales[0],sDescripcion, sConexionString);

            return Respuesta;

        }
        
    }
}
