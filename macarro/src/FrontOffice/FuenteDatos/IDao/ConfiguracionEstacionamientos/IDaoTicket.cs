using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.ConfiguracionEstacionamientos
{
    public interface IDaoTicket : IDao<Entidad, Boolean, Entidad>
    
    {
         Entidad VerificarXplaca(string placa);
         Boolean ModificarXticket(Entidad ticket);
         Boolean ModificarXplaca(Entidad parametro);
    }
}