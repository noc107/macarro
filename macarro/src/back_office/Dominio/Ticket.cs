using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using back_office.Datos;

namespace back_office.Dominio
{
    public class Ticket
    {
        private int _id;
        private DateTime _horaEntrada;
        private DateTime _horaSalida;
        private String _placa;
        private OperacionesBD _bd;

        public Ticket() 
        { 
        
        }

        public Ticket(int id, DateTime horaEntrada, DateTime horaSalida, string placa) 
        {
            this._id = id;
            this._horaEntrada = horaEntrada;
            this._horaSalida = horaSalida;
            this._placa = placa;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime HoraEntrada
        {
            get { return _horaEntrada; }
            set { _horaEntrada = value; }
        }
        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }
        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }
        
        public OperacionesBD Bd
        {
            get { return _bd; }
            set { _bd = value; }
        }

    }
}