using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IELDAT;
using IELENT;

namespace IELBUS
{
    public class UsuarioBus
    {
       public string UsuarioLoginBus(UsuarioEnt User)
        {
           UsuarioLoginDat busUser = new UsuarioLoginDat();
           return busUser.ObtieneUsuarioLogin(User);
            
        
        
        }

       public List<UsuarioEnt> ListaUsuarios()
       {
           UsuarioLoginDat listaUsuarios = new UsuarioLoginDat();
           return listaUsuarios.ListaUsuariosDat();
       
       }

       public UsuarioEnt ObtieneUsuario(string usuario)
       {
           UsuarioLoginDat oUsuario = new UsuarioLoginDat();
           return oUsuario.ObtieneUsuarioDat(usuario);

       }

      public bool fnRegistroBus(UsuarioEnt UsuarioItem)
       {

           UsuarioLoginDat oUsuario = new UsuarioLoginDat();
           return oUsuario.fnRegistroDat(UsuarioItem);
           
           
       }

    }
}
