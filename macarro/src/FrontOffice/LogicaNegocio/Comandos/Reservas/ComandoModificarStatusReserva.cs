using FrontOffice.Dominio;
using FrontOffice.FuenteDatos.Fabrica;
using FrontOffice.FuenteDatos.IDao.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.LogicaNegocio.Comandos.Reservas
{
    public class ComandoModificarStatusReserva :Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                IDaoReserva _daoReserva;

                _daoReserva= FabricaDao.ObtenerDaoReservaReserva();

                return _daoReserva.ModificarStatusReserva(parametro);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}