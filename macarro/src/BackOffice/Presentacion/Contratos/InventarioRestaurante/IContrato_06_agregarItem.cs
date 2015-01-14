using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.InventarioRestaurante
{
    public interface IContrato_06_agregarItem : IContratoGeneral
    {
        TextBox CantidadMinima { get; }
        TextBox Nombre { get; }
        TextBox Cantidad { get; }
        TextBox Descripcion { get; }
        TextBox PrecioVenta { get; }
        TextBox PrecioCompra { get; }
        DropDownList Proveedor { get; set; }

    }
}
