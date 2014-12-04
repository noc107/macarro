using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace back_office.Interfaz.web.ReservasSombrillasServiciosPlaya
{
    public partial class web_07_editarReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_confirmacionReserva.aspx");
        }
    }
}


