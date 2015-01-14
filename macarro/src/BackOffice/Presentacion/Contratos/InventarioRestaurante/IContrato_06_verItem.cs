using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.InventarioRestaurante
{
    public interface IContrato_06_verItem : IContratoGeneral
    {
        Label NombreVer { set; }
        Label CantidadVer { set; }
        Label DescripcionVer { set; }
        Label PrecioVentaVer { set; }
        Label PrecioCompraVer { set; }
        Label ProveedorVer { set; }
        ListBox Actualizaciones { set;}
    }
}
