using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.MenuRestaurante
{
    public interface IContrato_05_GestionarSeccion : IContratoGeneral
    {
        GridView gestionarSeccion { get; set; }
    }
}
