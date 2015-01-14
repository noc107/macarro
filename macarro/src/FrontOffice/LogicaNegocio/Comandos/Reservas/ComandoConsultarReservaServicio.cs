using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaServicio : Comando<string, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                IDaoReservaServicio _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();

                return _daoReservaServicio.ConsultarTodoXCorreo(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}