using FrontOffice.Presentacion.Contratos.Estacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Presentacion.Presentadores.Estacionamiento
{
    public class Presentador_11_detalleTicket : PresentadorGeneral

    {

          private IContrato_11_detalleTicket _vista;

          public Presentador_11_detalleTicket(IContrato_11_detalleTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        
        }

        public void EventoClickVolver()
        {
            throw new NotImplementedException();
        }
    }
}