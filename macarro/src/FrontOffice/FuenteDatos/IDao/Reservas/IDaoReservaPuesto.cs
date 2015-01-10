using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReservaPuesto : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarReservaPlayaPuestoXidPlaya(int _playaid);

    }
}