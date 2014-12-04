using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.UsuariosInternos
{
    public partial class web_09_consultarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void volver_consultar(object sender, EventArgs e)
        {
            Response.Redirect("web_09_gestionUsuario.aspx"); 
        }
    }
}