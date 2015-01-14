using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BackOffice.Presentacion.Presentadores.ConfiguracionServiciosPlaya;
using BackOffice.Presentacion.Contratos.ConfiguracionServiciosPlaya;

namespace BackOffice.Presentacion.Vistas.Web.ConfiguracionServiciosPlaya
{
    public partial class web_03_consultaServicio : System.Web.UI.Page, IContrato_03_consultaServicio
    {
        private string _nombreServicio;
        #region Párametros

        private Presentador_03_consultaServicio _presentador;

        #endregion

        #region Constructor

        public web_03_consultaServicio()
        {
            _presentador = new Presentador_03_consultaServicio(this);
        }

        #endregion

        #region Implementación de IContrato_03_consultaServicio

        public TextBox servicioABuscar
        {
            get { return txtBuscar; }
        }

        public DropDownList estadoDelServicio
        {
            get { return listEstado; }
        }

        public GridView tablaDeServicios
        {
            get { return Servicios; }
            set { Servicios = value; }
        }

        public ImageButton imagenBoton
        {
            get { return imgBuscar; }
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

        #region Métodos
        /// <summary>
        /// Cargar gridview con servicios registrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.cargarPagina();
        }

        /// <summary>
        /// Obtiene nombre del servicio en la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Servicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select" || e.CommandName == "Delete" || e.CommandName == "Edit")
            {
                Int16 _servicioIndex;

                _servicioIndex = Convert.ToInt16(e.CommandArgument);
                this._nombreServicio = HttpUtility.HtmlDecode(Servicios.Rows[_servicioIndex].Cells[0].Text);
            }
        }

        /// <summary>
        /// Evento asociado a eliminar servicio
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Servicios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _presentador.EventoEliminarServicio(this._nombreServicio);
        }

        ///// <summary>
        ///// Evento asociado a modificar servicio
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>        
        protected void Servicios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect(_presentador.RedireccionarPaginaEditar(this._nombreServicio));
        }

        ///// <summary>
        ///// Evento asociado a la consulta completa del servicio
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect(_presentador.RedireccionarPaginaConsultar(this._nombreServicio));
        }

        ///// <summary>
        ///// Evento asociado a la paginación del gridview
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tablaDeServicios.PageIndex = e.NewPageIndex;
            _presentador.imgBuscar_Click();
        }

        ///// <summary>
        ///// Agregar un atributo de confirmacion por cada boton de Delete del GridView
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                foreach (ImageButton button in e.Row.Cells[5].Controls.OfType<ImageButton>())
                    button.Attributes["onclick"] = "if(!confirm('" + RecursosServicioPresentador._msgEliminar + "')){ return false; };";

        }

        ///// <summary>
        ///// Evento del boton de busqueda de servicios
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            _presentador.imgBuscar_Click();
        }

        #endregion

    }
}