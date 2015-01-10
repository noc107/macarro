using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaReservaPuesto_Incio_Fin_Playa : Comando<string[], List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string[] parametro)
        {
            try
            {
                IDaoReservaReserva_Puesto _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva_Puesto();

                return _daoReservaServicio.ConsultarReservaReserva_PuestoXidplayaXinicioXfin(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}