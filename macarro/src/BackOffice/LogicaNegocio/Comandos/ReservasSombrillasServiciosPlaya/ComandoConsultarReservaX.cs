using BackOffice.Dominio;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya
{
    public class ComandoConsultarReservaX : Comando<int, Entidad>
    {
        public override Entidad Ejecutar ( int _parametro )
        {
            IdaoReserva _reserva = BackOffice.FuenteDatos.Fabrica.FabricaDao.ObtenerReserva ();
            return _reserva.ConsultarXId( _parametro );
        }
    }
}