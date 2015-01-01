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
    public partial class web_5_GenerarTicket : System.Web.UI.Page , IContrato_11_GenerarTicket
    {
        #region Presentador
        private Presentador_11_GenerarTicket _presentador;
        #endregion 

        #region Contrato

        public TextBox Placa 
        {
            get { return _textBoxPlaca; }

            set { _textBoxPlaca = value; }
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

        public Button Aceptar
        {
            get { return BotonGenerarTicket; }
        }

        #endregion

        #region Constructor

        public web_5_GenerarTicket() { 
        
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
           

        }


        


      

     

      



    }
}