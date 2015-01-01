using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
//using BackOffice.Excepciones.RolesSeguridad;


namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_gestionarRoles : System.Web.UI.Page, IContrato_08_GestionarRoles
    {
       
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion
        
        private Presentador_08_GestionarRoles _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public web_08_gestionarRoles()
        {
            _presentador = new Presentador_08_GestionarRoles(this);
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
                _presentador.BindGridRoles();
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
        protected void GVRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GVRol.PageIndex = e.NewPageIndex;
                _presentador.BindGridRoles();
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
        /// Implementacion del metodo GVRoles
        /// </summary>
        public GridView GVRoles
        {
            get { return GVRol; }
            set { GVRol = value; }
        }

        /// <summary>
        /// Metodo para manejar el evento de la generacion de la data del GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVRol_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton consultar = _presentador.Consultar();
                    consultar.Click += new ImageClickEventHandler(this.consultarBtn_Click);

                    ImageButton editar = _presentador.Editar();
                    editar.Click += new ImageClickEventHandler(this.editarBtn_Click);

                    ImageButton eliminar = _presentador.Eliminar();
                    eliminar.Click += new ImageClickEventHandler(this.eliminarBtn_Click);

                    e.Row.Cells[2].Controls.Add(consultar);
                    e.Row.Cells[2].Controls.Add(editar);
                    e.Row.Cells[2].Controls.Add(eliminar);
                }
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void consultarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("web_08_consultarRol.aspx?r=" +  _presentador.EventoConsultarBtn_Click(sender),false);
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("web_08_editarRol.aspx?r=" + _presentador.EventoConsultarBtn_Click(sender),false);
            }
            catch (Exception ex)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeError + ex.GetType().ToString());
                LabelMensajeError.Visible = true;
            }
        }


        /// <summary>
        /// Metodo para manejar elvento del boton eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void eliminarBtn_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                _presentador.EventoEliminarBtn_Click(sender);                
            }
            //catch (ExcepcionFKRol ex)
            //{
            //    _presentador.MostrarMensajeError(ex.Message);
            //    LabelMensajeError.Visible = true;
            //}

            catch (SqlException)
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeErrorEliminacion);
                LabelMensajeError.Visible = true;
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