using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.InventarioRestaurante
{
    interface IContrato_06_modificarItem : IContratoGeneral
    {
        TextBox nombre { get; set; }
        TextBox cantidad { get; set; }
        TextBox descripcion { get; set; }
        TextBox precioVenta { get; set; }
        TextBox precioCompra { get; set; }
        DropDownList proveedor { get; set; }
        TextBox aumentarCantidad { get; set; }
        TextBox restarCantidad { get; set; }
    }
}
