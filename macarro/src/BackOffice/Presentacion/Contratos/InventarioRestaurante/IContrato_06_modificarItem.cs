using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.InventarioRestaurante
{
    public interface IContrato_06_modificarItem : IContratoGeneral
    {
        TextBox Nombre { get; set; }
        TextBox Cantidad { get; set; }
        TextBox Descripcion { get; set; }
        TextBox PrecioVenta { get; set; }
        TextBox PrecioCompra { get; set; }
        DropDownList Proveedor { get; set; }
        TextBox AumentarCantidad { get;  }
        TextBox RestarCantidad { get;  }
    }
}
