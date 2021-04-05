using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELDAT;
using IELENT;

namespace IELBUS
{
    public class CiclosBus
    {
        CiclosDat oCicloDat= new CiclosDat();
        public List<CicloEnt> ListaCiclos()
        {

            return oCicloDat.ListaCiclosDat(); 
          

        }

        public CicloEnt ObtieneCiclo(string Ciclo)
        {
            return oCicloDat.ObtieneCicloDat(Ciclo);
        }

        public string fnRegistroCicloBus(CicloEnt CicloItem)
        {
            return oCicloDat.fnRegistroCicloDat(CicloItem);
        }


    }
}
