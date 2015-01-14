using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.VentaCierreCaja
{
    public interface IDaoImprimirFactura : IDao<Entidad, bool, Entidad>
    {

        Entidad obtenerDatosBasicosFactura(int _parametro);
        Entidad obtenerDatosClienteFactura(int _parametro);
        DataTable obtenerLineasFactura(int _parametro);

    }
}
