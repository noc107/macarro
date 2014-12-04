using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.Proveedores
{
    public partial class web_02_agregarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Label13.Text = "Los datos se han registrado satisfactoriamente.";
        //Label13.Attributes["style"] = "color:green; font-weight:bold;";
        //Label13.Visible = true;
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_02_gestionarProveedores.aspx");
        }
    }
}