using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.Dominio.Fabrica;
using FrontOffice.LogicaNegocio;
using FrontOffice.LogicaNegocio.Comandos.Reservas;
using FrontOffice.LogicaNegocio.Fabrica;
using FrontOffice.Presentacion.Contratos.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Presentadores.Reservas
{
    public class PresentadorModificarReservaServicio: PresentadorGeneral
    {
        private IContratoModificarReservaServicio _vista;
       // private LogicaNegocio_13_ModificarReservaServicio _modelo;

        string _reservaID = "";
        string _servicio = "";

        int _cantidad;
        int _cantidadReserva;
        int _cantidadServiciosDisponible;
        int _horarioCorrecto;

        public HttpResponse _pageResponse;

        List<string> _listaServicios = new List<string>();
        DataTable _reservaAModificar = new DataTable();

        DateTime _fechaIngresada;
        DateTime _fechaActual;
        DateTime _horarioInicioIngresado;
        DateTime _horarioFinIngresado;


        public PresentadorModificarReservaServicio(IContratoModificarReservaServicio _view, HttpResponse _responseVentana)
            : base ( _view )
        {
            _vista = _view;
            _pageResponse = _responseVentana;
            //_modelo = new LogicaNegocio_13_ModificarReservaServicio();
            
        }



        public void cargarVariablesURL()
        {
            _reservaID = _vista.reservaID;
            _cantidadReserva = _vista.cantidadReserva;
            _servicio = _vista.servicio;
        }

        public void cargarPaginaModificarReservaServicio()
        {
            cargarVariablesURL();

            Comando<int, Entidad> _comandoConsultarReservaXID;
            _comandoConsultarReservaXID = FabricaComando.ObtenerReservaServicioXID();

            Comando<string, List<string>> _comandoConsultarServicios;
            _comandoConsultarServicios = FabricaComando.ObtenerComandoConsultarServicios();

            ReservaServicio _rs = (ReservaServicio)FabricaEntidad.ObtenerReservaServicio();


            _rs = (ReservaServicio) _comandoConsultarReservaXID.Ejecutar(Convert.ToInt32(_reservaID));

            List<string> _listaServicios = _comandoConsultarServicios.Ejecutar(string.Empty);

                if (_rs != null)
                {
                            foreach (string ss in _listaServicios)
                            {
                               _vista._nombreServicio.Items.Add(ss);

                                if (ss.CompareTo(_rs.reservaServicio_Nombre) == 0)
                                {
                                    ListItem _l = _vista._nombreServicio.Items.FindByValue(ss);
                                    _l.Selected = true;
                                }

                            }

                            _vista._cantidadServicio.Text = _rs.reservaServicio_Cantidad.ToString();     
                }
        }

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


                        if (_vista._nombreServicio.Text.CompareTo(_servicio) == 0)
                        {
                            _cantidadServiciosDisponible = _cantidadServiciosDisponible + _cantidadReserva;
                        }

                        _cantidad = Convert.ToInt32(_vista._cantidadServicio.Text);

                        if (_cantidad > _cantidadServiciosDisponible)
                        {
                            _vista.LabelMensajeError.Text = "La Cantidad de Items Solicitado es Mayor a la Cantidad Disponible";
                            visibilidadMensajeError(true);

                        }
                        else
                        {
                            ModificarReserva();


                            _vista._aceptar.Enabled = false;
                            _vista._cancelar.Enabled = false;
                            _vista._nombreServicio.Enabled = false;
                            _vista._cantidadServicio.Enabled = false;
                            _vista._horaInicio.Enabled = false;
                            _vista._horaFin.Enabled = false;
                            _vista._fecha.Enabled = false;




                            _vista.LabelMensajeExito.Text = "La Reserva se ha Modificado Exitosamente, Será Redireccionado en unos segundos...";
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
            else
            {
                _vista.LabelMensajeError.Text = "La Hora de Inicio de la Reserva debe ser PREVIA a la Hora de Fin";
                _vista.LabelMensajeError.Visible = true;

            }
        }

        public int calcularCantidadServicio()
        {
            Comando <string[], int> _comandoServiciosDisponibles;
            _comandoServiciosDisponibles = FabricaComando.ObtenerComandoCantidadServiciosDisponibles();
            string[] _parametros = new string[3];

            _parametros[0] = _vista._nombreServicio.Text;
            _parametros[1] = _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            _parametros[2] = _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
                      
            return _comandoServiciosDisponibles.Ejecutar(_parametros);
        }

        public bool ModificarReserva()
        {
            Comando<Entidad, bool> _comandoModificarReserva;
            _comandoModificarReserva = FabricaComando.ObtenerModificarReservaServicio();
            ReservaServicio _rs = (ReservaServicio) FabricaEntidad.ObtenerReservaServicio();

            _rs.reservaServicio_FK_Reserva = Convert.ToInt32( _reservaID);
            _rs.reservaServicio_Nombre = _vista._nombreServicio.Text;
            _rs.reservaServicio_HoraInicio = Convert.ToDateTime(_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));
            _rs.reservaServicio_HoraFin = Convert.ToDateTime(_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));
            _rs.reservaServicio_Cantidad = Convert.ToInt32(_vista._cantidadServicio.Text);

            CambiarStatusReserva();
            

            return _comandoModificarReserva.Ejecutar(_rs);
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

        public void CambiarStatusReserva()
        {
                    Comando<Entidad, bool> comandoModificarStatusReserva;
                    comandoModificarStatusReserva = FabricaComando.ObtenerComandoModificarStatusReserva();

                    Reserva _r = (Reserva) FabricaEntidad.ObtenerReserva();

                    _r.reserva_id = Convert.ToInt32( _reservaID);
                    _r.fK_estado = "En Espera";

                    comandoModificarStatusReserva.Ejecutar(_r);
                    
        }

    }
}