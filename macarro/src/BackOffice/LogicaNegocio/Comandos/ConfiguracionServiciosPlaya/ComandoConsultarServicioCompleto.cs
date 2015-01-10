using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.ConfiguracionServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ConfiguracionServiciosPlaya
{
    public class ComandoConsultarServicioCompleto : Comando<string, Entidad>
    {
        public override Entidad Ejecutar(string parametro)
        {
            IDaoServiciosPlaya _daoServiciosPlaya;
            _daoServiciosPlaya = FabricaDao.ObtenerDaoServiciosPlaya();
            return _daoServiciosPlaya.ConsultarServicioCompleto(parametro);
        }
    }
}