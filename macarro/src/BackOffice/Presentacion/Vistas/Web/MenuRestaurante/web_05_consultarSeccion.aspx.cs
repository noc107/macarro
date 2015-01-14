using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.MenuRestaurante;
using BackOffice.Presentacion.Presentadores.MenuRestaurante;
//using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.MenuRestaurante
{
    public partial class web_05_consultarSeccion : System.Web.UI.Page, IContrato_05_ConsultarSeccion
    {

        private Presentador_05_ConsultarSeccion _presentador;

        public web_05_consultarSeccion()
        {
            _presentador = new Presentador_05_ConsultarSeccion(this);
        }

        /// <summary>
        /// Metodo que se ejecuta al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _presentador.EventoConsultar();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Implementacion del metodo lbNombre
        /// </summary>
        public Label nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Implementacion del metodo lbDescripcion
        /// </summary>
        public Label descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeExito
        /// </summary>
        public Label LabelMensajeExito
        {
            get { return MensajeExito; }
            set { MensajeExito = value; }
        }

        /// <summary>
        /// Implementacion del metodo LabelMensajeError
        /// </summary>
        public Label LabelMensajeError
        {
            get { return MensajeError; }
            set { MensajeError = value; }
        }
    }
}