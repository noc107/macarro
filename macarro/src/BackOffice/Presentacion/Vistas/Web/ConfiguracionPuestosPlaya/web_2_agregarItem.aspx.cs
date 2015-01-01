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
    public partial class web_2_agregarItem : System.Web.UI.Page , IContrato_2_agregarItem
    {
        
        #region Presentador
        private Presentador_2_agregarItem _presentador;
        #endregion

        #region Implementación de Contrato

        public DropDownList DropTipoItem
        {
            get { return formularioAgregarItem.TipoDeItem; }
        }

        public TextBox CampoPrecio
        {
            get { return formularioAgregarItem.Precio; }
        }

        public TextBox CampoCantidad
        {
            get { return formularioAgregarItem.CantidadItem; }
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
        public web_2_agregarItem()
        {
            _presentador = new Presentador_2_agregarItem(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// evento de la ventana encargado de subir a la base de datos la informacion del nuevo inventario de la playa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar();
        }


        #region CodigoAnterior
        /*
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// evento de la ventana encargado de subir a la base de datos la informacion del nuevo inventario de la playa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    this.mensajeDeEstado.OcultarMensajeDeExito();
        //    this.mensajeDeEstado.OcultarMensajeDeError();
        //    try
        //    {
        //        if ( new LogicaInventario().AgregarInventarioNuevoAplaya(this.formularioAgregarItem.Tipo(),
        //           this.formularioAgregarItem.Precio(), this.formularioAgregarItem.Cantidad() ) )                   
        //        {
        //            this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoAgregarInventario);
        //        }
        //        else
        //            this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesInventario.mensajeFalso);
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