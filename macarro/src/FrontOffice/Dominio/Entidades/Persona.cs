﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Persona:Entidad
    {
        private int _id;
        private string _cedula;
        private string _tipoDocumento;
        private string _nombre;
        private string _segundoNombre;
        private string _apellido;
        private string _segundoApellido;
        private DateTime _fechaNacimiento;
        private string _telefono;
        private string _nombreLugar;
        private Usuario _usuarioAsociado;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string SegundoNombre
        {
            get { return _segundoNombre; }
            set { _segundoNombre = value; }
        }

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string SegundoApellido
        {
            get { return _segundoApellido; }
            set { _segundoApellido = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }


        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string NombreLugar
        {
            get { return _nombreLugar; }
            set { _nombreLugar = value; }
        }

        public Usuario UsuarioAsociado
        {
            get { return _usuarioAsociado; }
            set { _usuarioAsociado = value; }
        }

        public Persona()
        {
            _id = 0;
            _cedula = string.Empty;
            _nombre = string.Empty;
            _segundoNombre = string.Empty;
            _apellido = string.Empty;
            _segundoApellido = string.Empty;
            _fechaNacimiento = System.DateTime.Now;
            _telefono = string.Empty;

            _nombreLugar = string.Empty;
        }

        public Persona(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;

        }

        public Persona(int id, string cedula, string tipoDoc, string nombre, string segNombre, string apellido, string segApellido, DateTime fechaNac, string telefono, string nombreLugar, Usuario usuario)
        {
            _id = id;
            _cedula = cedula;
            _tipoDocumento = tipoDoc;
            _nombre = nombre;
            _segundoNombre = segNombre;
            _apellido = apellido;
            _segundoApellido = segApellido;
            _fechaNacimiento = fechaNac;
            _nombreLugar = nombreLugar;
            _telefono = telefono;
            _usuarioAsociado = usuario;

        }
    }
}