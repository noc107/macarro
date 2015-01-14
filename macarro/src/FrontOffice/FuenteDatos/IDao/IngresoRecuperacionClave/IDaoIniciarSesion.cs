using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontOffice.Dominio;

namespace FrontOffice.FuenteDatos.IDao.IngresoRecuperacionClave
{
    public interface IDaoIniciarSesion : IDao<Entidad, bool, Entidad>
    {
        Entidad verificarDatos(Entidad parametro);
        
        Entidad verificarDatosPersona(Entidad parametro);
    }
}