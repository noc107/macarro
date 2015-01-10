using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.MenuRestaurante
{
    public interface IDaoSeccion : IDao<Entidad, bool, Entidad>
    {
        Entidad ConsultarSeccion(int id);
        //bool AgregarSeccion(Entidad Seccion);
    }
}
