using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.IngresoRecuperacionClave
{
    public partial class web_01_registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
           // if (SegNombre.Text == "")
           //     SegNombre.Text = null;
           // if (SegApellido.Text == "")
           //     SegApellido.Text = null;

           //// FechaNac.Text = Convert.ToDateTime(FechaNac.Text).ToString("dd/MM/yyyy");

           // LogicaLogin _pasoParametros = new LogicaLogin();
           // bool _resp;
           // string _estaCorreo;
           // string _estaDocIdentificacion;

           // _estaCorreo = _pasoParametros.verificoCorreo(Correo.Text);
           // _estaDocIdentificacion = _pasoParametros.verificoDocIdentificacion(TipoDocIdentidad.Text, TipoDocIdentidad.Text);

           // if ((_estaCorreo != " ") && (_estaDocIdentificacion != " "))
           // {
           //     Response.Write("Lo siento ya hay un cliente registrado con el mismo Doc de Identificación y/o Correo");
           // }
           // else
           // {
           //     _resp = _pasoParametros.registroCliente(Direccion1.Text, NumeroDocumento.Text, TipoDocIdentidad.Text, PriNombre.Text,
           //         SegNombre.Text, PriApellido.Text, SegApellido.Text, FechaNac.Text, Correo.Text, Contrasena.Text, PreSeguridad.Text,
           //         RespSeguridad.Text);

           //     if (_resp == true)
           //     {
           //         //   Response.Write("Se ha registrado con éxito");
           //         Response.Redirect("/Interfaz/web/IngresoRecuperacionClave/web_01_bienvenido.aspx");
           //     }
           //     else
           //         Response.Write("No se pudo procesar su solicitud");
           // }
        }
    }
}