using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.RolesSeguridad
{
    public partial class web_08_editarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_08_gestionarRoles.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            LabelMensaje.Text = "El ítem ha sido modificado satisfactoriamente";
            LabelMensaje.CssClass = "MensajeExito";
            LabelMensaje.Visible = true;
        }
    }

}