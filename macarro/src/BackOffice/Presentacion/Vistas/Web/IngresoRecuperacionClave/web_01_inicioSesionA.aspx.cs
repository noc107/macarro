using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Interfaz;

namespace BackOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_inicioSesionA : System.Web.UI.Page
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


    }
}