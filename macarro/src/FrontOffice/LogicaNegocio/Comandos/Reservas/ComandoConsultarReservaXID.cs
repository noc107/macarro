using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaXID : Comando<string, Entidad>
    {
        public override Entidad Ejecutar(string parametro)
        {
            try
            {
                IDaoReserva _daoReserva;

                _daoReserva = FabricaDao.ObtenerDaoReservaReserva();

                return _daoReserva.ConsultarXId(Convert.ToInt32(parametro));

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}