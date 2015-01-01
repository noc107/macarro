using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Interfaz;
using BackOffice.Presentacion.Contratos.IngresoRecuperacionClave;
using BackOffice.Presentacion.Presentadores.IngresoRecuperacionClave;

namespace BackOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_inicioSesionA : System.Web.UI.Page, IContrato_01_inicioSesionA
    {
        private Presentador_01_inicioSesionA _presentador;

        // Variables de sesión para el correo y contraseña
        
        public web_01_inicioSesionA()
        {
             _presentador = new Presentador_01_inicioSesionA(this);
        }

        string IContrato_01_inicioSesionA.correo
        {
            get { return correo.Text; }
        }

        string IContrato_01_inicioSesionA.Contrasena
        {
            get { return Contrasena.Text; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // Se inicializan las variables de sesión
        }

        /// <summary>
        /// Se conecta con la capa Lógica y le pasa los valores obtenidos en los textBox.
        ///También se definen las variables de sesión
        /// </summary>
        protected void Boton_IniciarSesion(object sender, EventArgs e)
        {
            _presentador.Boton_IniciarSesion();
        
            // IMPLEMENTACIÓN DE INICIO DE SESIÓN    
        
    

        //    LogicaLogin _envioParametros = new LogicaLogin();

        //    if (correo.Text != null && Contrasena.Text != null)
        //    {
        //        LogicaEmpleado _empleado = new LogicaEmpleado();
        //        _empleado = _envioParametros.inicio(correo.Text, Contrasena.Text);
        //        if (_empleado.Correo != string.Empty)
        //        {
        //            Session["correo"] = _empleado.Correo;
        //            Session["docIdentidad"] = _empleado.DocIdentidad;
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



        public Label LabelMensajeExito
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Label LabelMensajeError
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}