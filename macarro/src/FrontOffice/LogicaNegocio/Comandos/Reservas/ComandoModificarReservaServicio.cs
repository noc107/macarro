using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas 
{
    public class ComandoModificarReservaServicio : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoReservaServicio _daoReservaServicio;
                _daoReservaServicio = FabricaDao.ObtenerDaoReservaServicio();

                return _daoReservaServicio.Modificar(parametro);


            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}