using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReservaPlaya : IDao<Entidad, Boolean, Entidad>
    {
        Entidad ConsultarReservaPlayaXid(int _playaid);
    }
}