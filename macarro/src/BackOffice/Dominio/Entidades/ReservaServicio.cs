using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class ReservaServicio:Entidad
    {
        private int ReservaServicio_id;
        private string ReservaServicio_Nombre;
        private DateTime ReservaServicio_HoraInicio;
        private DateTime ReservaServicio_HoraFin;
        private int ReservaServicio_Cantidad;
        private int ReservaServicio_Total;
        private int ReservaServicio_FK_Horario;
        private int ReservaServicio_FK_Reserva;

        public int reservaServicio_FK_Reserva
        {
            get { return ReservaServicio_FK_Reserva; }
            set { ReservaServicio_FK_Reserva = value; }
        }

        public int reservaServicio_id
        {
            get { return ReservaServicio_id; }
            set { ReservaServicio_id = value; }
        }

        public string reservaServicio_Nombre
        {
            get { return ReservaServicio_Nombre; }
            set { ReservaServicio_Nombre = value; }
        }

        public DateTime reservaServicio_HoraInicio
        {
            get { return ReservaServicio_HoraInicio; }
            set { ReservaServicio_HoraInicio = value; }
        }

        public DateTime reservaServicio_HoraFin
        {
            get { return ReservaServicio_HoraFin; }
            set { ReservaServicio_HoraFin = value; }
        }

        public int reservaServicio_Cantidad
        {
            get { return ReservaServicio_Cantidad; }
            set { ReservaServicio_Cantidad = value; }
        }

        public int reservaServicio_FK_Horario
        {
            get { return ReservaServicio_FK_Horario; }
            set { ReservaServicio_FK_Horario = value; }
        }

        public int reservaServicio_Total
        {
            get { return ReservaServicio_Total; }
            set { ReservaServicio_Total = value; }
        }


        public ReservaServicio()
        {

            ReservaServicio_id = 0;
            ReservaServicio_HoraInicio = System.DateTime.Now;
            ReservaServicio_HoraFin = System.DateTime.Now;
            ReservaServicio_Cantidad = 0;
            reservaServicio_Total = 0;
            ReservaServicio_FK_Horario = 0;

        }

        public ReservaServicio(int _reservaServicioId, DateTime _reservaHoraInicio, DateTime _reservaHoraFin, int _cantidad, int _total, int _fkHorario, int _fkReserva)
        {
            ReservaServicio_id = _reservaServicioId;
            ReservaServicio_HoraInicio = _reservaHoraInicio;
            ReservaServicio_HoraFin = _reservaHoraFin;
            ReservaServicio_Cantidad = _cantidad;
            ReservaServicio_Total = _total;
            ReservaServicio_FK_Horario = _fkHorario;

        }

    }
}