using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReserva : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarReservasMayorANow(string _persona);
        bool EliminarReserva(int _reservaid);

        int ObtenerSecuencia();
        bool InsertarReservaSinSecuencia(string[] data);
        Boolean ModificarStatusReserva(Entidad parametro);
    }
}