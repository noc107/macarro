using BackOffice.Presentacion.Contratos.UsuariosInternos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.UsuariosInternos
{
    public class Presentador_09_gestionUsuario : PresentadorGeneral
    {
        private IContrato_09_gestionUsuario _contratoGestionUsuario;


        public Presentador_09_gestionUsuario(IContrato_09_gestionUsuario _contratoGestionUsuario)
            : base(_contratoGestionUsuario)
        {
            this._contratoGestionUsuario = _contratoGestionUsuario;
        }


        public void PageLoad()
        {


        }
    }
}