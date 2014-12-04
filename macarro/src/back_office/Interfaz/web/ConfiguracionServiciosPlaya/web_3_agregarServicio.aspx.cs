using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.ConfiguracionServiciosPlaya
{
    public partial class web_3_agregarServicio : System.Web.UI.Page
    {

        /*protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('aaaaaa');", true);
        }*/

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            this.borrarCampos();
        }

        private void borrarCampos()
        {
           /* this.inputNombreServcio.Text = "";
            this.inputDescripcion.Text = "";
            this.inputCantidad.Text = "";
            this.inputCapacidad.Text = "";
            this.inputCosto.Text = "";
            this.TextBoxCategoriaOtro.Text = "";
            this.Dropdownlist1.SelectedIndex = 0;
            this.Dropdownlist2.SelectedIndex = 0;*/
        }
    }
}