using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_preguntaSeguridad : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string _correoS = (string)(Session["correo"]);
            //LogicaLogin _preguntaSeguridad = new LogicaLogin();
            //Lpregunta.Text = _preguntaSeguridad.obtenerPreguntaL(_correoS);
        }
        /// <summary>
        /// Se redirecciona a la página para cambiar la contraseña en caso de que la respuesta de 
        /// seguridad sea la correcta
        /// </summary>
        protected void Siguiente_Click(object sender, EventArgs e)
        {
            //LogicaLogin _respuestaCorrecta = new LogicaLogin();
            //string _correoS = (string)(Session["correo"]);
            
            //if (_respuestaCorrecta.comparar(_correoS, Respuesta.Text))
            //{
            //    Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_recuperarContrasena.aspx");
            //}
            //else
            //{
            //    Response.Write("Respuesta invalida");
            //}
        }
    }
}