using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    public interface IContrato_05_AgregarSeccion : IContratoGeneral
    {
        TextBox nombre { get; set; }
        TextBox descripcion { get; set; }
    }
}
