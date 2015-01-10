using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio;

namespace FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento
{
    public class Presentador_11_GenerarTicket : PresentadorGeneral
    {
        private IContrato_11_GenerarTicket _vista;

        public Presentador_11_GenerarTicket(IContrato_11_GenerarTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        }

        public void EventoClickAceptar( string Placa)
        {
            try
            {
                Dominio.Entidad _ticket;
                
                Comando<Entidad, Boolean> comandoGenerarTicket;
                _ticket = FabricaEntidad.ObtenerTicket(Placa);
                comandoGenerarTicket = FabricaComando.ObtenerComandoGenerarTicket();

                Boolean respuesta = comandoGenerarTicket.Ejecutar(_ticket);

                if (respuesta)
                {

                    _vista.LabelMensajeExito.Text = "Ticket generado con exito";
                    _vista.LabelMensajeExito.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
        }


    }
}