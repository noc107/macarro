using FrontOffice.Presentacion.Contratos;
using FrontOffice.Presentacion.Contratos.Reservas;
using FrontOffice.Presentacion.Presentadores.Reservas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas 
{
    public partial class web_07_consultaSombrilla : Page, IContratoConsultaSombrilla, IContratoGeneral
    {
        PresentadorConsultaSombrilla _presentador;

        public web_07_consultaSombrilla()
        {
       
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador = new PresentadorConsultaSombrilla(this, "manueljos@hotmail.com", Response);
            _presentador.databind ();
       
        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            _presentador.SetRow(e);
        }

        void editarBtn_Click(Object sender, ImageClickEventArgs e)
        {
        }

        void eliminarBtn_Click(Object sender, ImageClickEventArgs e)
        {
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
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

        public GridView _tabla
        {
            get { return GridViewUsuario; }
            set { GridViewUsuario = value; }
        }
    }
}