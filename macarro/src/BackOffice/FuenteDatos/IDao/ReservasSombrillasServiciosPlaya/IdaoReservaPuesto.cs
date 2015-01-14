using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya
{
    public interface IdaoReservaPuesto : BackOffice.FuenteDatos.IDao.IDao < Entidad, Boolean, List<Entidad>>
    {
    }
}