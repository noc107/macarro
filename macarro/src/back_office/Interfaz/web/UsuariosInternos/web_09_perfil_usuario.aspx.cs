using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.UsuariosInternos
{
    public partial class web_09_perfil_usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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