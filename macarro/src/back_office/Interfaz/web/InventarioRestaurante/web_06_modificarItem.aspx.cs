using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_modificarItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("web_06_gestionarInventario.aspx");
        
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("web_06_gestionarInventario.aspx");
        }


        protected void ButtonAceptarModalAumentar_Click(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(tbCantidad.Text.ToString());
            int y = 0;
            if (string.IsNullOrWhiteSpace(TextBoxAumentarCantidad.Text.ToString()))   //No suma null
                y = 0;
                try
                {
                    y = Convert.ToInt32(TextBoxAumentarCantidad.Text.ToString()); //Intenta convertir (no letras)
                }
                catch (FormatException)
                {
                    y = 0;
                }
                finally
                {
                    if (y < 0) //No opera numeros negativos
                        y = 0;
                    x = x + y;
                    tbCantidad.Text = x.ToString();
                    TextBoxAumentarCantidad.Text = "";     //Setea el textbox en vacio
                }
        }


        protected void ButtonCancelarModalAumentar_Click(object sender, EventArgs e)
        {
            TextBoxAumentarCantidad.Text = "";     //Setea el textbox en vacio                
        }

        protected void ButtonAceptarModalRestar_Click(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(tbCantidad.Text.ToString());
            int y = 0;
            if (string.IsNullOrWhiteSpace(TextBoxRestarCantidad.Text.ToString()))   //No resta null
                y = 0;
            try
            {
                y = Convert.ToInt32(TextBoxRestarCantidad.Text.ToString()); //Intenta convertir (no letras)
            }
            catch (FormatException)
            {
                y = 0;
            }
            finally
            {
                if (y < 0) //No opera numeros negativos
                    y = 0;
                if (y > x)
                {
                    tbCantidad.Text = "0";
                    TextBoxRestarCantidad.Text = "";
                }
                else
                {
                    x = x - y;
                    tbCantidad.Text = x.ToString();
                    TextBoxRestarCantidad.Text = "";     //Setea el textbox en vacio
                }
            }
        }

        protected void ButtonCancelarModalRestar_Click(object sender, EventArgs e)
        {
            TextBoxRestarCantidad.Text = "";     //Setea el textbox en vacio                
        }
    }
}