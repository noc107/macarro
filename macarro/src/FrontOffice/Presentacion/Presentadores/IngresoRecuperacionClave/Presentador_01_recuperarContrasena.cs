using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_recuperarContrasena : PresentadorGeneral
    {
        private IContrato_01_recuperarContrasena _contratorecuperarContrasena;

        //Constructor
        public Presentador_01_recuperarContrasena(IContrato_01_recuperarContrasena _contratorecuperarContrasena)
            : base(_contratorecuperarContrasena)
        {
            this._contratorecuperarContrasena = _contratorecuperarContrasena;
        }

        public void Aceptar_Click()
        {
            // Se procede con el cambio de contraseña (Lógica)
        }

    }
}