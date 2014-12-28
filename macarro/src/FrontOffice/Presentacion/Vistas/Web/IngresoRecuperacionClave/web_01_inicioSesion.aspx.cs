
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_inicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se conecta con la capa Lógica y le pasa los valores obtenidos en los textBox.
        ///También se definen las variables de sesión
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
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