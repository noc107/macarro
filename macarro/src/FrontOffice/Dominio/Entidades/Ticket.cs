﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Ticket: Entidad
    {
        private int _id;
        private DateTime _entrada; 
        private DateTime _salida;
        private string _placa;
        private int _fkEstado;
        private int _fkEstacionamiento;
        private string _estado;

    

     


        public Ticket() 
        {
          _id = 0;
            _entrada = DateTime.MinValue;
           _salida = DateTime.MinValue;
            _placa = null;
        }


        public Ticket(int id, DateTime entrada, DateTime salida, string placa,int fkEstacionamiento, string estado)
        {
            _id= id;
           _entrada = entrada;
           _salida = salida;
           _placa = placa;
           _fkEstacionamiento = fkEstacionamiento;
           _estado = estado;
        
        }
        public Ticket(int id, DateTime entrada ,string placa, int fkEstacionamiento, string estado)
        {
            _id = id;
            _entrada = entrada;
            _placa = placa;
            _fkEstacionamiento = fkEstacionamiento;
            _estado = estado;

        }

        public Ticket(string placa) 
        
        {
            _placa = placa;
            _id = 0;   
            _fkEstado = 20;
            _fkEstacionamiento=1;
        }

        public Ticket(string placa, int fkEstado)
        {
            _placa = placa;
            _id = 0;
            _fkEstado = fkEstado;
            _fkEstacionamiento = 1;
        }
        #region Propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public DateTime Entrada
        {
            get { return _entrada; }
            set { _entrada = value; }
        }

        public DateTime Salida
        {
            get { return _salida; }
            set { _salida = value; }
        }

        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        public int FkEstacionamiento
        {
            get { return _fkEstacionamiento; }
            set { _fkEstacionamiento = value; }
        }

        public int FkEstado
        {
            get { return _fkEstado; }
            set { _fkEstado = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion 


    }
}