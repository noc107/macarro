using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Interfaz;
using BackOffice.Presentacion.Contratos;
using BackOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using BackOffice.Presentacion.Presentadores.IngresoRecuperacionClave;

namespace BackOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_inicioSesionA : System.Web.UI.Page, IContrato_01_inicioSesionA
    {
        private Presentador_01_inicioSesionA _presentador;

        // Variables de sesión para el correo y contraseña
        #region Variables de Sesion
            string _correoS;
            string _docIdentidadS;
            string _primerNombreS;
            string _primerApellidoS;
        #endregion
        
        public web_01_inicioSesionA()
        {
             _presentador = new Presentador_01_inicioSesionA(this);
        }

        #region Get & Set, Implementación del contrato inicioSesionA

        TextBox IContrato_01_inicioSesionA.correo
        {
            get { return correo; }
        }

        TextBox IContrato_01_inicioSesionA.Contrasena
        {
            get { return Contrasena; }
        }


         Label Contratos.IContratoGeneral.LabelMensajeExito
        {
            get { return _mensajeExito; }
            set { _mensajeExito = value; }
        }

         Label Contratos.IContratoGeneral.LabelMensajeError
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
        //        LogicaEmpleado _empleado = new LogicaEmpleado();
        //        _empleado = _envioParametros.inicio(correo.Text, Contrasena.Text);
        //        if (_empleado.Correo != string.Empty)
        //        {
        //            Session["correo"] = _empleado.Correo;
        //            Session["docId"] = _empleado.DocIdentidad;
        //            Session["primerNombre"] = _empleado.PrimerNombre;
        //            Session["primerApellido"] = _empleado.PrimerApellido;
        //            Session.Timeout = 15;
        //            Response.Redirect("/Presentacion/Vistas/Web/inicio.aspx");

        //            //Response.Write("Entro con el correo: " + recibe.Correo);
        //        }
        //        else
        //        {
        //            Response.Write("Correo o Contraseña invalido");               
        //        }
        //    }
        }

    }
}