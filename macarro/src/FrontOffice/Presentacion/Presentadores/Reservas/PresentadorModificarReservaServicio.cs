using FrontOffice.LogicaNegocio.Reservas;
using FrontOffice.Presentacion.Contratos.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
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

        DataTable _listaServicios = new DataTable();
        DataTable _reservaAModificar = new DataTable();

        DateTime _fechaIngresada;
        DateTime _fechaActual;


        public PresentadorModificarReservaServicio(IContratoModificarReservaServicio _view)
            : base ( _view )
        {
            _vista = _view;
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

           // _reservaAModificar = _modelo.ConsultarReservaPorIdBD(_reservaID);
            //_listaServicios = _modelo.ConsultarServicios();
                if (_reservaAModificar.Rows.Count > 0)
                {
                    foreach (DataRow row in _reservaAModificar.Rows)
                    {
                        if (_reservaAModificar.Rows.Count > 0)
                        {
                            foreach (DataRow row2 in _listaServicios.Rows)
                            {
                               _vista._nombreServicio.Items.Add(row2["Servicio"].ToString());

                                if (row2["Servicio"].ToString().CompareTo(row["Nombre"].ToString()) == 0)
                                {
                                    ListItem _l = _vista._nombreServicio.Items.FindByValue(row2["Servicio"].ToString());
                                    _l.Selected = true;
                                }

                            }
                        }

                        _vista._cantidadServicio.Text = row["Cantidad"].ToString();

                        DateTime _horaInicio = Convert.ToDateTime(row["Inicio"].ToString());
                        _vista._horaInicio.Text = _horaInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                        DateTime _horaFin = Convert.ToDateTime(row["Fin"].ToString());
                        _vista._horaFin.Text = _horaFin.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                }
        }

        public void presionarBotonAceptar()
        {
            visibilidadMensajeError(false);
            visibilidadMensajeExito(false);

            _horarioCorrecto = calcularHorarioServicio();

            _fechaIngresada = Convert.ToDateTime(Convert.ToDateTime(_vista._fecha.Text).ToString("d"));
            _fechaActual = Convert.ToDateTime(DateTime.Now.ToString("d"));

            if (_fechaIngresada >= _fechaActual)
            {
                if (_horarioCorrecto >= 1)
                {
                    //_cantidadServiciosDisponible =
                                            // _modelo.
                                            // ConsultarCantidadServicios(_vista._nombreServicio.Text,
                                            // _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
                                            // _vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));


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
                        //_modelo.ModificarReserva(_reservaID,
                                        // Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
                                         //Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
                                        // _vista._nombreServicio.Text,
                                        // _vista._cantidadServicio.Text,
                                        // _vista._fecha.Text);

                        _vista.LabelMensajeExito.Text = "La Reserva se ha realizado Exitosamente";
                        _vista.LabelMensajeExito.Visible = true;
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

        public int calcularHorarioServicio()
        {
            return 0;// _modelo.ConsultarHorarioServicios(_vista._nombreServicio.Text,
                                    // _vista._horaInicio.Text, _vista._horaFin.Text);
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