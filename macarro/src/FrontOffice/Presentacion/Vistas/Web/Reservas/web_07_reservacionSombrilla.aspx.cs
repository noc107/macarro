using FrontOffice.Presentacion.Contratos;
using FrontOffice.Presentacion.Contratos.Reservas;
using FrontOffice.Presentacion.Presentadores.Reservas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservacionSombrilla : Page, IContratoReservacionSombrilla, IContratoGeneral
    {
        //float _total = 0f;
        //ImageButton _puesto;
        //TableRow tRow;
        //TableCell tCell;
        //ListaPuesto _listaOcupados;
        //List<Puesto> _lista = new List<Puesto>();
        //ListaPuesto _listaReserva = new ListaPuesto();
        //LogicaReservaSombrilla _log = new LogicaReservaSombrilla();

        //// numero total de filas
        //int rowCnt;
        //// fila actual
        //int rowCtr;
        //// numero total de celdas por fila(columnas)
        //int cellCtr;
        //// celda actual
        //int cellCnt;
        PresentadorReservacionSombrilla _presentador;
        public web_07_reservacionSombrilla()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int _tipo = int.Parse(Request.QueryString["tipo"]);
            int reserva = 0;
            if (_tipo == 1)
                reserva = int.Parse(Request.QueryString["reserva"]);
            DateTime _fecha = DateTime.Parse(Request.QueryString["fecha"]);
            _presentador = new PresentadorReservacionSombrilla(this, _fecha, 1, "manueljos@hotmail.com", _tipo, reserva, ViewState, IsPostBack);
            _presentador.LoadPage();
        }
        private void llenarMatriz()
        {
        }

        protected void puestoBtn_Click(object sender, EventArgs e)
        {
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.OnClickAceptar();
        }
        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../inicio.aspx");
        }

        public Table _tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        public Label _monto
        {
            get { return l_total; }
            set { l_total = value; }
        }
        public Label _fechaReserva
        {
            get { return l_fecha; }
            set { l_fecha = value; }
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