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
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /** private DataTable _dt;
        private string _nombreServicio;

        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion


        private void variableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                ex.GetType();
            }
        } 

        **/

        #region Métodos 
        /// <summary>
        /// Cargar gridview con servicios regustrados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _presentador.cargarPagina();

            //variableSesion();

            //logicaConsultaServicio _consulta;

            //this.LabelMensaje.Visible = false;
            //if (Request.QueryString["Mensaje"] != null)
            //{
            //    this.LabelMensaje.Visible = true;
            //    if (Request.QueryString["Mensaje"].Equals("1"))
            //    {
            //        this.LabelMensaje.Text = UtilidadMensajes._msgModificacionServicio;
            //        LabelMensaje.CssClass = "avisoMensaje MensajeExito";
            //    }
            //    else
            //    {
            //        LabelMensaje.CssClass = "avisoMensaje MensajeError";
            //        this.LabelMensaje.Text = Request.QueryString["Mensaje"];
            //    }
            //}

            //_consulta = new logicaConsultaServicio();
            //this._dt = _consulta.buscarServicio(txtBuscar.Text, listEstado.SelectedValue, this.LabelMensaje);


            //Servicios.DataSource = this._dt;
            //Servicios.DataBind();
                

         }

        /// <summary>
        /// Obtiene nombre del servicio en la fila seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Servicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            _presentador.Servicios_RowCommand();

            //if (e.CommandName == "Select" || e.CommandName == "Delete" || e.CommandName == "Edit")
            //{ 
            //    Int16 _servicioIndex;

            //    _servicioIndex = Convert.ToInt16(e.CommandArgument);
            //    this._nombreServicio = HttpUtility.HtmlDecode(Servicios.Rows[_servicioIndex].Cells[0].Text);
            //}
        }

        /// <summary>
        /// Evento asociado a eliminar servicio
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Servicios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _presentador.Servicios_RowDeleting();

        //    logicaConsultaServicio _eliminar;
        //    logicaConsultaServicio _consulta;

        //    _eliminar = new logicaConsultaServicio();

        //    _eliminar.eliminarServicio(this._nombreServicio, this.LabelMensaje);

        //    this.txtBuscar.Text = "";
        //    this.listEstado.SelectedIndex = 0;

        //    _consulta = new logicaConsultaServicio();
        //    this._dt = _consulta.buscarServicio(txtBuscar.Text, listEstado.SelectedValue, this.LabelMensaje);

        //    Servicios.DataSource = this._dt;
        //    Servicios.DataBind();

        }

        ///// <summary>
        ///// Evento asociado a modificar servicio
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>        
        protected void Servicios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            _presentador.Servicios_RowEditing();

        //    Response.Redirect("web_03_modificarServiciosPlaya.aspx?Servicio=" + this._nombreServicio);

        }

        ///// <summary>
        ///// Evento asociado a la consulta completa del servicio
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            _presentador.Servicios_SelectedIndexChanging();

        //    Response.Redirect("web_03_consultaServicioCompleta.aspx?Servicio=" + this._nombreServicio);

        }

        ///// <summary>
        ///// Evento asociado a la paginación del gridview
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _presentador.Servicios_PageIndexChanging();

        //    this.Servicios.PageIndex = e.NewPageIndex;
        //    this.Servicios.DataSource = this._dt;
        //    this.Servicios.DataBind();
        }

        ///// <summary>
        ///// Agregar un atributo de confirmacion por cada boton de Delete del GridView
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void Servicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            _presentador.Servicios_RowDataBound();

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        foreach (ImageButton button in e.Row.Cells[4].Controls.OfType<ImageButton>())
        //        {
        //            if (button.CommandName == "Delete")
        //            {
        //                if (ControlRolAccion.listaAcciones(_correoS).Contains("Eliminar servicio de playa"))
        //                {
        //                    button.Attributes["onclick"] = "if(!confirm('" + UtilidadMensajes._msgEliminar+ "')){ return false; };";
        //                }
        //                else
        //                {
        //                    LabelMensaje.Text = "No posee los perminsos para eliminar el ítem";
        //                    LabelMensaje.Visible = true;
        //                }
        //            }
        //        }
        //    }
        }

        ///// <summary>
        ///// Evento del boton de busqueda de servicios
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            _presentador.imgBuscar_Click();
        //    logicaConsultaServicio _busqueda;

        //    _busqueda = new logicaConsultaServicio();
        //    this._dt = _busqueda.buscarServicio(txtBuscar.Text, listEstado.SelectedValue, this.LabelMensaje);

        //    if (this._dt != null)
        //    {

        //        Servicios.DataSource = this._dt;
        //    }
        //    else
        //        Servicios.DataSource = null;
            
        //    Servicios.DataBind();


        }

        #endregion

    }
}