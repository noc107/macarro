using FrontOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.FuenteDatos.IDao.Reservas
{
    public interface IDaoReservaServicio : IDao<Entidad, Boolean, Entidad>
    {
        List<Entidad> ConsultarTodoXCorreo(string _correo);
        int ConsultarCantidadServiciosDisponibles(string[] _horario);

        List<string> ConsultarServicios();
        int VerificarHorario(string[] _horario);

    }
}