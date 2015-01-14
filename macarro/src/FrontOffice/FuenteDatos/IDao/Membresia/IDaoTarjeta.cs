using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Membresia
{
    public interface IDaoTarjeta : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarTarjetaXIdUsuario(int Id);

    }
}