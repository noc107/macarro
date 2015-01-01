using BackOffice.Presentacion.Contratos.UsuariosInternos;
using BackOffice.Presentacion.Contratos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


namespace BackOffice.Presentacion.Presentadores.UsuariosInternos
{
    public class Presentador_09_agregarUsuario: PresentadorGeneral
    {

        private IContrato_09_AgregarUsuario _vista;


        public Presentador_09_agregarUsuario(IContrato_09_AgregarUsuario _vista)
            : base(_vista)
        {
            this._vista = _vista; 
        }

        public void PageLoad()
        {


        }


    }
}