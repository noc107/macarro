using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;
//using BackOffice.Excepciones.RolesSeguridad;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_editarRol : System.Web.UI.Page, IContrato_08_EditarRol
    {
        
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        string rolN;
        private Presentador_08_EditarRol _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public web_08_editarRol()
        {
            _presentador = new Presentador_08_EditarRol(this);
        }

        /// <summary>
        /// Metodo que inicia al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                _presentador.rolActual(Convert.ToInt32(Request.QueryString["r"]));
                if (!Page.IsPostBack)
                {
                    _presentador.llenarInfo();
                }
                rolN = TBNombre.Text;
            }
            catch (NullReferenceException)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeNoSeleccionado);
                LabelMensajeError.Visible = true;
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
        /// Implementacion del metodo TBNombre
        /// </summary>
        public TextBox TBNombre 
        {
            get { return tNombre; }
            set { tNombre = value; } 
        
        }

        /// <summary>
        /// Implementacion del metodo TBDescripcion
        /// </summary>
        public TextBox TBDescripcion
        {
            get { return tDescripcion; }
            set { tDescripcion = value; }
        }

        /// <summary>
        /// Implementacion del metodo LBAccionesDisponibles
        /// </summary>
        public ListBox LBAccionesDisponibles 
        {
            get { return ListaAccionesDisponibles; }
            set { ListaAccionesDisponibles = value; }
        }

        /// <summary>
        /// Implementacion del metodo LBAccionesAsignadas
        /// </summary>
        public ListBox LBAccionesAsignadas
        {
            get { return ListaAccionesAsignadas; }
            set { ListaAccionesAsignadas = value; }
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
        /// Metodo para manejar elvento del boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_08_gestionarRoles.aspx");
        }

        /// <summary>
        /// Metodo para manejar elvento del boton modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rolN.Equals(tNombre.Text, StringComparison.OrdinalIgnoreCase) || !_presentador.VerificarRol(tNombre.Text))
                {
                    _presentador.EventoAceptar_Click();

                    _presentador.MostrarMensajeExito(RecursosInterfazRolesSeguridad.mensajeModificacion);
                    LabelMensajeExito.Visible = true;
                }
                else
                {
                    _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeRegistrado);
                    LabelMensajeError.Visible = true;
                }
            }
            //catch (ExcepcionListAccionVacia ex)
            //{
            //    _presentador.MostrarMensajeError(ex.Message);
            //    LabelMensajeError.Visible = true;
            //}
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }

        }

        /// <summary>
        /// Metodo para manejar elvento del boton de agregar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ListaAccionesDisponibles.SelectedIndex != -1)
                {
                    _presentador.EventoAgregar_Click();
                }
                else
                {
                    _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeElemento);
                    LabelMensajeError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }

        }

        /// <summary>
        /// Metodo para manejar elvento del boton de quitar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void quitar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ListaAccionesAsignadas.SelectedIndex != -1)
                {
                    _presentador.EventoQuitar_Click();
                }
                else
                {
                    _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeElemento);
                    LabelMensajeError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }
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