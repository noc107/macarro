using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    interface IContrato_05_gestionarProducto : IContratoGeneral
    {
        GridView gestionarProducto { get; }
    }
}
