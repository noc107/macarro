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
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador = new PresentadorReservaServicio(this,Response);
            _presentador.cargarDropDownListServicioReservaServicio();

            _aceptar.Enabled = true;
            _cancelar.Enabled = true;
            _nombreServicio.Enabled = true;
            _cantidadServicio.Enabled = true;
            _horaInicio.Enabled = true;
            _horaFin.Enabled = true;
            _fecha.Enabled = true;

        }

        protected void botonCancelar_Click1(object sender, EventArgs e)
        {
            _presentador.presionarBotonCancelar();

            Response.Redirect("web_07_consultaReservaServicio.aspx");
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.presionarBotonAceptar();
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