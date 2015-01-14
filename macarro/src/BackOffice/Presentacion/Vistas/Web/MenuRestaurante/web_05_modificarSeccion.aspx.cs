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
    public partial class web_05_modificarSeccion : System.Web.UI.Page, IContrato_05_ModificarSeccion
    {
       
        private Presentador_05_ModificarSeccion _presentador;

        /// <summary>
        /// Inicializacion del presentador
        /// </summary>
        public web_05_modificarSeccion()
        {
            _presentador = new Presentador_05_ModificarSeccion(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _presentador.EventoConsultar(1);
               // _presentador.llenarInfo(Convert.ToInt32(Request.QueryString["r"]));
            }
            //rolN = TBNombre.Text;
        }

        protected void modificaSeccion(object sender, EventArgs e)
        {
            try
            {
                _presentador.EventoAceptar_Click();
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

