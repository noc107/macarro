using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservaServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("web_07_consultaReserva.aspx");
        }
    }
}