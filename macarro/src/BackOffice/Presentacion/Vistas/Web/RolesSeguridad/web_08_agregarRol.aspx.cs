using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackOffice.Presentacion.Contratos.RolesSeguridad;
using BackOffice.Presentacion.Presentadores.RolesSeguridad;
using BackOffice.Presentacion.Vistas.Web.RolesSeguridad.Recursos;

namespace BackOffice.Presentacion.Vistas.Web.RolesSeguridad
{
    public partial class web_08_agregarRol : System.Web.UI.Page, IContrato_08_AgregarRol
    {
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion
        private Presentador_08_AgregarRol _presentador;

        /// <summary>
        /// Constructor de la interfaz e inicializacion del presentador
        /// </summary>
        public web_08_agregarRol()
        {
            _presentador = new Presentador_08_AgregarRol(this);
        }

        /// <summary>
        /// Metodo que inicia al cargar la interfaz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //    variableSesion();
            if (!Page.IsPostBack)
            {
                _presentador.llenarInfo();
            }
        }

        /// <summary>
        /// Implementacion del metodo TBNombre
        /// </summary>
        public TextBox TBNombre
        {
            get { return TextBoxNombre; }
            set { TextBoxNombre = value; }

        }

        /// <summary>
        /// Implementacion del metodo TBDescripcion
        /// </summary>
        public TextBox TBDescripcion
        {
            get { return TextBoxDescripcion; }
            set { TextBoxDescripcion = value; }
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
        /// Metodo para manejar elvento del boton aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (!_presentador.VerificarRol(TextBoxNombre.Text))
            {
                if (_presentador.EventoAceptar_Click())
                {
                    _presentador.MostrarMensajeExito(RecursosInterfazRolesSeguridad.mensajeAgregado);
                    LabelMensajeExito.Visible = true;
                }
            }
            else
            {
                _presentador.MostrarMensajeError(RecursosInterfazRolesSeguridad.mensajeRegistrado);
                LabelMensajeError.Visible = true;
                LabelMensajeExito.Visible = false;
            }
        }

        /// <summary>
        /// Metodo para manejar elvento del boton de agregar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregar_Click(object sender, ImageClickEventArgs e)
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

        /// <summary>
        /// Metodo para manejar elvento del boton de quitar accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void quitar_Click(object sender, ImageClickEventArgs e)
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