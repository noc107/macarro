using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.ReservasSombrillasServiciosPlaya;
using BackOffice.Presentacion.Presentadores.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_confirmacionReserva : Page, IContrato_07_confirmacionReserva
    {
        DataTable _dt;
        string _id;
        string _nombreServicio;
        presentador_07_confirmacionReserva _presentador;

        public web_07_confirmacionReserva ()
        {
            _presentador = new presentador_07_confirmacionReserva ( this );
        }

        protected void Page_Load ( object sender, EventArgs e )
        {
            _idReserva = Request.QueryString [ "Reserva" ];
            //ConfigurarReserva _consulta;

            //_consulta = new ConfigurarReserva();
            //_dt = _consulta.ListarServicios(_idReserva);
            //GridView.DataSource = _dt;
            //GridView.DataBind();

            _aceptar.Click += botonAceptar_Click;
            botonCancelar.Click += botonCancelar_Click;

            if ( !IsPostBack )
            {
                _presentador.consultarReserva ();
                _presentador.consultar ();
            }
        }

        void botonCancelar_Click ( object sender, EventArgs e )
        {
            Response.Redirect ( "web_07_listaReservas.aspx" );
        }

        void botonAceptar_Click ( object sender, EventArgs e )
        {
            _presentador.actualizarEstado ();
            Response.Redirect ( "web_07_listaReservas.aspx" );
        }

        public GridView _tableServicio
        {

            get { return Tabla2; }
            set { Tabla2 = value; }

        }

        public GridView _tablePuesto
        {

            get { return Tabla; }
            set { Tabla = value; }

        }

        public string _idReserva
        {
            get { return _id; }
            set { _id = value; }
        }

        public Label LabelMensajeExito
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        public DropDownList _combo
        {
            get { return ddlConfirmar; }
            set { ddlConfirmar = value; }
        }

        public Label _estadoActual
        {
            get { return Estado_Reserva; }
            set { Estado_Reserva = value; }
        }

        public Button _aceptar
        {
            get { return botonAceptar; }
            set { botonAceptar = value; }
        }

        protected void grid_PageIndexChanging_Puesto ( object sender, GridViewPageEventArgs e )
        {
            _presentador.grid_PageIndexChanging ( sender, e );
        }

        protected void grid_RowCommand_Puesto ( object sender, GridViewCommandEventArgs e )
        {
            _presentador.grid_RowCommand (sender, e);
        }

        protected void grid_RowEditing ( object sender, GridViewEditEventArgs e )
        {
            //    GestionarReservaBD _gest = new GestionarReservaBD();
            //    string _idServicio = _gest.idServicio(_nombreServicio, Convert.ToInt32(_idReserva)); 
            //    Response.Redirect("web_07_editarReserva.aspx?Servicio=" + _idServicio + "?Reserva=" + _idReserva);
        }


    }
}