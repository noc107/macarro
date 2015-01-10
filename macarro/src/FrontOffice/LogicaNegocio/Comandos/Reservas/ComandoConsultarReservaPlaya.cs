using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaPlaya : Comando<int, Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoReservaPlaya _daoReservaPlaya;
                _daoReservaPlaya = FabricaDao.ObtenerDaoReservaPlaya();
                return _daoReservaPlaya.ConsultarReservaPlayaXid(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}