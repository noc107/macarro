using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarCantidadServiciosDisponibles : Comando<string[], int>
    {
        public override int Ejecutar(string[] parametro)
        {
            try
            {
                IDaoReservaServicio _daoReservaServicio;

                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();

                return _daoReservaServicio.ConsultarCantidadServiciosDisponibles(parametro);

            }
            catch (Exception e)
            {
                return -1000;
            }
        }

    }
}