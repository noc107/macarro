using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.ConfiguracionServiciosPlaya
{
    public partial class web_03_modificarServiciosPlaya : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
        }

        protected void AceptarBoton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("web_03_consultaServicio.aspx");
            }
            else 
            {
                labelHorario.Text = "asdasd";
            }
        }

        protected void CancelarBoton_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_03_consultaServicio.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            args.IsValid = false;
        }
   
    }
}