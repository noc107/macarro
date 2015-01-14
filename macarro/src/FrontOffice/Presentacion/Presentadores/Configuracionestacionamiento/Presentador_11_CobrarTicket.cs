using FrontOffice.Dominio;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento
{
    public class Presentador_11_CobrarTicket : PresentadorGeneral
    {

        private IContrato_11_CobrarTicket _vista;

        public Presentador_11_CobrarTicket(IContrato_11_CobrarTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        
        }

        public void EventoClickCobrar(string Ticket)
        {
            Boolean respuesta = false;

            if (Ticket.Equals(RecursoPresentadorEstacionamiento.TicketPerdido))
            {
                try
                {


                    Dominio.Entidad _ticket;
                    Comando<Entidad, Boolean> comandoCobrarTicket;
                    _ticket = FabricaEntidad.ObtenerTicket(_vista.Placa.Text.ToString(), 21);
                    comandoCobrarTicket = FabricaComando.ObtenerComandoCobrarTicketPorPlaca();

                    respuesta = comandoCobrarTicket.Ejecutar(_ticket);

                    if (respuesta)
                    {
                        _vista.LabelMensajeExito.Text = RecursoPresentadorEstacionamiento.MensajeExitoCobrarTicket;
                        _vista.LabelMensajeExito.Visible = true;
                        _vista.Placa.Visible = false;
                        _vista.Placa.Text = RecursoPresentadorEstacionamiento.Vacio;
                        _vista.LabelPlaca.Visible = false;
                        _vista.Perdido.SelectedValue = RecursoPresentadorEstacionamiento.Combox;

                    }
                    if (!respuesta)
                    {
                        _vista.LabelMensajeError.Text = RecursoPresentadorEstacionamiento.MensajeErrorCobrarTicket;
                        _vista.LabelMensajeError.Visible = true;
                        _vista.Placa.Visible = false;
                        _vista.Placa.Text = RecursoPresentadorEstacionamiento.Vacio;
                        _vista.LabelPlaca.Visible = false;
                        _vista.Perdido.SelectedValue = RecursoPresentadorEstacionamiento.Combox;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {


                try
                {
                    Dominio.Entidad _ticket;
                    Comando<Entidad, Boolean> comandoCobrarTicketPorNumeroTicket;
                    _ticket = FabricaEntidad.ObtenerTicket(_vista.Ticket.Text.ToString());
                    comandoCobrarTicketPorNumeroTicket = FabricaComando.ObtenerComandoCobrarTicketPorNumero();

                    respuesta = comandoCobrarTicketPorNumeroTicket.Ejecutar(_ticket);

                    if (respuesta)
                    {
                        _vista.LabelMensajeExito.Text = RecursoPresentadorEstacionamiento.MensajeExitoCobrarTicket;
                        _vista.LabelMensajeExito.Visible = true;
                        _vista.Ticket.Visible = false;
                        _vista.Ticket.Text = RecursoPresentadorEstacionamiento.Vacio;
                        _vista.LabelTicket.Visible = false;
                        _vista.Perdido.SelectedValue = RecursoPresentadorEstacionamiento.Combox;

                    }
                    if (!respuesta)
                    {
                        _vista.LabelMensajeError.Text = RecursoPresentadorEstacionamiento.MensajeErrorCobrarTicket;
                        _vista.LabelMensajeError.Visible = true;
                        _vista.Ticket.Visible = false;
                        _vista.Ticket.Text = RecursoPresentadorEstacionamiento.Vacio;
                        _vista.LabelTicket.Visible = false;
                        _vista.Perdido.SelectedValue = RecursoPresentadorEstacionamiento.Combox;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            
            }
            
        }


        public void SeleccionCombox()
        {

            if (_vista.Perdido.SelectedItem.Text.Equals(RecursoPresentadorEstacionamiento.TicketNoPerdido))
            {
                _vista.LabelTicket.Visible = true;
                _vista.Ticket.Visible = true;
                _vista.Placa.Visible = false;
                _vista.LabelPlaca.Visible = false;
                _vista.Placa.Text = RecursoPresentadorEstacionamiento.Ticket;
                _vista.Ticket.Text = RecursoPresentadorEstacionamiento.Vacio;
                _vista.LabelMensajeExito.Visible = false;
                _vista.LabelMensajeError.Visible = false;
                
                
            }
            else
                if (_vista.Perdido.SelectedItem.Text.Equals(RecursoPresentadorEstacionamiento.TicketPerdido))
                {
                    _vista.Placa.Visible = true;
                    _vista.LabelPlaca.Visible = true;
                    _vista.LabelTicket.Visible = false;
                    _vista.Ticket.Visible = false;
                    _vista.Ticket.Text = RecursoPresentadorEstacionamiento.Ticket;
                    _vista.Placa.Text = RecursoPresentadorEstacionamiento.Vacio;
                    _vista.LabelMensajeExito.Visible = false;
                    _vista.LabelMensajeError.Visible = false;
                    


                }
                else 
                {
                    _vista.LabelTicket.Visible = false;
                    _vista.Ticket.Visible = false;
                    _vista.Placa.Visible = false;
                    _vista.LabelPlaca.Visible = false;
                    _vista.Ticket.Text = RecursoPresentadorEstacionamiento.Vacio;
                    _vista.Placa.Text = RecursoPresentadorEstacionamiento.Vacio;
                    _vista.LabelMensajeExito.Visible = false;
                    _vista.LabelMensajeError.Visible = false;
                }
        }
    }
    
}