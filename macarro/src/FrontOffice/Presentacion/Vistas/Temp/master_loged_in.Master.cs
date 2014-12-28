using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace front_office.view.temp
{
    public partial class master_loged_in : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Cerrar_Sesion(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Presentacion/Vistas/Web/inicio_no_logeado.aspx");
        }
    }
}