using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.MenuRestaurante
{
    public interface IDaoPlato : IDao<Entidad, bool, Entidad>
    {
        Entidad ConsultarPlato(int id);
        //bool AgregarPlato(Entidad Plato);
    }
}
