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
    public partial class web_2_configurarPlaya : System.Web.UI.Page , IContrato_2_configurarPlaya
    {

        #region Presentador
        private Presentador_2_configurarPlaya _presentador;
        #endregion

        #region Implementación de Contrato
        
        public GridView GridPlayaActual
        {
	        get { return estadoActualDeLaPlaya; }
        }

        public TextBox CampoLargoPlaya
        {
	        get { return textboxConfigurarPlaya.LargoDePlaya; }
        }

        public TextBox CampoAnchoPlaya
        {
	        get { return textboxConfigurarPlaya.AnchoDePlaya; }
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
        public web_2_configurarPlaya()
        {
            _presentador = new Presentador_2_configurarPlaya(this);            
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.EventoConsultarPlayaActual();
        }

        ///// <summary>
        ///// Evento llamado al presionar el boton aceptar que llama a la capa logica para ingresar la nueva configuracion de la configuracion de la playa 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            _presentador.EventoClickAceptar();
        }

        #region CodigoAnterior
        /*
        //private Playa _configuracion;
        private int _playaAconfigurar;

        /// <summary>
        /// Ingresa en el data grid la informacion actual de la playa al carga la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>                       
        protected void Page_Load(object sender, EventArgs e)
        {
            //GenerarConfiguracionActualEnTabla();            
        }
        /// <summary>
        /// da formato al string que es mostrado en el data grid con los datos de la playa 
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        //public string MensajeDelDataGrid(string fila, string columna)
        //{
        //    string intermedio = RecursosInterfaz.textoFilasPor;
        //    string final = RecursosInterfaz.textoColumnasPor;
        //    return fila + intermedio +columna + final;
        //}
        ///// <summary>
        ///// llama a la capa logica para hacer el pedido de la informacion actual de la playa 
        ///// </summary>
        //public void GenerarConfiguracionActualEnTabla()
        //{
        //    ConfigurarPlaya estadoActual;
        //    estadoActual = new ConfigurarPlaya();
        //    _configuracion = estadoActual.solicitarConfiguracionActualDeLaPlaya();
        //    CargarConfiguracionDePlaya();
        //}
        ///// <summary>
        ///// coloca en el data grid la informacion recibida con la configuracion actual de la playa
        ///// </summary>
        //public void CargarConfiguracionDePlaya()
        //{
        //    try
        //    {
        //        DataTable configuacion = new DataTable();

        //        configuacion.Columns.Add(RecursosInterfaz.configuracionDeLaPlaya, typeof(string));
        //        _playaAconfigurar = _configuracion.Id;
        //        configuacion.Rows.Add(MensajeDelDataGrid(_configuracion.Filas.ToString(), _configuracion.Columnas.ToString()));
        //        this.estadoActualDeLaPlaya.DataSource = configuacion;
        //        this.estadoActualDeLaPlaya.DataBind();
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

        //}
        ///// <summary>
        ///// Evento llamado al presionar el boton aceptar que llama a la capa logica para ingresar la nueva configuracion de la configuracion de la playa 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
        //    this.mensajeDeEstado.OcultarMensajeDeExito();
        //    this.mensajeDeEstado.OcultarMensajeDeError();
        //    _configuracion = new Playa( _playaAconfigurar, int.Parse( this.textboxConfigurarPlaya.Largo() ), int.Parse( this.textboxConfigurarPlaya.Ancho() ) );
        //    ConfigurarPlaya configurar = new ConfigurarPlaya();
        //    try
        //    {
        //         if( configurar.ModificarConfiguracionDePlaya( _configuracion ) )
        //         {
        //             this.mensajeDeEstado.MensajeDeExito(RecursosInterfaz.mensajeDeExitoConfigurarPlaya);  
        //         }
        //         else
        //             this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
        //         GenerarConfiguracionActualEnTabla();
        //         this.botonAceptar.Enabled = false;
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