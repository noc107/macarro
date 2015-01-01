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
    public class Presentador_09_modificarUsuario: PresentadorGeneral
    {
        private IContrato_09_modificarUsuario _contratoModificarUsuario;


        public Presentador_09_modificarUsuario(IContrato_09_modificarUsuario _contratoModificarUsuario)
            : base(_contratoModificarUsuario)
        {
            this._contratoModificarUsuario = _contratoModificarUsuario; 
        }


        public void PageLoad() 
        {
            

        }
    }
}