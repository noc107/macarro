using BackOffice.Dominio;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya
{
    public class ComandoModificarReserva : Comando<Entidad, Boolean>
    {

        public override Boolean Ejecutar ( Entidad _parametro )
        {
            IdaoReserva _reserva = BackOffice.FuenteDatos.Fabrica.FabricaDao.ObtenerReserva ();
            return _reserva.Modificar(_parametro);
        }
    }
}