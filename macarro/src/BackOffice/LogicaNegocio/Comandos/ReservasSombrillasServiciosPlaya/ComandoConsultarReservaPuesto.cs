using BackOffice.Dominio;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya
{
    public class ComandoConsultarReservaPuesto : Comando<int, List<Entidad>>
    {
        public override List<Entidad> Ejecutar ( int _parametro )
        {
            IdaoReservaPuesto _reserva = BackOffice.FuenteDatos.Fabrica.FabricaDao.ObtenerReservaPuesto();
            return _reserva.ConsultarXId(_parametro);
        }
    }
}