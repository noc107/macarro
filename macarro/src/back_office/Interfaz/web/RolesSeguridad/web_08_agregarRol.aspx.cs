using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.RolesSeguridad
{
    public partial class Agregar_Rol : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Aceptar_Click(object sender, EventArgs e)
        {

            LabelMensaje.Text = "El ítem ha sido creado satisfactoriamente";
            LabelMensaje.CssClass = "MensajeExito";
            LabelMensaje.Visible = true;
            
        }

        
    }
}