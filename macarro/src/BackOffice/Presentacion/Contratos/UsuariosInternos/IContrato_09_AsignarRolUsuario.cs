using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
   public interface IContrato_09_AsignarRolUsuario : IContratoGeneral
    {

         ListBox RolAsignado { get; set;}
         ListBox RolDisponible { get; set;}

    }
}