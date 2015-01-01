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
        TextBox cantidadMinima { get; }
        TextBox nombre { get; }
        TextBox cantidad { get; }
        TextBox descripcion { get; }
        TextBox precioVenta { get; }
        TextBox precioCompra { get; }
        DropDownList proveedor { get; set; }

    }
}
