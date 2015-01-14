using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.VentaCierreCaja;
using BackOffice.Presentacion.Presentadores.VentaCierreCaja;

namespace back_office.Interfaz.web.VentaCierreCaja
{

    public partial class WebForm3 : System.Web.UI.Page, IContrato_07_GestionarVenta
    {
        /*#region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion*/

        private Presentador_07_GestionarVenta _presentadorGestionarVenta;

        public WebForm3()
        {
            this._presentadorGestionarVenta = new Presentador_07_GestionarVenta(this);
        }

        /// <summary>
        /// Metodo al cargar la pagina de gestion de facturas
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {

            this._presentadorGestionarVenta.OcultarMensajes();
            
            this._presentadorGestionarVenta.ConsultarFacturas();
            
            /*if (!Page.IsPostBack)
            {
                variableSesion();
            }*/                      
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
            /*try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                MensajeError.Text = "No se han podido cargar los datos de sesion";
                MensajeError.Visible = true;
                ex.GetType();
            }*/
        }

        /// <summary>
        /// Metodo de paginacion del GridView
        /// </summary>
        protected void Ventas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            this._presentadorGestionarVenta.Ventas_PageIndexChanging(e);
           
        }

        /// <summary>
        /// Agregar los respectivos botones al gridView de ventas
        /// </summary>
        protected void Ventas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton _verDetalle = this._presentadorGestionarVenta.ImageButtonVerDetalle();
                _verDetalle.Click += new ImageClickEventHandler(this.botonVerDetalle_Click);

                ImageButton _modificar = this._presentadorGestionarVenta.ImageButtonModificar();
                _modificar.Click += new ImageClickEventHandler(this.botonModificar_Click);

                ImageButton _eliminar = this._presentadorGestionarVenta.ImageButtonEliminar();
                _eliminar.Click += new ImageClickEventHandler(this.botonEliminar_Click);

                e.Row.Cells[4].Controls.Add(_verDetalle);
                e.Row.Cells[4].Controls.Add(_modificar);
                e.Row.Cells[4].Controls.Add(_eliminar);
            }


        }

        /// <summary>
        /// Metodo de del evento de ver en detalle una factura
        /// </summary>
        void botonVerDetalle_Click(Object sender, ImageClickEventArgs e)
        {

            Response.Redirect("web_07_imprimirFactura.aspx?NroFactura=" + this._presentadorGestionarVenta.VerDetalle_Click(sender), false);
            
        }

        /// <summary>
        /// Metodo de del evento de modificar una factura
        /// </summary>
        void botonModificar_Click(Object sender, ImageClickEventArgs e)
        {

               Response.Redirect("web_07_facturacion.aspx?NroFactura=" + this._presentadorGestionarVenta.Modificar_Click(sender), false);
   
        }

        /// <summary>
        /// Metodo de del evento de eliminar una factura
        /// </summary>
        void botonEliminar_Click(Object sender, ImageClickEventArgs e)
        {

            this._presentadorGestionarVenta.Eliminar_Click(sender);

        }

        /// <summary>
        /// Metodo de del evento del boton de busqueda
        /// </summary>
        void imgBuscar_Click(Object sender, ImageClickEventArgs e)
        {

            this._presentadorGestionarVenta.ConsultarFacturas();        
        
        }


        public DropDownList listaEstadoBuscador
        {
            get
            {
                return this.listEstado;
            }
            set
            {
                this.listEstado = value;
            }
        }

        public TextBox TBoxBuscador
        {
            get
            {
                return this.txtBuscar;
            }
            set
            {
                this.txtBuscar = value;
            }
        }

        public GridView GridVentas
        {
            get
            {
                return this.Ventas;
            }
            set
            {
                this.Ventas = value;
            }
        }

        public Label LabelMensajeExito
        {
            get
            {
                return this._mensajeExito;
            }
            set
            {
                this._mensajeExito = value;
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                return this._mensajeError;
            }
            set
            {
                this._mensajeError = value;
            }
        }

    }
}