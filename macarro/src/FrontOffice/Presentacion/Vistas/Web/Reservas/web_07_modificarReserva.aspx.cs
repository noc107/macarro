using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_modificarReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_consultaReserva.aspx");
        }

        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_consultaReserva.aspx");
        }
    }
}