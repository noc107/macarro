using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoInsertarReservaSinSecuencia : Comando<string[],bool>
    {
        public override bool Ejecutar(string[] parametro)
        {
            try
            {
                IDaoReserva _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva();

                return _daoReservaServicio.InsertarReservaSinSecuencia(parametro);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}