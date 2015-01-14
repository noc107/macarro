using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaServicioXID : Comando<int, Entidad>
    {
        public override Entidad Ejecutar(int parametro)
        {
            try
            {
                IDaoReservaServicio _daoReservaServicio;

                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();

                return _daoReservaServicio.ConsultarXId(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}