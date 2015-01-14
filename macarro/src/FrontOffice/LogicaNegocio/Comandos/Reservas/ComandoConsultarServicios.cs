using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarServicios : Comando<string,List<string>>
    {
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                IDaoReservaServicio _daoReservaServicio;

                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();

                return _daoReservaServicio.ConsultarServicios();

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}