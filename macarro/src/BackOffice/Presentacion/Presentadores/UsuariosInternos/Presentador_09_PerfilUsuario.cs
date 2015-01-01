using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BackOffice.Presentacion.Contratos.UsuariosInternos;

namespace BackOffice.Presentacion.Presentadores.UsuariosInternos
{
    public class Presentador_09_PerfilUsuario : PresentadorGeneral
    {
        private IContrato_09_PerfilUsuario _contratoPerfilUsuario;

        

        public Presentador_09_PerfilUsuario(IContrato_09_PerfilUsuario _contratoPerfilUsuario)
            : base(_contratoPerfilUsuario)
        {
            this._contratoPerfilUsuario = _contratoPerfilUsuario;
        }

        public void PageLoad()
        {


        }
    }
}