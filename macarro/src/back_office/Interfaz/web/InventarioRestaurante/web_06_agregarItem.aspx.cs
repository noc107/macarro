using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using back_office.Logica.InventarioRestaurante;
using back_office.Excepciones.InventarioRestaurante;

namespace back_office.Interfaz.web.InventarioRestaurante
{
    public partial class web_06_agregarItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcedimientosItem _procedimiento = new ProcedimientosItem();
            string[] _proveedores = _procedimiento.verProveedor();
            for (int _contador = 0; _contador < _proveedores.Length; _contador++)
            {
                ListItem oItem = new ListItem(_proveedores[_contador]);
                Proveedores.Items.Add(oItem);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            ProcedimientosItem _procedimiento = new ProcedimientosItem();
            float _precioCompra = float.Parse(tbPrecio2.Text);
            float _precioVenta = float.Parse(tbPrecio.Text);
            int _cantidad = int.Parse(Cantidad.Text);
            int _cantidadMinima = int.Parse(tbCantidadMinima.Text);
            if (_precioVenta < _precioCompra)
            {
                MensajeFallo.Text = "El precio de venta no puede ser menor al precio de compra";
                MensajeFallo.Visible = true;
            }
            else if (_cantidad < _cantidadMinima)
            {
                MensajeFallo.Text = "La cantidad no puede ser menor a la cantidad minima";
                MensajeFallo.Visible = true;
            }
            else 
            {
                try
                {

                    bool _exito = _procedimiento.guardarItem(Nombre.Text, Convert.ToInt32(Cantidad.Text),
                                float.Parse(tbPrecio2.Text), float.Parse(tbPrecio.Text), tbDescripcion.Text, Proveedores.Text,
                                Convert.ToInt32(tbCantidadMinima.Text));

                    if (_exito)
                    {
                     
                        MensajeFallo.Visible = false;
                        MensajeExito.Visible = true;
                        Boton1.Enabled = false;
                    }
                    else
                    {
                        MensajeFallo.Visible = true;
                    }
                }
                catch (ExcepcionAgregarItem)
                {
                    MensajeFallo.Text = "En estos momentos presentamos problemas con la base de datos, por favor intente mas tarde";
                    MensajeFallo.Visible = true;
                }
                catch (Exception) 
                {
                    MensajeFallo.Text = "Su operacion no pudo ser procesada, por favor contacte con el administrador";
                    MensajeFallo.Visible = true;
                }
            }
        }
    }
}