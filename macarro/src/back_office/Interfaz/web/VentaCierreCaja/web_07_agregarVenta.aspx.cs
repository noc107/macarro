using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.VentaCierreCaja
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            //llamar al procedimiento que consulta en bd y llena la lista
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("web_03_consultaServicioCompleta.aspx");

            //this.MensajeExito.Text = "Se ha guardado correctamente la cuenta.";
            //this.MensajeExito.CssClass = "MensajeExito Mensaje";
            this.MensajeExito.Visible = true;
            this.TextBoxCliente.Text = "";
        }

        protected void ButtonFacturar_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_07_imprimirFactura.aspx");
        }

        protected void ButtonAgregarServicio_Click(object sender, EventArgs e) 
        {
            //this.MensajeErrorLista.Text = this.ListaServicios.SelectedValue.ToString();
            if(this.ListaServicios.SelectedValue.ToString() == "")
                this.MensajeErrorLista.Visible = true;
            else
                this.MensajeErrorLista.Visible = false;
        }
    }
}