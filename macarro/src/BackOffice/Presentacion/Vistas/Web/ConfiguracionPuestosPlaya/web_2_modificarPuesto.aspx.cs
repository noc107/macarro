using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos.ConfiguracionPuestosPlaya;
using BackOffice.Presentacion.Presentadores.ConfiguracionPuestosPlaya;


namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionPuestosPlaya
{
    public partial class web_2_modificarPuesto : System.Web.UI.Page , IContrato_2_modificarPuesto
    {

        #region Presentador
        private Presentador_2_modificarPuesto _presentador;
        #endregion

        #region Implementacion de Contrato

        public TextBox CampoFila
        {
            get { return formularioModificarPuesto.Fila; }
        }

        public TextBox CampoColumna
        {
            get { return formularioModificarPuesto.Columna; }
        }

        public TextBox CampoDescripcion
        {
            get { return formularioModificarPuesto.Descripcion; }
        }

        public TextBox CampoPrecio
        {
            get { return formularioModificarPuesto.Precio; }
        }

        public Button BtnAceptar
        {
            get { return botonAceptar; }
        }

        public Button BtnCancelar
        {
            get { return botonCancelar; }
        }

        public Label LabelMensajeExito
        {
            get { return mensajeDeEstado.mensajeExito; }
            set { mensajeDeEstado.mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return mensajeDeEstado.mensajeError; }
            set { mensajeDeEstado.mensajeError = value; }
        }

        #endregion

        #region constructor
        public web_2_modificarPuesto()
        {
            _presentador = new Presentador_2_modificarPuesto(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Metodo de evento del boton para actualizar el puesto.
        /// </summary>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar();
        }

        /// <summary>
        /// Metodo que regresa al regresar puesto.
        /// </summary>
        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(_presentador.EventoClickCancelar());
        }

        #region CodigoAnterior
        /*
        private string paginaBuscar = RecursosInterfaz.PaginaConsultarPuesto;       
        private object _fila;
        private object _columna;
        private object _descripcion;
        private object _monto;

        /// <summary>
        /// Metodo de entrada de la pagina.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

          _fila = Session[RecursosInterfaz.IdFila];
           _columna = Session[RecursosInterfaz.IdColumna];
            _descripcion = Session[RecursosInterfaz.Descripcion];
             _monto = Session[RecursosInterfaz.Precio];
             Inicio();
        
        }

        /// <summary>
        /// Metodo que llena el formulario.
        /// </summary>
        private void Inicio()
        {
            string fila = (string)_fila;
            string columna = (string)_columna;
            string descripcion = (string)_descripcion;
            string monto = (string)_monto;
           
            if (!IsPostBack)
            {
               

                // seteo los campos del componentes!
                this.formularioModificarPuesto.filas(fila);
                this.formularioModificarPuesto.columnas(columna);
                this.formularioModificarPuesto.descripcions(descripcion);
                this.formularioModificarPuesto.montos(monto);

            
            
            }
        
        
        }
        
        /// <summary>
        /// Metodo de evento del boton para actualizar el puesto.
        /// </summary>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    try{
        //    string estado=string.Empty;
        //    string filax = this.formularioModificarPuesto.filac();
        //    string columnax= this.formularioModificarPuesto.columnac();
        //    string descripcionx=this.formularioModificarPuesto.descripcionc();
        //    string montox=this.formularioModificarPuesto.montoc();

        //    LogicaPuesto logica = new LogicaPuesto();
        //    bool flag = logica.actualizacionPuesto(filax,
        //                                columnax,
        //                                descripcionx,
        //                                montox,
        //                                estado);
        //    if (flag)
        //    {
               
        //        this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoModificarPuesto);
        //    }
        //    }
        //    catch (ExcepcionPuesto ex)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(ex.Message + RecursosExcepcionesPlaya.mensajeDeDatos);
        //    }
        //    catch (ExcepcionPuestoLogica exl)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(exl.Message + RecursosExcepcionesPlaya.mensajeDeLogica);
        //    }
        //    catch (HttpException)
        //    {
        //        this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //    }
        }
        /// <summary>
        /// Metodo que regresa al regresar puesto.
        /// </summary>
        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(RecursosInterfaz.PaginaConsultarPuesto);
        }
         */
        #endregion
        
    }
}
