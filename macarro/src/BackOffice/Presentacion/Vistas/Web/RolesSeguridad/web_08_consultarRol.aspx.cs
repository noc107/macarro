using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_consultarRol : System.Web.UI.Page, IContrato_08_ConsultarRol
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        private Presentador_08_ConsultarRol _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public web_08_consultarRol()
        {
            _presentador = new Presentador_08_ConsultarRol(this);
        }

        /// <summary>
        /// Metodo que inicia al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //    variableSesion();
            _presentador.llenarInfo(Convert.ToInt32(Request.QueryString["r"]));
        }

        /// <summary>
        /// Implementacion del metodo LNombre
        /// </summary>
        public Label LNombre
        {
            get { return lNombre; }
            set { lNombre = value; }
        }

        /// <summary>
        /// Implementacion del metodo LDescripcion
        /// </summary>
        public Label LDescripcion
        {
            get { return lDescripcion; }
            set { lDescripcion = value; }
        }

        /// <summary>
        /// Implementacion del metodo LBAcciones
        /// </summary>
        public ListBox LBAcciones
        {
            get { return ListAcciones; }
            set { ListAcciones = value; }
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
   
        /// <summary>
        /// Metodo para manejar el evento del boton de regresar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_08_gestionarRoles.aspx");
        }

        /// <summary>
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
            _correoS = (string)(Session["correo"]);
            _docIdentidadS = (string)(Session["docIdentidad"]);
            _primerNombreS = (string)(Session["primerNombre"]);
            _primerApellidoS = (string)(Session["primerApellido"]);
        }

    }
}