using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Dominio.Fabrica;
using BackOffice.Dominio.Entidades;

namespace BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya
{
    public interface IDaoServiciosPlaya : IDao<Entidad, bool, Entidad>
    {
        Entidad ConsultarServicioCompleto(string parametro);
        List<Entidad> ConsultarServicios(Entidad parametro);
        bool EliminarServicioPlaya(string parametro);
    }
}