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
    public partial class web_2_consultarInventario : System.Web.UI.Page , IContrato_2_consultarInventario
    {

        #region Presentador
        private Presentador_2_consultarInventario _presentador;
        #endregion

        #region Implementación de Contrato

        public DropDownList DropTipoItem
        {
            get { return comboConsultarInventario.TipoDeItem; }
        }

        public Button BtnAceptar 
        {
            get { return botonAceptar; } 
        }

        public GridView GridTablaInventario 
        {
            get { return GvInventario;} 
        }

        public Button BtnModificarTodo 
        {
            get { return Btn_Modificar;}
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
        public web_2_consultarInventario()
        {
            _presentador = new Presentador_2_consultarInventario(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Buscador que se activa al presionar el boton de aceptar
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void ConsultarListaInventario(object sender, EventArgs e)
        {
            _presentador.EventoClickConsultarInventario();           
        }

        /// <summary>
        /// Acciones que se pueden ejecutar en el GridView
        /// </summary>
        protected void GvInventarioRowCommand(object sender, GridViewCommandEventArgs e)
        {                                              

            if (e.CommandName == RecursosInterfaz.ComandoModificar)
            {
                ComandoGridModificar(e);
            }

            if (e.CommandName == RecursosInterfaz.ComandoEliminar)
            {
                ComandoGridEliminar(e);
            }
        }

        /// <summary>
        /// Método que es llamado al seleccionarse
        /// el cambio de la página.
        /// Paginación de la tabla
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void GvInventarioPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridTablaInventario.PageIndex = e.NewPageIndex;
            _presentador.EventoClickConsultarInventario();
        }

        /// <summary>
        /// Método que es llamado al darle al boton de modificar todos
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Evento</param>
        protected void Btn_Modificar_Click(object sender, EventArgs e)
        {
            Session[RecursosInterfaz.IdInventario] = null;
            Session[RecursosInterfaz.InvTipo] = this.comboConsultarInventario.TipoDeItem.Text;
            Response.Redirect(_presentador.EventoModificar());            
        }

        private void ComandoGridModificar(GridViewCommandEventArgs e) 
        {
            
            int idInventario;

            int indiceSeleccionado = Convert.ToInt32(e.CommandArgument);
            string idValue = GridTablaInventario.DataKeys[indiceSeleccionado].Value.ToString();
            bool parsed = Int32.TryParse(idValue, out idInventario);
            Session[RecursosInterfaz.IdInventario] = idInventario;
            Response.Redirect(_presentador.EventoModificar()); 
        
        }

        private void ComandoGridEliminar(GridViewCommandEventArgs e)
        {
            
            int idInventario;

            int indiceSeleccionado = Convert.ToInt32(e.CommandArgument);
            string idValue = GridTablaInventario.DataKeys[indiceSeleccionado].Value.ToString();
            bool parsed = Int32.TryParse(idValue, out idInventario);

            _presentador.EventoEliminarItemSeleccionado(idInventario);
        }

    }
}