using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Estacionamiento : Entidad
    {
        private int _id;
        private string _nombre;
        private int _capacidad;
        private float _tarifa;
        private float _ticketPerdido;
        private int _estado;
        private int _disponible;

     
       

       


        public Estacionamiento()
        {
            _id = 0;
            _nombre = null;
            _capacidad = 0;
            _tarifa = 0;
            _ticketPerdido = 0;

        }


        public Estacionamiento(int id, string nombre, int capacidad, float tarifa, float ticketPerdido , int estado, int disponible)
        {
            _id = id;
            _nombre= nombre;
            _capacidad = capacidad;
            _tarifa = tarifa;
            _ticketPerdido = ticketPerdido;
              _estado = estado;
              _disponible = disponible;
        

        }

        #region Propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }


        public float Tarifa
        {
            get { return _tarifa; }
            set { _tarifa = value; }
        }


        public float TicketPerdido
        {
            get { return _ticketPerdido; }
            set { _ticketPerdido = value; }
        }

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        #endregion 

    }
}