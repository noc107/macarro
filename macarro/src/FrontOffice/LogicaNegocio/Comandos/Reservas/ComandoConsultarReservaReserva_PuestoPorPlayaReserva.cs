using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoConsultarReservaReserva_PuestoPorPlayaReserva : Comando<int[], List<Entidad>>
    {
        public override List<Entidad> Ejecutar(int[] parametro)
        {
            try
            {
                IDaoReservaReserva_Puesto _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva_Puesto();

                return _daoReservaServicio.ConsultarReservaReserva_PuestoXidplayaXidreserva(parametro);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}