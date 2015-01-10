using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaPuesto : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int parametro)
        {
            try
            {
                IDaoReservaPuesto _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaPuesto();

                return _daoReservaServicio.ConsultarReservaPlayaPuestoXidPlaya(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}