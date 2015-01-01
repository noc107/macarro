using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;

namespace FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave
{
    public class Presentador_01_modificar : PresentadorGeneral
    {
        private IContrato_01_modificar _contratoModificar;

        //Constructor
        public Presentador_01_modificar(IContrato_01_modificar _contratoModificar)
            : base(_contratoModificar)
        {
            this._contratoModificar = _contratoModificar;
        }

        public void aceptar_Click()
        {
            // Se procede con el modificar (Lógica)
        }


    }
}