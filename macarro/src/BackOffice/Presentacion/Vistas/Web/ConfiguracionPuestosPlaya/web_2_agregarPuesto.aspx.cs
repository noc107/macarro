using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_agregarPuesto : System.Web.UI.Page , IContrato_2_agregarPuesto
    {

        #region Presentador
        private Presentador_2_agregrarPuesto _presentador;
        #endregion

        #region Implementación de Contrato

        public RadioButtonList RadioOpciones
        {
	        get { return formularioAgregarPuesto.ListaDeOpciones; }
        }

        public TextBox CampoFila
        {
	        get { return formularioAgregarPuesto.Fila; }
        }

        public TextBox CampoColumna
        {
	        get { return formularioAgregarPuesto.Columna; }
        }

        public TextBox CampoDescripcion
        {
	        get { return formularioAgregarPuesto.Descripcion; }
        }

        public TextBox CampoPrecio
        {
	        get { return formularioAgregarPuesto.Precio; }
        }

        public Button BtnAceptar
        {
	        get { return botonAceptar; }
        }

        public Label LabelMensajeExito 
        {
            get { return mensajeDeEstado.mensajeExito;}
            set { mensajeDeEstado.mensajeExito = value;}
        }

        public Label LabelMensajeError
        {
            get { return mensajeDeEstado.mensajeError; }
            set { mensajeDeEstado.mensajeError = value; }
        }
        #endregion

        #region constructor
        public web_2_agregarPuesto()
        {
            _presentador = new Presentador_2_agregrarPuesto(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar();
        }

        #region CodigoAnterior
        /*
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    this.mensajeDeEstado.OcultarMensajeDeExito();
        //    this.mensajeDeEstado.OcultarMensajeDeError();
        //    try
        //    {
        //        if (new LogicaPuesto().AgregarPuestoEnPlaya(this.formularioAgregarPuesto.Tipo(), this.formularioAgregarPuesto.Fila(),
        //           this.formularioAgregarPuesto.Columna(), this.formularioAgregarPuesto.Descripcion(), this.formularioAgregarPuesto.Precio()))
        //        {
        //            this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoAgregarPuesto);
        //        }
        //        else
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //        this.botonAceptar.Enabled = false;
        //    }
        //    catch (ExceptionDatos ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeDatos);
        //    }
        //    catch (ExceptionLogica ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepciones.mensajeDeLogica);
        //    }
        //    catch (Exception)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepciones.mensajeFalso);
        //    }
        }
        */
        #endregion
    
    }
}