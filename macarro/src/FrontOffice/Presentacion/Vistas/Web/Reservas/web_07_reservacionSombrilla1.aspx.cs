using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontOffice.Presentacion.Vistas.Web.Reservas
{
    public partial class web_07_reservacionSombrilla1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_reservacionSombrilla.aspx?tipo=2&fecha=" + tb_fecha.Text);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_consultaSombrilla.aspx");
        }
    }
}