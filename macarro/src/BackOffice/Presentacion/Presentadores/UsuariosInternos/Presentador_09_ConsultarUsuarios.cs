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
    public class Presentador_09_ConsultarUsuarios : PresentadorGeneral
    {
        private IContrato_09_ConsultarUsuarios _contratoPerfilUsuario;



        public Presentador_09_ConsultarUsuarios(IContrato_09_ConsultarUsuarios _contratoPerfilUsuario)
            : base(_contratoPerfilUsuario)
        {
            this._contratoPerfilUsuario = _contratoPerfilUsuario;
        }

        public void PageLoad()
        {


        }

    }
}