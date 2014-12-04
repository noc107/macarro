using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Logica.InventarioRestaurante;


namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_agregarItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProcedimientosItem _procedimiento = new ProcedimientosItem();
            bool _exito = _procedimiento.guardarItem(Nombre.Text,Convert.ToInt32(Cantidad.Text),
                        float.Parse(tbPrecio2.Text),float.Parse(tbPrecio.Text),tbDescripcion.Text,Proveedores.Text,
                        Convert.ToInt32(tbCantidadMinima.Text));
            if (_exito)
            {
                MensajeExito.Visible = true;
                Boton1.Enabled = false;
            }
            else
            {
                MensajeFallo.Visible = true;
            }
        }
    }
}