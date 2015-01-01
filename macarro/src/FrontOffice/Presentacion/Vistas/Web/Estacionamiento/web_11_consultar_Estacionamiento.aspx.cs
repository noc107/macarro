
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
    public partial class web_11_consultar_Estacionamiento : System.Web.UI.Page , IContrato_11_consultar_Estacionamiento
    {

            #region Presentador
            private Presentador_11_consultar_Estacionamiento _presentador;
            #endregion 

            #region Contrato

        string IContrato_11_consultar_Estacionamiento.LabelNombreEstacionamienot
        {
          get {return _nombreEstacionamiento.Text;}
          set { _nombreEstacionamiento.Text = value;}  

        }

        string IContrato_11_consultar_Estacionamiento.LabelCapacidad
        {
          get {return _capacidad.Text;}
          set { _capacidad.Text = value;}  

        }

         string IContrato_11_consultar_Estacionamiento.LabelTarifa
        {
          get {return _tarifa.Text;}
          set { _tarifa.Text = value;}  

        }

          string IContrato_11_consultar_Estacionamiento.LabelEstado
        {
          get {return _estado.Text;}
          set { _estado.Text = value;}  

        }


            string IContrato_11_consultar_Estacionamiento.LabelPerdido
        {
          get {return _tarifaPerdido.Text;}
          set { _tarifaPerdido.Text = value;}  

        }

          string IContrato_11_consultar_Estacionamiento.LabelDisponible
        {
          get {return _disponible.Text;}
          set { _disponible.Text = value;}  

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

          #region constructor
        public web_11_consultar_Estacionamiento()
        {
            _presentador = new Presentador_11_consultar_Estacionamiento(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
    }
}