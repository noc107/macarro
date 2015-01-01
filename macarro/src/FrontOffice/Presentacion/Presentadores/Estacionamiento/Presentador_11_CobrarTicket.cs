using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Estacionamiento;

namespace FrontOffice.Presentacion.Presentadores.Estacionamiento
{
    public class Presentador_11_CobrarTicket : PresentadorGeneral
    {

        private IContrato_11_CobrarTicket _vista;

        public Presentador_11_CobrarTicket(IContrato_11_CobrarTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        
        }

        public void EventoClickCobrar()
        {
            throw new NotImplementedException();
        }
    }
    
}