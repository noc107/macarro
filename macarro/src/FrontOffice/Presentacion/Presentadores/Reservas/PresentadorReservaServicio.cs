using FrontOffice.Presentacion.Contratos.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.Dominio;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class PresentadorReservaServicio: PresentadorGeneral
    {
        private IContratoReservaServicio _vista;
        //private LogicaNegocio_13_ReservaServicio _modelo;

        int _cantidadServiciosDisponible;
        int _cantidad;
        int _horarioCorrecto;

        DateTime _fechaIngresada;
        DateTime _fechaActual;
        DateTime _horarioInicioIngresado;
        DateTime _horarioFinIngresado;

        public HttpResponse _pageResponse;


        DataTable _listaServicios = new DataTable();

        public PresentadorReservaServicio(IContratoReservaServicio _view, HttpResponse _responseVentana)
            : base ( _view )
        {
            _vista = _view;
            _pageResponse = _responseVentana;
        }


        /*
         public void consultarReserva ( )
        {
            DataTable _dt = new DataTable ();
            _dt = _consultar.GetReservasPuesto ( _vista._idReserva );
            if ( _dt != null )
            {
                _vista._tablePuesto.DataSource = _dt;
                _vista._tablePuesto.DataBind ();
            }
            else
            {
                _dt = _consultar.GetReservasServicio ( _vista._idReserva );
                _vista._tableServicio.DataSource = _dt;
                _vista._tableServicio.DataBind ();
            }
        }
       */

        public void presionarBotonAceptar()
        {
            visibilidadMensajeError(false);
            visibilidadMensajeExito(false);

            _horarioCorrecto = calcularHorarioServicio();

            _fechaIngresada = Convert.ToDateTime(Convert.ToDateTime(_vista._fecha.Text).ToString("d"));
            _fechaActual = Convert.ToDateTime(DateTime.Now.ToString("d"));

            _horarioInicioIngresado = Convert.ToDateTime(Convert.ToDateTime(_vista._horaInicio.Text).
                                              ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));
           
            _horarioFinIngresado = Convert.ToDateTime(Convert.ToDateTime(_vista._horaFin.Text).
                                                    ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));


            if (_horarioInicioIngresado < _horarioFinIngresado)
            {
                if (_fechaIngresada >= _fechaActual)
                {
                    if (_horarioCorrecto >= 1)
                    {
                        _cantidadServiciosDisponible = calcularCantidadServicio();
                        _cantidad = Convert.ToInt32(_vista._cantidadServicio.Text);

                        if (_cantidad > _cantidadServiciosDisponible)
                        {
                            _vista.LabelMensajeError.Text = "La Cantidad de Items Solicitado es Mayor a la Cantidad Disponible";
                            visibilidadMensajeError(true);

                        }
                        else
                        {

                            insertarReserva();

                            _vista._aceptar.Enabled = false;
                            _vista._cancelar.Enabled = false;
                            _vista._nombreServicio.Enabled = false;
                            _vista._cantidadServicio.Enabled = false;
                            _vista._horaInicio.Enabled = false;
                            _vista._horaFin.Enabled = false;
                            _vista._fecha.Enabled = false;


                            _vista.LabelMensajeExito.Text = "La Reserva se ha realizado Exitosamente Será Redireccionado en unos segundos...";
                            _vista.LabelMensajeExito.Visible = true;

                            _pageResponse.AddHeader("REFRESH", "5;URL=web_07_consultaReservaServicio.aspx");

                        }
                    }
                    else
                    {
                        _vista.LabelMensajeError.Text = "Dicho Servicio No Se Encuentra Abierto en el Horario Seleccionado";
                        _vista.LabelMensajeError.Visible = true;

                    }
                }
                else
                {
                    _vista.LabelMensajeError.Text = "La Fecha de Reserva No Puede Ser Menor a la Actual";
                    _vista.LabelMensajeError.Visible = true;
                }
            }
        }

        public void presionarBotonCancelar()
        {
            visibilidadMensajeError(false);
            visibilidadMensajeExito(false);
        }


        public bool insertarReserva()
        {
            Comando<Entidad, bool> _comandoInsertarReserva;

            _comandoInsertarReserva = FabricaComando.ObtenerInsertarReservaServicio();

            Reserva _rs = (Reserva)FabricaEntidad.ObtenerReserva();

            _rs.fK__usuario = "marianacarol@gmail.com";
            _rs.fK_estado = "En Espera";
            _rs.reserva_Servicio.reservaServicio_Nombre = _vista._nombreServicio.Text;
            _rs.reserva_Servicio.reservaServicio_HoraInicio = Convert.ToDateTime(_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).
                                                                      ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));

            _rs.reserva_Servicio.reservaServicio_HoraFin = Convert.ToDateTime(_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).
                                                                   ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));

            _rs.reserva_Servicio.reservaServicio_Cantidad = Convert.ToInt32(_vista._cantidadServicio.Text);

            return _comandoInsertarReserva.Ejecutar(_rs);

        }

        public void cargarDropDownListServicioReservaServicio()
        {
            Comando<string, List<string>> _comandoConsultarServicios;
            _comandoConsultarServicios = FabricaComando.ObtenerComandoConsultarServicios();

            List<string> _listaServicios = _comandoConsultarServicios.Ejecutar(string.Empty);

            if (_listaServicios != null)
            {

                foreach (string ss in _listaServicios)
                {
                    _vista._nombreServicio.Items.Add(ss);

                }
            }
            else
            {
                _listaServicios = _comandoConsultarServicios.Ejecutar(string.Empty);

                if (_listaServicios != null)
                {

                    foreach (string ss in _listaServicios)
                    {
                        _vista._nombreServicio.Items.Add(ss);

                    }
                }
                else
                {
                    _vista.LabelMensajeError.Text = "No Hay Servicios Disponibles";
                    _vista.LabelMensajeError.Visible = true;

                }

            }
        }

        public int calcularCantidadServicio()
        {
            Comando<string[], int> _comandoServiciosDisponibles;
            _comandoServiciosDisponibles = FabricaComando.ObtenerComandoCantidadServiciosDisponibles();
            string[] _parametros = new string[3];

            _parametros[0] = _vista._nombreServicio.Text;
            _parametros[1] = _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            _parametros[2] = _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

            return _comandoServiciosDisponibles.Ejecutar(_parametros);
        }

        public int calcularHorarioServicio()
        {
            Comando<string[], int> _comandoVerificarHorarioServicio;
            _comandoVerificarHorarioServicio = FabricaComando.ObtenerComandoConsultarVerificarHorario();
            string[] _parametros = new string[3];

            _parametros[0] = _vista._nombreServicio.Text;
            _parametros[1] = Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            _parametros[2] = Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

            return _comandoVerificarHorarioServicio.Ejecutar(_parametros);
        }

        public void visibilidadMensajeExito(bool _visibilidad)
        {
            _vista.LabelMensajeExito.Visible = _visibilidad;
        }

        public void visibilidadMensajeError(bool _visibilidad)
        {
            _vista.LabelMensajeError.Visible = _visibilidad;
        }



   
    }
}