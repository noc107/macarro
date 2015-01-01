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
    public partial class web_07_listaReservas : Page, IContrato_07_listaReserva
    {


        string _id;

        private presentador_07_listaReservas _presentador;

        public web_07_listaReservas ()
        {
            _presentador = new presentador_07_listaReservas ( this );

        }
        protected void Page_Load ( object sender, EventArgs e )
        {
            //_idReserva = Request.QueryString["Reserva"];

            //ConfigurarReserva _consulta;

            //_consulta = new ConfigurarReserva();
            //_dt = _consulta.ListarReservas(_idReserva);


            _presentador.Cargar_Reservas ();



        }

        public GridView _table
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



        protected void grid_PageIndexChanging ( object sender, GridViewPageEventArgs e )
        {
            _presentador.grid_PageIndexChanging ( sender, e );
        }

        protected void grid_RowCommand ( object sender, GridViewCommandEventArgs e )
        {
            _presentador.grid_RowCommand ( sender, e );

        }

        protected void grid_RowEditing ( object sender, GridViewEditEventArgs e )
        {
            Response.Redirect ( "web_07_confirmacionReserva.aspx?Reserva=" + this._id );
        }
    }
}