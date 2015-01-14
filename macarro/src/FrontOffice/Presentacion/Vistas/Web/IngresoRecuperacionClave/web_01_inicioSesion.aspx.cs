
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using FrontOffice.Presentacion.Presentadores.IngresoRecuperacionClave;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_inicioSesion : System.Web.UI.Page, IContrato_01_inicioSesion
    {
        private Presentador_01_inicioSesion _presentador;
        
        // Variables de sesión para el correo y contraseña
        #region Variables de Sesion
        string _correoS;
        string _docIdentidadS;
        string _primerNombreS;
        string _primerApellidoS;
        #endregion

        public web_01_inicioSesion()
        {
             _presentador = new Presentador_01_inicioSesion(this);
        }

        #region Get & Set, Implementación del contrato inicioSesionA
        TextBox IContrato_01_inicioSesion.correo
        {
            get { return correo; }
        }

        TextBox IContrato_01_inicioSesion.Contrasena
        {
            get { return Contrasena; }
        }

        public Label LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

        public Label LabelMensajeError
        {
            get { return _mensajeError; }
            set { _mensajeError = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {

            }
            */
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
                _presentador.MostrarMensajeError("No se han cargado los datos de sesión");
                _mensajeError.Visible = true;
            }
        }

        /// <summary>
        /// Se conecta con la capa Lógica y le pasa los valores obtenidos en los textBox.
        ///También se definen las variables de sesión
        /// </summary>
        protected void Boton_IniciarSesion(object sender, EventArgs e)
        {
            try
            {
                _presentador.verificarDatos(correo.Text, Contrasena.Text);

            }
            catch (Exception)
            {
                _presentador.MostrarMensajeError("No se han podido ingresar debido a que ha ocurrido un error");
                _mensajeError.Visible = true;
            }
            

        // IMPLEMENTACIÓN DE INICIO DE SESIÓN   

        //    LogicaLogin _envioParametros = new LogicaLogin();

        //    if (correo.Text != null && Contrasena.Text != null)
        //    {
        //        LogicaCliente _cliente = new LogicaCliente();
        //        _cliente = _envioParametros.inicio(correo.Text, Contrasena.Text);
        //        if (_cliente.Correo != string.Empty)
        //        {
        //            Session["correo"] = _cliente.Correo;
        //            Session["docIdentidad"] = _cliente.DocIdentidad;
        //            Session["primerNombre"] = _cliente.PrimerNombre;
        //            Session["primerApellido"] = _cliente.PrimerApellido;
        //            Session.Timeout = 15;
        //            Response.Redirect("../inicio.aspx");

        //            //Response.Write("Entro con el correo: " + recibe.Correo);
        //        }
        //        else
        //            Response.Write("Correo o Contraseña invalido");
        //    }
        }

        ///// <summary>
        ///// Redirecciona a la página de pregunta secreta en caso de estar registrado
        ///// </summary>
        protected void BOlvidasteContrasena_Click(object sender, EventArgs e)
        {

            _presentador.BOlvidasteContrasena_Click();

            // IMPLEMENTACIÓN DE OLVIDAR CONTRASEÑA
        //    LogicaLogin _envioParametro = new LogicaLogin();
        //    string _recibeCorreo = _envioParametro.verificoCorreo(correo.Text);
        //    if (_recibeCorreo == correo.Text)
        //    {
        //        Session["correo"] = _recibeCorreo;
        //        Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_preguntaSeguridad.aspx");
        //    }
        //    else
        //        Response.Write("Usted no esta registrado");
        }

        
    }
}