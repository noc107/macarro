using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Membresia
{
    public interface IDaoMembresia : IDao<Entidad, Boolean, Entidad>
    {
        Entidad ConsultarMembresiaXIdUsuario(int Id);

    }
}