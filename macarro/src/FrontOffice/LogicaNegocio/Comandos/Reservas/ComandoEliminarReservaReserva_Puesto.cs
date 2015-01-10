using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoEliminarReservaReserva_Puesto : Comando<int, bool>
    {
        public override bool Ejecutar(int parametro)
        {
            try
            {
                IDaoReservaReserva_Puesto _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva_Puesto();

                return _daoReservaServicio.EliminarReservaReserva_PuestoXIdReserva(parametro);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}