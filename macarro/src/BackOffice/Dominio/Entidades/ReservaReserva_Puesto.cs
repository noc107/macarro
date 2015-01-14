using BackOffice.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Dominio.Entidades
{
    public class ReservaReserva_Puesto : Entidad
    {
        private int ReservaPuesto_id;
        private DateTime ReservaPuesto_fecha;
        private int ReservaPuesto_FK_reserva;
        private int ReservaPuesto_FK_puestoFila;
        private int ReservaPuesto_FK_puestoColumna;
        private int ReservaPuesto_FK_inventario;
        private int ReservaPuesto_FK_playa;

        public int reservaPuesto_id
        {
            get { return ReservaPuesto_id; }
            set { ReservaPuesto_id = value; }
        }
        public DateTime reservaPuesto_fecha
        {
            get { return ReservaPuesto_fecha; }
            set { ReservaPuesto_fecha = value; }
        }
        public int reservaPuesto_FK_reserva
        {
            get { return ReservaPuesto_FK_reserva; }
            set { ReservaPuesto_FK_reserva = value; }
        }
        public int reservaPuesto_FK_puestoFila
        {
            get { return ReservaPuesto_FK_puestoFila; }
            set { ReservaPuesto_FK_puestoFila = value; }
        }
        public int reservaPuesto_FK_puestoColumna
        {
            get { return ReservaPuesto_FK_puestoColumna; }
            set { ReservaPuesto_FK_puestoColumna = value; }
        }
        public int reservaPuesto_FK_inventario
        {
            get { return ReservaPuesto_FK_inventario; }
            set { ReservaPuesto_FK_inventario = value; }
        }
        public int reservaPuesto_FK_playa
        {
            get { return ReservaPuesto_FK_playa; }
            set { ReservaPuesto_FK_playa = value; }
        }

        public ReservaReserva_Puesto()
        {

        }
        public ReservaReserva_Puesto(int reservaPuesto_id,DateTime reservaPuesto_fecha,int reservaPuesto_FK_reserva,int reservaPuesto_FK_puestoFila, int reservaPuesto_FK_puestoColumna, 
            int reservaPuesto_FK_inventario,int reservaPuesto_FK_playa)
        {
            ReservaPuesto_id = reservaPuesto_id;
            ReservaPuesto_fecha = reservaPuesto_fecha;
            ReservaPuesto_FK_reserva = reservaPuesto_FK_reserva;
            ReservaPuesto_FK_puestoFila = reservaPuesto_FK_puestoFila;
            ReservaPuesto_FK_puestoColumna = reservaPuesto_FK_puestoColumna;
            ReservaPuesto_FK_playa = reservaPuesto_FK_playa;
        }
    }
}