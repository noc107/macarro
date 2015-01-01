using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Contratos.Estacionamiento;
using FrontOffice.Presentacion.Presentadores.Estacionamiento;


namespace FrontOffice.Presentacion.Vistas.Web.Estacionamiento
{
    public partial class web_11_CobrarTicket : System.Web.UI.Page , IContrato_11_CobrarTicket
    {
        #region Presentador
        private Presentador_11_CobrarTicket _presentador;
        #endregion

        #region Contrato


        public TextBox Ticket 
        {
            get { return textboxNumeroTicket; }
            set { textboxNumeroTicket = value; }
        }


        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }


        public DropDownList Perdido
        {
            get { return DropDown_estado; }
            set { DropDown_estado = value; }
        }

        public Button Cobrar 
        {
            get { return BotonPagarEstacionamiento; }
        
        }
        #endregion

        #region Constructor
        public web_11_CobrarTicket() 
        {
            _presentador = new Presentador_11_CobrarTicket(this);
        }

        #endregion 
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BotonPagarEstacionamiento_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickCobrar();
        }

    }
}