using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento;


namespace FrontOffice.Presentacion.Vistas.Web.Configuracionestacionamiento
{
    public partial class web_11_GenerarTicket : System.Web.UI.Page , IContrato_11_GenerarTicket
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

        public TextBox Estacionamiento
        {
            get { return _textboxEstacionamiento; }

            set { _textboxEstacionamiento = value; }
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

        

        #endregion

        #region Constructor

        public web_11_GenerarTicket() {


            _presentador = new Presentador_11_GenerarTicket(this);
        
        
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
           

        }

        protected void BotonGenerarTicket_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar(_textBoxPlaca.Text);
        }


        


      

     

      



    }
}