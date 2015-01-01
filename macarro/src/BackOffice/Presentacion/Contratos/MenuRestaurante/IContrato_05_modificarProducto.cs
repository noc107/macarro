using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    interface IContrato_05_modificarProducto : IContratoGeneral
    {
        TextBox nombre { get; }
        TextBox descripcion { get; }
        TextBox precio { get; }
        DropDownList seccion { get; set; }
        Button btnModoficar { get; }
    }
}
