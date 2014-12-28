using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_recuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
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