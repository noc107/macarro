using FrontOffice.Presentacion.Contratos.Reservas;
using FrontOffice.LogicaNegocio.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

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


        DataTable _listaServicios = new DataTable();

        public PresentadorReservaServicio(IContratoReservaServicio _view)
            : base ( _view )
        {
            _vista = _view;
            //_modelo = new LogicaNegocio_13_ReservaServicio();
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

            if (_fechaIngresada >= _fechaActual)
            {
                if (_horarioCorrecto >= 1)
                {
                    _cantidadServiciosDisponible = 
                                             //_modelo.
                                             //ConsultarCantidadServicios(_vista._nombreServicio.Text,
                                             //_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
                                             //_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));


                    _cantidad = Convert.ToInt32(_vista._cantidadServicio.Text);

                    if (_cantidad > _cantidadServiciosDisponible)
                    {
                        _vista.LabelMensajeError.Text = "La Cantidad de Items Solicitado es Mayor a la Cantidad Disponible";
                        visibilidadMensajeError(true);

                    }
                    else
                    {
                        //_modelo. InsertarReservaServicio("marianacarol@gmail.com", "En Espera", _vista._nombreServicio.Text,
                                                                     //_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaInicio.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
                                                                     //_vista._fecha.Text + " " + Convert.ToDateTime(_vista._horaFin.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture), _vista._cantidadServicio.Text);

                        _vista.LabelMensajeExito .Text = "La Reserva se ha realizado Exitosamente";
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

        public void presionarBotonCancelar()
        {
            visibilidadMensajeError(false);
            visibilidadMensajeExito(false);
        }

        public void cargarDropDownListServicioReservaServicio()
        {
              //_listaServicios = _modelo.ConsultarServicios();

            foreach (DataRow row in _listaServicios.Rows)
            {
                _vista._nombreServicio.Items.Add(row["Servicio"].ToString());

            }
        }

        public int calcularHorarioServicio()
        {
            return 0;//_modelo.ConsultarHorarioServicios(_vista._nombreServicio.Text, 
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