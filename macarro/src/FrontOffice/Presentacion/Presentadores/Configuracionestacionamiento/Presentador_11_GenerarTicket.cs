using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Dominio;
using FrontOffice.LogicaNegocio;
using FrontOffice.Dominio.Entidades;

namespace FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento
{
    public class Presentador_11_GenerarTicket : PresentadorGeneral
    {
        private IContrato_11_GenerarTicket _vista;
        private Estacionamiento est;
        private Ticket tic;

        public Presentador_11_GenerarTicket(IContrato_11_GenerarTicket vistaEstacionamiento)
            : base(vistaEstacionamiento) 
        {

            _vista = vistaEstacionamiento;
        }

        public void EventoClickAceptar( string Placa)
        {

            Boolean respuesta = false; 
           bool resp=false;
            _vista.LabelMensajeExito.Visible = false;
            try
            {
                resp = VerificarPlaca(Placa);
                if (!resp)
                {
                    try
                    {
                        Dominio.Entidad _ticket;

                        Comando<Entidad, Boolean> comandoGenerarTicket;
                        _ticket = FabricaEntidad.ObtenerTicket(Placa);
                        comandoGenerarTicket = FabricaComando.ObtenerComandoGenerarTicket();

                        respuesta = comandoGenerarTicket.Ejecutar(_ticket);

                        if (respuesta)
                        {

                            _vista.LabelMensajeExito.Text = RecursoPresentadorEstacionamiento.TicketGenereado;
                            _vista.LabelMensajeExito.Visible = true;

                        }


                        if (!respuesta)
                        {
                            _vista.LabelMensajeError.Text = RecursoPresentadorEstacionamiento.CarroEnElEstacionamienot;
                            _vista.LabelMensajeError.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
            
            public bool PageLoad()
            
            {
                bool respuesta = false;
                try
                {
                    Dominio.Entidad _estacionamiento;

                    Comando<int, Entidad> comandoConsultarEstacionamiento;
                    _estacionamiento = FabricaEntidad.ObtenerEstacionamiento();
                    comandoConsultarEstacionamiento = FabricaComando.ObtenerComandoConsultarEstacionamiento();

                    _estacionamiento = comandoConsultarEstacionamiento.Ejecutar(1);

                    if (_estacionamiento != null)
                    {
                        est = (Estacionamiento)_estacionamiento;
                        respuesta=LlenarDatos(est);
                        return respuesta;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return respuesta;
            }

                public bool LlenarDatos(Estacionamiento est)
                {
                    if (est != null)
                    {
                        _vista.Estacionamiento.Text = est.Nombre.ToString();
                        if (est.Disponible == 0 ) 
                        {
                            
                            _vista.LabelMensajeError.Text = "No existen puestos disponibles en el estacionamiento";
                            _vista.LabelMensajeError.Visible = true;
                            _vista.Placa.ReadOnly = true;
                            _vista.LabelMensajeExito.Visible = false;
                               return true;
                        }

                    }
                    return false;
                }
          
        public bool VerificarPlaca(string placa)
        {
           bool respuesta = false;
                try
                {
                    Dominio.Entidad _ticket;

                    Comando<string, Entidad> comandoConsultarTicketPlaca;
                    _ticket = FabricaEntidad.ObtenerTicket();
                    comandoConsultarTicketPlaca = FabricaComando.ObtenerComandoConsultarTicketPlaca();

                    _ticket = comandoConsultarTicketPlaca.Ejecutar(placa);

                    if (_ticket != null)
                    {
                        
                            respuesta = true;
                            return respuesta;
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return respuesta;
            }

        public void EsconderMensajes()
        {
            _vista.LabelMensajeError.Visible = false;
            _vista.LabelMensajeExito.Visible = false;
        }
     

      }
 }


    
