using FrontOffice.Dominio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Reserva: Entidad
    {
        private int Reserva_id;
        private DateTime Reserva_fecha;
        private string FK_usuario;
        private string FK_estado;
        private ReservaServicio Reserva_Servicio;
        private List<ReservaPuesto> Reserva_Puestos;
        public int reserva_id
        {
            get { return Reserva_id; }
            set { Reserva_id = value; }
        }

        public DateTime reserva_fecha
        {
            get { return Reserva_fecha; }
            set { Reserva_fecha = value; }
        }


        public string fK__usuario
        {
            get { return FK_usuario; }
            set { FK_usuario = value; }
        }

        public string fK_estado
        {
            get { return FK_estado; }
            set { FK_estado = value; }
        }

        public ReservaServicio reserva_Servicio
        {
            get { return Reserva_Servicio; }
            set { Reserva_Servicio = value; }
        }

        public List<ReservaPuesto> reserva_Puesto
        {
            get { return Reserva_Puestos; }
            set { Reserva_Puestos = value; }
        }

        public Reserva()
        {
            Reserva_id = 0;
            Reserva_fecha = System.DateTime.Now;
            FK_usuario = string.Empty;
            FK_estado = string.Empty;
            Reserva_Servicio = (ReservaServicio) FabricaEntidad.ObtenerReservaServicio();
        }

        public Reserva(int _reservaId, DateTime _reservaFecha, string _fkUsuario, string _fkEstado, ReservaServicio _reservaServicio)
        {
            Reserva_id = _reservaId;
            Reserva_fecha = _reservaFecha;
            FK_usuario = _fkUsuario;
            FK_estado = _fkEstado;
            Reserva_Servicio = _reservaServicio;
        }

    }
}