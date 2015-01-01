using FrontOffice.Presentacion.Contratos;
using FrontOffice.Presentacion.Contratos.Reservas;
using FrontOffice.Presentacion.Presentadores.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservaServicio : System.Web.UI.Page,IContratoReservaServicio
    {

        PresentadorReservaServicio _presentador;
        
        public web_07_reservaServicio()
        {
            _presentador = new PresentadorReservaServicio(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.cargarDropDownListServicioReservaServicio();

            /*_listaServicios = FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ModificarReservaServicio.
                  ConsultarServicios();

            foreach (DataRow row in _listaServicios.Rows)
            {
                DropDownServicio.Items.Add(row["Servicio"].ToString());

            }*/

        }

        protected void botonCancelar_Click1(object sender, EventArgs e)
        {
            _presentador.presionarBotonCancelar();

            Response.Redirect("web_07_consultaReservaServicio.aspx");
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.presionarBotonAceptar();

            /*MensajeError.Visible = false;
            MensajeExito.Visible = false;*/

            //_presentador.visibilidadMensajeError(false);
            //_presentador.visibilidadMensajeExito(false);

            //_horarioCorrecto = _presentador.calcularHorarioServicio();

            //_fechaIngresada = Convert.ToDateTime(Convert.ToDateTime(tb_fecha.Text).ToString("d"));
            //_fechaActual = Convert.ToDateTime(DateTime.Now.ToString("d"));

            //if (_fechaIngresada >= _fechaActual)
            //{
            //    if (_horarioCorrecto >= 1)
            //    {
            //        _cantidadServiciosDisponible = FrontOffice.LogicaNegocio.Reservas.
            //                                 LogicaNegocio_13_ReservaServicio.
            //                                 ConsultarCantidadServicios(DropDownServicio.Text,
            //                                 tb_fecha.Text + " " + Convert.ToDateTime(tb_hora_i.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
            //                                 tb_fecha.Text + " " + Convert.ToDateTime(dd_hora_f.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));


            //        _cantidad = Convert.ToInt32(tb_cantidad.Text);

            //        if (_cantidad > _cantidadServiciosDisponible)
            //        {
            //            MensajeError.Text = "La Cantidad de Items Solicitado es Mayor a la Cantidad Disponible";
            //            MensajeError.Visible = true;

            //        }
            //        else
            //        {
            //            FrontOffice.LogicaNegocio.Reservas.
            //                                LogicaNegocio_13_ReservaServicio.
            //                                InsertarReservaServicio("marianacarol@gmail.com", "En Espera", DropDownServicio.Text,
            //                                                         tb_fecha.Text + " " + Convert.ToDateTime(tb_hora_i.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
            //                                                         tb_fecha.Text + " " + Convert.ToDateTime(dd_hora_f.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture), tb_cantidad.Text);

            //            MensajeExito.Text = "La Reserva se ha realizado Exitosamente";
            //            MensajeExito.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        MensajeError.Text = "Dicho Servicio No Se Encuentra Abierto en el Horario Seleccionado";
            //        MensajeError.Visible = true;

            //    }
            //}
            //else
            //{
            //    MensajeError.Text = "La Fecha de Reserva No Puede Ser Menor a la Actual";
            //    MensajeError.Visible = true;
            //}

        }

        public DropDownList _nombreServicio
        {
            get { return DropDownServicio; }
            set { DropDownServicio = value; }
        }

        public TextBox _cantidadServicio
        {
            get { return tb_cantidad; }
            set { tb_cantidad = value; }
        }

        public TextBox _horaInicio
        {
            get { return tb_hora_i; }
            set { tb_hora_i = value; }
        }

        public TextBox _horaFin
        {
            get { return dd_hora_f; }
            set { dd_hora_f = value; }
        }

        public TextBox _fecha
        {
            get { return tb_fecha; }
            set { tb_fecha = value; }
        }

        public Button _aceptar
        {
            get { return botonAceptar; }
            set { botonAceptar = value; }
        }

        public Button _cancelar
        {
            get { return botonCancelar; }
            set { botonCancelar = value; }
        }

        public Label LabelMensajeExito
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return MensajeError; }
            set { MensajeError = value; }
        }
    }
}