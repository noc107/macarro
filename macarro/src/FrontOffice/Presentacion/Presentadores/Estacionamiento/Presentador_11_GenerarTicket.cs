using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Estacionamiento;

namespace FrontOffice.Presentacion.Presentadores.Estacionamiento
{
    public class Presentador_11_GenerarTicket : PresentadorGeneral
    {
        private IContrato_11_GenerarTicket _vista;

        public Presentador_11_GenerarTicket(IContrato_11_GenerarTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        }

        public void EventoClickAceptar()
        {
            throw new NotImplementedException();
        }


    }
}