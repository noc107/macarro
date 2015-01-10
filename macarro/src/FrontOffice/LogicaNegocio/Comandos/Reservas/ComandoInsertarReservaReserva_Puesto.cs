using FrontOffice.Dominio.Entidades;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoInsertarReservaReserva_Puesto : Comando<ReservaReserva_Puesto,bool>
    {
        public override bool Ejecutar(ReservaReserva_Puesto parametro)
        {
            try
            {
                IDaoReservaReserva_Puesto _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaReserva_Puesto();

                return _daoReservaServicio.InsertarReservaReserva_PuestoSinInventario(parametro);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}