using BackOffice.Dominio;
using BackOffice.FuenteDatos.IDao.ReservasSombrillasServiciosPlaya;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.LogicaNegocio.Comandos.ReservasSombrillasServiciosPlaya
{
    public class ComandoConsultarReservaServicio : Comando<int, Entidad>
    {

        public override Entidad Ejecutar ( int _parametro )
        {
            IdaoReservaServicio _reserva = BackOffice.FuenteDatos.Fabrica.FabricaDao.ObtenerReservaServicio();
            return _reserva.ConsultarXId(_parametro);
        }
    }
}