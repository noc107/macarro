using BackOffice.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.InventarioRestaurante
{
    public interface IDao_06_inventarioRestaurante : IDao<Entidad, bool, Entidad>
    {
        DataTable VerRazonesSocialesBD();
    }
}
