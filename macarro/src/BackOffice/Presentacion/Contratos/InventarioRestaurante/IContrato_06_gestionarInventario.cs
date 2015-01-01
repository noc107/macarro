using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.InventarioRestaurante
{
    public interface IContrato_06_gestionarInventario : IContratoGeneral
    {
        GridView gridInventario { set; }
        TextBox buscar { get; }
        DropDownList listaBuscar { get; set; }
    }
}
