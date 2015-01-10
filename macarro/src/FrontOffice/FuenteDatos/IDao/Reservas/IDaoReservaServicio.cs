using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReservaServicio : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarReservaServicioXCorreo(string _correo);

    }
}