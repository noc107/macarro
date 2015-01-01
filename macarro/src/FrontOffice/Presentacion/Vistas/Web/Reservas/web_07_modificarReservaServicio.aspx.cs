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
    public partial class web_07_modificarReserva : System.Web.UI.Page,IContratoModificarReservaServicio
    {
        string _reservaID = "";
        string _servicio = "";
        int _cantidadReserva;

        PresentadorModificarReservaServicio _presentador;

        public web_07_modificarReserva()
        {
            _presentador = new PresentadorModificarReservaServicio(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            _reservaID = Request.QueryString["r"].ToString();
            _cantidadReserva = Convert.ToInt32(Request.QueryString["c"]);
            _servicio = Request.QueryString["s"].ToString();

            //_reservaAModificar = FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ModificarReservaServicio.
            //                     ConsultarReservaPorIdBD(_reservaID);
            //_listaServicios = FrontOffice.LogicaNegocio.Reservas.LogicaNegocio_13_ModificarReservaServicio.
            //                  ConsultarServicios();

            _presentador.cargarVariablesURL();
            
            
            if (!IsPostBack)
            {
                _presentador.cargarPaginaModificarReservaServicio();
               
                //if (_reservaAModificar.Rows.Count > 0)
                //{
                //    foreach (DataRow row in _reservaAModificar.Rows)
                //    {
                //        if (_reservaAModificar.Rows.Count > 0)
                //        {
                //            foreach (DataRow row2 in _listaServicios.Rows)
                //            {
                //                DropDownServicio.Items.Add(row2["Servicio"].ToString());

                //                if (row2["Servicio"].ToString().CompareTo(row["Nombre"].ToString()) == 0)
                //                {
                //                    ListItem _l = DropDownServicio.Items.FindByValue(row2["Servicio"].ToString());
                //                    _l.Selected = true;
                //                }

                //            }
                //        }

                //        tb_cantidad.Text = row["Cantidad"].ToString();

                //        DateTime _horaInicio = Convert.ToDateTime(row["Inicio"].ToString());
                //        tb_hora_i.Text = _horaInicio.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                //        DateTime _horaFin = Convert.ToDateTime(row["Fin"].ToString());
                //        dd_hora_f.Text = _horaFin.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                //    }
                //}
            }
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.presionarBotonAceptar();

            //MensajeError.Visible = false;
            //MensajeExito.Visible = false;
            //int _horarioCorrecto = FrontOffice.LogicaNegocio.Reservas.
            //                         LogicaNegocio_13_ModificarReservaServicio.
            //                         ConsultarHorarioServicios(DropDownServicio.Text, tb_hora_i.Text, dd_hora_f.Text);

            //DateTime _fechaIngresada = Convert.ToDateTime(Convert.ToDateTime(tb_fecha.Text).ToString("d"));
            //DateTime _fechaActual = Convert.ToDateTime(DateTime.Now.ToString("d"));

            //if (_fechaIngresada >= _fechaActual)
            //{
            //    if (_horarioCorrecto >= 1)
            //    {
            //        _cantidadServiciosDisponible = FrontOffice.LogicaNegocio.Reservas.
            //                                 LogicaNegocio_13_ModificarReservaServicio.
            //                                 ConsultarCantidadServicios(DropDownServicio.Text,
            //                                 tb_fecha.Text + " " + Convert.ToDateTime(tb_hora_i.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
            //                                 tb_fecha.Text + " " + Convert.ToDateTime(dd_hora_f.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture));


            //        if (DropDownServicio.Text.CompareTo(_servicio) == 0)
            //        {
            //            _cantidadServiciosDisponible = _cantidadServiciosDisponible + _cantidadReserva;
            //        }

            //        _cantidad = Convert.ToInt32(tb_cantidad.Text);

            //        if (_cantidad > _cantidadServiciosDisponible)
            //        {
            //            MensajeError.Text = "La Cantidad de Items Solicitado es Mayor a la Cantidad Disponible";
            //            MensajeError.Visible = true;

            //        }
            //        else
            //        {
            //            FrontOffice.LogicaNegocio.Reservas.
            //            LogicaNegocio_13_ModificarReservaServicio.
            //            ModificarReserva(_reservaID,
            //                             Convert.ToDateTime(tb_hora_i.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
            //                             Convert.ToDateTime(dd_hora_f.Text).ToString("hh:mm:ss tt", CultureInfo.InvariantCulture),
            //                             DropDownServicio.Text,
            //                             tb_cantidad.Text,
            //                             tb_fecha.Text);

            //            MensajeExito.Text = "La Reserva se ha Modificado Exitosamente";
            //            MensajeExito.Visible = true;

            //            Response.Redirect("web_07_consultaReservaServicio.aspx");
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

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_consultaReservaServicio.aspx");
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
            set { dd_hora_f= value; }
        }

        public TextBox _fecha
        {
            get { return tb_fecha; }
            set { tb_fecha= value; }
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

        public string reservaID
        {
            get { return _reservaID; }
            set { _reservaID = value; }
        }

        public int cantidadReserva
        {
            get { return _cantidadReserva; }
            set { _cantidadReserva = value; }
        }
        public string servicio
        {
            get { return _servicio; }
            set { _servicio = value; }
        }


    }
}