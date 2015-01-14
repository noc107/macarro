using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.Presentacion.Presentadores.MenuRestaurante;


namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_modificarProducto : System.Web.UI.Page, IContrato_05_ModificarPlato
    {

        private Presentador_05_ModificarProducto _presentador;

        /// <summary>
        /// Inicializacion del presentador
        /// </summary>
        public web_05_modificarProducto()
        {
            _presentador = new Presentador_05_ModificarProducto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presentador.EventoConsultar(1);
            }
        }


        protected void modificarPlato(object sender, EventArgs e)
        {
            try
            {
                _presentador.EventoAceptar_Click(1);
                _mensajeExito.Visible = true;
                _mensajeError.Visible = false;


            }
            catch (Exception ex)
            {
                _mensajeExito.Visible = false;
                _mensajeError.Visible = true;
            }
        }



        /// <summary>
        /// Implementacion del metodo nombre
        /// </summary>
        public TextBox nombre
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo descripcion
        /// </summary>
        public TextBox descripcion
        {
            get { return _descripcionProducto; }
            set { _descripcionProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo precio
        /// </summary>
        public TextBox precio
        {
            get { return _precioProducto; }
            set { _precioProducto = value; }
        }

        /// <summary>
        /// Implementacion del metodo seccion
        /// </summary>
        public DropDownList seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeExito
        /// </summary>
        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeError
        /// </summary>
        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }
    }
}

