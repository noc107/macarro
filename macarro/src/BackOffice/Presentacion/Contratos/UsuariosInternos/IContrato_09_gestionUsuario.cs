using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BackOffice.Presentacion.Contratos.UsuariosInternos
{
   public interface IContrato_09_gestionUsuario:IContratoGeneral
    {
        TextBox   BusquedaUsuario     {get; set;}
        GridView  TablaDatosUsuarios  {get;}
    }
}
