using BackOffice.Presentacion.Contratos.InventarioRestaurante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Presentacion.Presentadores.InventarioRestaurante
{
    public class Presentador_06_agregarItem : PresentadorGeneral
    {
        private IContrato_06_agregarItem _contrato;
        public Presentador_06_agregarItem(IContrato_06_agregarItem _contrato)
            : base(_contrato)
        {
            this._contrato = _contrato;
        }

        public void EventoAceptar()
        { 
      
        
        }
    }
}