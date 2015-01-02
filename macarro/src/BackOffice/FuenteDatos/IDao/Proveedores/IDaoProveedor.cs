using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.Proveedores
{
    public interface IDaoProveedor : IDao<Entidad,Boolean, Entidad> 
    {
    }
}
