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
        Label nombreVer { set; }
        Label cantidadVer { set; }
        Label descripcionVer { set; }
        Label precioVentaVer { set; }
        Label precioCompraVer { set; }
        Label proveedorVer { set; }
        ListBox actualizaciones { set;}
    }
}
