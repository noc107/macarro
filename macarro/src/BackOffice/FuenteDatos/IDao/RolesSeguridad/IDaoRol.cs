using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.RolesSeguridad
{
    public interface IDaoRol : IDao<Entidad, bool, Entidad>
    {
        Int64 ConsultarSecuencia();
        List<Entidad> ConsultarRol(Entidad rol);
        bool EliminarRol(Entidad rol);
        
    }
}
