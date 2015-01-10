using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoEliminarReservaReserva : Comando<int, bool>
    {
        public override bool Ejecutar(int parametro)
        {
            try
            {
                IDaoReserva _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva();

                return _daoReservaServicio.EliminarReserva(parametro);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}