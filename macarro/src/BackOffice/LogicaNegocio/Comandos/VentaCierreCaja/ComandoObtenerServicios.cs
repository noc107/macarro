using BackOffice.Dominio;
using BackOffice.FuenteDatos.Fabrica;
using BackOffice.FuenteDatos.IDao.VentaCierreCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.VentaCierreCaja
{
    public class ComandoObtenerServicios:Comando<string,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            IDaoFacturacion _daoFacturacion = FabricaDao.ObtenerDaoFacturacion();
            return _daoFacturacion.ConsultarDetalleServicio(parametro);
        }
    }
} 