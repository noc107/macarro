using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio;

namespace BackOffice.FuenteDatos.IDao.IngresoRecuperacionClave
{
    public interface IDaoIniciarSesion : IDao<Entidad, bool, Entidad>
    {
        Entidad verificarDatos(Entidad parametro);
        
        Entidad verificarDatosPersona(Entidad parametro);
    }
}