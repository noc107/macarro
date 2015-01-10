using BackOffice.Dominio; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.UsuariosInternos
{
   public interface IDaoEmpleado:  IDao<Entidad,bool,Entidad>
    {
       List<string> ConsultarRolesEmpleado(int parametro);
    }
}
