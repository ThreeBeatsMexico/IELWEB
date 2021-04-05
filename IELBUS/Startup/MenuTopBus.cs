using IELENT;
using IELDAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IELBUS
{
   public class MenuTopBus
    {

        public MenuTopEnt ObtieneMenuPrincipal(string sIDUsuario)
        {
            MenuTopDat oMenuTopDat = new MenuTopDat();

            return oMenuTopDat.ObtieneMenuPrincipal(sIDUsuario);
        }


       
    }
}
