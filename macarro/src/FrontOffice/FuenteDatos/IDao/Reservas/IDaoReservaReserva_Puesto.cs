using FrontOffice.Dominio;
using FrontOffice.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReservaReserva_Puesto : IDao<Entidad, Boolean, Entidad>
    {
        bool EliminarReservaReserva_PuestoXIdReserva(int _idReserva);
        bool EliminarReservaReserva_PuestoXIdReservaXFilaXColumna(int[] data);

        bool InsertarReservaReserva_PuestoSinInventario(ReservaReserva_Puesto origen);

        List<Entidad> ConsultarReservaReserva_PuestoXidplayaXidreserva(int[] data);
        List<Entidad> ConsultarReservaReserva_PuestoXidplayaXinicioXfin(string[] data);

    }
}