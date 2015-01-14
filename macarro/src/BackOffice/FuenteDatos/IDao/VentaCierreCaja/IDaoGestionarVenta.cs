using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.IDao.VentaCierreCaja
{
    public interface IDaoGestionarVenta : IDao<Entidad, bool, Entidad>
    {

        DataTable ConsultarFacturas(string[] parametros);
        int EliminarFacturas(string parametros);
    }
}