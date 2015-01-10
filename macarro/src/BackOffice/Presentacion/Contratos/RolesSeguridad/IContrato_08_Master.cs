using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.RolesSeguridad
{
    public interface IContrato_08_Master : IContratoGeneral
    {
        Menu menuMaster { get; set; }
    }
}
