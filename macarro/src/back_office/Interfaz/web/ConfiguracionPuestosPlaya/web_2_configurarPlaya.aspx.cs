using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Dominio;
using back_office.Logica.ConfiguracionPuestosPlaya;
using back_office.Excepciones.ConfiguracionPuestosPlaya.ConfiguracionDePlaya;
using System.Data;


namespace back_office.Interfaz.web.ConfiguracionPuestosPlaya
{
    public partial class web_2_configurarPlaya : System.Web.UI.Page
    {
        private Playa _configuracion;
        private int _playaAconfigurar;
        private const string _dataGridEncabezado = "Configuracion actual de la Playa";
        /// <summary>
        /// Ingresa en el data grid la informacion actual de la playa al carga la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>                       
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarConfiguracionActualEnTabla();            
        }
        /// <summary>
        /// da formato al string que es mostrado en el data grid con los datos de la playa 
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public string MensajeDelDataGrid(string fila, string columna)
        {
            const string intermedio = " Filas por ";
            const string final = " Columnas";
            return fila + intermedio +columna + final;
        }
        /// <summary>
        /// llama a la capa logica para hacer el pedido de la informacion actual de la playa 
        /// </summary>
        public void GenerarConfiguracionActualEnTabla()
        {
            ConfigurarPlaya estadoActual;
            estadoActual = new ConfigurarPlaya();
            _configuracion = estadoActual.solicitarConfiguracionActualDeLaPlaya();
            CargarConfiguracionDePlaya();
        }
        /// <summary>
        /// coloca en el data grid la informacion recibida con la configuracion actual de la playa
        /// </summary>
        public void CargarConfiguracionDePlaya()
        {
            try
            {
                DataTable configuacion = new DataTable();

                configuacion.Columns.Add(_dataGridEncabezado, typeof(string));
                _playaAconfigurar = _configuracion.Id;
                configuacion.Rows.Add(MensajeDelDataGrid(_configuracion.Filas.ToString(), _configuracion.Columnas.ToString()));
                this.estadoActualDeLaPlaya.DataSource = configuacion;
                this.estadoActualDeLaPlaya.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Evento llamado al presionar el boton aceptar que llama a la capa logica para ingresar la nueva configuracion de la configuracion de la playa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            this.mensajeDeEstado.OcultarMensajeDeExito();
            this.mensajeDeEstado.OcultarMensajeDeError();
            _configuracion = new Playa( _playaAconfigurar, int.Parse( this.textboxConfigurarPlaya.Largo() ), int.Parse( this.textboxConfigurarPlaya.Ancho() ) );
            ConfigurarPlaya configurar = new ConfigurarPlaya();
            try
            {
                 configurar.ModificarConfiguracionDePlaya( _configuracion );
                 if( configurar.ModificarConfiguracionDePlaya( _configuracion ) )
                 {
                     this.mensajeDeEstado.MensajeDeExito(RecursosInterfazConfiguracioPuestosPlaya.mensajeDeExitoConfigurarPlaya);  
                 }
                 else
                     this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
                 GenerarConfiguracionActualEnTabla();
            }
            catch (ExcepcionConfiguracionPlayaDatos)
            {
                this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeDeDatos);
            }
            catch (ExcepcionConfiguracionPlayaLogica)
            {
                this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeDeLogica);
            }
            catch (Exception)
            {
                this.mensajeDeEstado.MensajeDeError(RecursosExcepcionesPlaya.mensajeFalso);
            }
        }

    }
}