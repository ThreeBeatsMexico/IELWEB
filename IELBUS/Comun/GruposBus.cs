using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELDAT;
using IELENT;

namespace IELBUS
{
    public class GruposBus
    {
        GrupoDat oGrupoDat = new GrupoDat();
        public List<GrupoEnt> ListaGrupos()
        {

            return oGrupoDat.ListaGruposDat();


        }

        public GrupoEnt ObtieneGrupo(string Grupo)
        {
            return oGrupoDat.ObtieneGruposDat(Grupo);
        }

        public string fnRegistroGrupoBus(GrupoEnt GrupoItem)
        {
            return oGrupoDat.fnRegistroGrupoDat(GrupoItem);
        }

        public string ValidaGrupoBus(GrupoEnt GrupoItem)
        {
            return oGrupoDat.ValidaGrupo(GrupoItem);
        }

        public string EliminaGrupo(string idGrupo)
        {
            return oGrupoDat.EliminaGrupo(idGrupo);
        }
    }
}
