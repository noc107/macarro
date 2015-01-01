using FrontOffice.Presentacion.Contratos.Estacionamiento;
using FrontOffice.Presentacion.Presentadores.Estacionamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Estacionamiento
{
    public partial class web_11_detalleTicket : System.Web.UI.Page , IContrato_11_detalleTicket
    {

        #region Presentador
        private Presentador_11_detalleTicket _presentador;
        #endregion 

        #region Contrato

        string IContrato_11_detalleTicket.LabelEntrada 
        {
            get { return _Entrada.Text; }
            set { _Entrada.Text = value; }
        
        }

         string IContrato_11_detalleTicket.LabelSalida 
        {
            get { return _salida.Text; }
            set { _salida.Text = value; }
        }

         string IContrato_11_detalleTicket.LabelPlaca
         {
             get { return _placa.Text; }
             set { _placa.Text = value; }
         }


         string IContrato_11_detalleTicket.LabelPerdido
         {
             get { return _perdido.Text; }
             set { _perdido.Text = value; }
         }

         string IContrato_11_detalleTicket.LabelMonto
         {
             get { return _monto.Text; }
             set { _monto.Text = value; }
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

        public web_11_detalleTicket() 
        {
            _presentador = new Presentador_11_detalleTicket(this);
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BotonVolver_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickVolver();
        }

    }
}