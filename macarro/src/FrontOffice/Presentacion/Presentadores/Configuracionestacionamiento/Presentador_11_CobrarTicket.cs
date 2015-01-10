using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using FrontOffice.Presentacion.Contratos.Estacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FrontOffice.Presentacion.Presentadores.ConfiguracionEstacionamiento
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


        public void SeleccionCombox()
        {

            if (_vista.Perdido.SelectedItem.Text.Equals("NO"))
            {
                _vista.LabelTicket.Visible = true;
                _vista.Ticket.Visible = true;
                _vista.Placa.Visible = false;
                _vista.LabelPlaca.Visible = false;
            }
            else
                if (_vista.Perdido.SelectedItem.Text.Equals("SI"))
                {
                    _vista.Placa.Visible = true;
                    _vista.LabelPlaca.Visible = true;
                    _vista.LabelTicket.Visible = false;
                    _vista.Ticket.Visible = false;


                }
                else 
                {
                    _vista.LabelTicket.Visible = false;
                    _vista.Ticket.Visible = false;
                    _vista.Placa.Visible = false;
                    _vista.LabelPlaca.Visible = false;
                }
        }
    }
    
}