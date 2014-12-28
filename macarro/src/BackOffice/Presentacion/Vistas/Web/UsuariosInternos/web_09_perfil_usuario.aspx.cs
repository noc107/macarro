using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Vistas.Web.UsuariosInternos
{
    public partial class web_09_perfil_usuario : System.Web.UI.Page
    {
        string _correoS = string.Empty;
        string _docIdentidadS = string.Empty;
        string _primerNombreS = string.Empty;
        string _primerApellidoS = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            VariableSesion();
            if ((_correoS != null) && (_docIdentidadS != null))
            {
            }
            else
                Server.Transfer("../IngresoRecuperacionClave/web_01_inicioSesionA.aspx", false);
        }

        private void VariableSesion()
        {
            try
            {
                _correoS = (string)(Session["correo"]);
                _docIdentidadS = (string)(Session["docIdentidad"]);
                _primerNombreS = (string)(Session["primerNombre"]);
                _primerApellidoS = (string)(Session["primerApellido"]);
            }
            catch (Exception ex)
            {
                //MensajeErrores.Text = "No se han podido cargar los datos de sesion";
                //MensajeErrores.Visible = true;
                //ex.GetType();
            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_09_perfilUsuario.aspx"); 
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            validatorfechanac.MinimumValue = DateTime.Now.AddYears(-65).ToString("dd/MM/yyyy");
            validatorfechanac.MaximumValue = DateTime.Now.AddYears(-18).ToString("dd/MM/yyyy");
        }
    }
}