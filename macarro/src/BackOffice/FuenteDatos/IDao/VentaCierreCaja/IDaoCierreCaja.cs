using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.FuenteDatos.IDao.VentaCierreCaja
{
    public interface IDaoCierreCaja : IDao<Entidad, Boolean, Entidad>
    {

        Entidad consultarCierreCajaDia(string[] parametro);
        Entidad consultarCierreCajaMes(string[] parametro);

    }
}
