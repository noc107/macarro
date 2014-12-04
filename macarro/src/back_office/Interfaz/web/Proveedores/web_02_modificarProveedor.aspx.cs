using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.Proveedores
{
    public partial class Xweb_02_modificarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
        }
    }
}