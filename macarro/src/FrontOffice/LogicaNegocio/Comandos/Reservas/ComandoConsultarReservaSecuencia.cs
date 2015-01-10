using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaSecuencia : Comando<bool,int>
    {
        public override int Ejecutar(bool parametro)
        {
            try
            {
                IDaoReserva _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva();

                return _daoReservaServicio.ObtenerSecuencia();

            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}