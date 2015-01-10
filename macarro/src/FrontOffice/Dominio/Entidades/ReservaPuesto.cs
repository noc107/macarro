using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class ReservaPuesto : Entidad
    {
        private float ReservaPuesto_precio;
        private int ReservaPuesto_FK_estado;
        private int ReservaPuesto_reserva;
        private int ReservaPuesto_puestoFila;
        private int ReservaPuesto_puestoColumna;
        private int ReservaPuesto_FK_inventario;
        private int ReservaPuesto_FK_playa;
        private string ReservaPuesto_descripcion;
        public float reservaPuesto_precio
        {
            get { return ReservaPuesto_precio; }
            set { ReservaPuesto_precio = value; }
        }
        public int reservaPuesto_FK_estado
        {
            get { return ReservaPuesto_FK_estado; }
            set { ReservaPuesto_FK_estado = value; }
        }
        public int reservaPuesto_reserva
        {
            get { return ReservaPuesto_reserva; }
            set { ReservaPuesto_reserva = value; }
        }
        public int reservaPuesto_puestoFila
        {
            get { return ReservaPuesto_puestoFila; }
            set { ReservaPuesto_puestoFila = value; }
        }
        public int reservaPuesto_puestoColumna
        {
            get { return ReservaPuesto_puestoColumna; }
            set { ReservaPuesto_puestoColumna = value; }
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
        public string reservaPuesto_Descripcion
        {
            get { return ReservaPuesto_descripcion; }
            set { ReservaPuesto_descripcion = value; }
        }
        public ReservaPuesto ()
        {
            ReservaPuesto_precio=0;
            ReservaPuesto_reserva=0;
            ReservaPuesto_puestoFila=0;
            ReservaPuesto_puestoColumna=0;
            ReservaPuesto_FK_inventario=0;
            ReservaPuesto_FK_playa=0;
        }
        public ReservaPuesto(int _reservaPuesto_Precio,int _reservaPuesto_Reserva,int _reservaPuesto_PuestoFila,int _reservaPuesto_PuestoColumna,int reservaPuesto_FK_Inventario,
            int _reservaPuesto_FK_Playa, string _reservaPuesto_Descripcion)
        {
            ReservaPuesto_precio = _reservaPuesto_Precio;
            ReservaPuesto_reserva = _reservaPuesto_Reserva;
            ReservaPuesto_puestoFila = _reservaPuesto_PuestoFila;
            ReservaPuesto_puestoColumna = _reservaPuesto_PuestoColumna;
            ReservaPuesto_FK_inventario = reservaPuesto_FK_Inventario;
            ReservaPuesto_FK_playa = _reservaPuesto_FK_Playa;
            ReservaPuesto_descripcion = _reservaPuesto_Descripcion;
        }
    }
}