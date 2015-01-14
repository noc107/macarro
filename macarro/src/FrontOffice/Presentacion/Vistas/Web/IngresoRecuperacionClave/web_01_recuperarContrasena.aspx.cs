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
    public partial class web_01_recuperarContrasena : System.Web.UI.Page, IContrato_01_recuperarContrasena
    {

        private Presentador_01_recuperarContrasena _presentador;

        // Variables de sesión para el correo y contraseña

        public web_01_recuperarContrasena()
        {
            _presentador = new Presentador_01_recuperarContrasena(this);
        }


        TextBox IContrato_01_recuperarContrasena.Ncontrasena
        {
            get { return Ncontrasena; }
            //set { Ncontrasena.Text = value; }
        }

        TextBox IContrato_01_recuperarContrasena.Ccontrasena
        {
            get { return Ccontrasena; }
            //set { Ccontrasena.Text = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // inicio
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            _presentador.Aceptar_Click();
            
            //LogicaLogin _envioParametros = new LogicaLogin();
            //string _correoS = Session["correo"].ToString();

            //if (_envioParametros.cambiarClave(_correoS, Ccontrasena.Text))
            //{
            //    //Response.Write("Su contraseña se cambio con éxito");
            //    Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_bienvenido.aspx");
            //}
            //else 
            //{
            //    Response.Write("En estos momentos no se pudo procesar su solicitud");
            //}
        }

    }
}