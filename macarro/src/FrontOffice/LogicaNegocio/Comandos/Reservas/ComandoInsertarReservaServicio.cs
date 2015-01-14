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
    public class ComandoInsertarReservaServicio: Comando<Entidad,bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                Reserva _r = (Reserva) parametro;
                IDaoReservaServicio _daoReservaServicio;
                IDaoReserva _daoReserva;

                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();
                _daoReserva = FabricaDao.ObtenerDaoReservaReserva();

                _r.reserva_id = _daoReserva.ObtenerSecuencia();
                _r.reserva_Servicio.reservaServicio_FK_Reserva = _r.reserva_id;

                _daoReserva.Agregar(_r);
                _daoReservaServicio.Agregar(_r.reserva_Servicio);

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}