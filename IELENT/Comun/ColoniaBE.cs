using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IELENT
{
   public class ColoniaBE
    {
        public string NombreMunicpio { get; set; }
        public string NombreEstado { get; set; }
        public string ClaveMunicipio { get; set; }
        public string ClaveEntidad { get; set; }
        public string CodigoPostal { get; set; }
        public string NombreColonia { get; set; }
        public string ClaveColonia { get; set; }
        public string CodigoPostalAdmon { get; set; }
        public string ClaveTipoAsenta { get; set; }
        public string TipoAsenta { get; set; }
        public string ClaveCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public string Zona { get; set; }
       

        //[10-06-14][DGRV][Se agrego el objeto]
        public bool ORIGINAL { get; set; }
        //[10-06-14][DGRV][]
    }
}
