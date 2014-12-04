using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.UsuariosInternos
{
    public partial class web_09_asignarRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lstIzquierda.Items.Add("Administrador");
            lstIzquierda.Items.Add("Cliente");
            lstIzquierda.Items.Add("Cajero");
            lstIzquierda.Items.Add("Empleado");

        }
    }
}