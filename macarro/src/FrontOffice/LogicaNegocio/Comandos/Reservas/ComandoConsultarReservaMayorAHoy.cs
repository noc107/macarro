using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaMayorAHoy : Comando<string,List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                IDaoReserva _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva();

                return _daoReservaServicio.ConsultarReservasMayorANow(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}