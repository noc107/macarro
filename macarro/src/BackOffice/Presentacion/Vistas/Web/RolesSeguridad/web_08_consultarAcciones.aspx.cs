using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_consultarAcciones : System.Web.UI.Page,IContrato_08_ConsultarAcciones
    {
        
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        private Presentador_08_ConsultarAcciones _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public web_08_consultarAcciones()
        {
            _presentador = new Presentador_08_ConsultarAcciones(this);
        }

        /// <summary>
        /// Metodo que inicia al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //variableSesion();

            try
            {
                _presentador.BindGridAcciones();
            }
            catch (SqlException)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeConexionBD);
                LabelMensajeError.Visible = true;
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }

        }

        /// <summary>
        /// Metodo para el manejo de la paginacion del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVAccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GVAccion.PageIndex = e.NewPageIndex;
                _presentador.BindGridAcciones();
                LabelMensajeError.Visible = false;
            }
            catch (SqlException)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeConexionBD);
                LabelMensajeError.Visible = true;
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Implementacion del metodo GVAcciones
        /// </summary>
        public GridView GVAcciones
        {
            get { return GVAccion; }
            set { GVAccion = value; }
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
        /// Metodo para cargar las variables de sesion
        /// </summary>
        private void variableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeSesion);
                LabelMensajeError.Visible = true;
            }
        }

    }


}