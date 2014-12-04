using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Datos;

namespace back_office.Dominio
{
    public class Estacionamiento
    {
        private int _id;
        private String _nombre;
        private int _capacidad;
        private float _tarifa;
        private float _tarifa_ticketPerdido;
        private String _estado;
        private OperacionesBD _bd;

        public Estacionamiento() 
        { 
        
        }

        public Estacionamiento(int id, String nombre, int capacidad, float tarifa,  float tarifa_ticketPerdido, String estado, OperacionesBD bd)
        {
            this._id=id;
            this._nombre = nombre;
            this._capacidad = capacidad;
            this._tarifa = tarifa;
            this._tarifa_ticketPerdido = tarifa_ticketPerdido;
            this._estado = estado;

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public String Nombre
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
        public float Tarifa_ticketPerdido
        {
              get { return _tarifa_ticketPerdido; }
              set { _tarifa_ticketPerdido = value; }
        }
        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public OperacionesBD Bd
        {
            get { return _bd; }
            set { _bd = value; }
        }

    }
}