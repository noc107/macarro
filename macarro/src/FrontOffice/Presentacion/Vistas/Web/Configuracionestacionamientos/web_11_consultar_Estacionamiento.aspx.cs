
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Contratos.Configuracionestacionamiento;
using FrontOffice.Presentacion.Presentadores.Configuracionestacionamiento;
using FrontOffice.Dominio.Entidades;

namespace FrontOffice.Presentacion.Vistas.Web.Configuracionestacionamientos
{
    public partial class web_11_consultar_Estacionamiento : System.Web.UI.Page , IContrato_11_consultar_Estacionamiento
    {

            #region Presentador
            private Presentador_11_consultar_Estacionamiento _presentador;
            #endregion 

            #region Contrato

       public Label LabelNombreEstacionamienot
        {
          get {return _nombreEstacionamiento;}
          set { _nombreEstacionamiento = value;}  

        }

       public Label LabelCapacidad
        {
          get {return _capacidad;}
          set { _capacidad = value;}  

        }

        public Label LabelTarifa
        {
          get {return _tarifa;}
          set { _tarifa = value;}  

        }

          public Label LabelEstado
        {
          get {return _estado;}
          set { _estado = value;}  

        }


           public Label LabelPerdido
        {
          get {return _tarifaPerdido;}
          set { _tarifaPerdido = value;}  

        }

         public Label LabelDisponible
        {
          get {return _disponible;}
          set { _disponible = value;}  

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
            
            ConsultarEstacionamiento();
            
        }

        public void ConsultarEstacionamiento() 
        {
           
            _presentador.ConsultarEstacionamiento();
             
        }

        protected void BotonVolver_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickVolver();
        }
    }
}