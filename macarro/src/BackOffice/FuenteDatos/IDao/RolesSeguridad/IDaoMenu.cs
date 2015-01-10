using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.FuenteDatos.IDao.RolesSeguridad
{
    public interface IDaoMenu : IDao<string, Menu, bool>
    {
        Menu ConsultarMenuMaster(string usuario);
        string ListaIdsAccionesUsuario(string usuario);
        List<string> ListaUrlAccionesUsuario(string usuario);
        List<string> ListaAccionesUsuario(string usuario);
    }
}
