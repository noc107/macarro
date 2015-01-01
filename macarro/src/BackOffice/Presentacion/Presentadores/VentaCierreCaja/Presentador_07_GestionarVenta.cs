using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;


namespace BackOffice.Presentacion.Presentadores.VentaCierreCaja
{
    public class Presentador_07_GestionarVenta : PresentadorGeneral
    {
        private IContrato_07_GestionarVenta _contratoGestionarVenta;
        
        public Presentador_07_GestionarVenta(IContrato_07_GestionarVenta _contratoGestionarVenta)
            : base(_contratoGestionarVenta)
        { 
            this._contratoGestionarVenta = _contratoGestionarVenta;
        }

    }
}