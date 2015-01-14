using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Dominio.Entidades
{
    public class Usuario    :   Entidad
    {
        private int _id;
        private string _correo;
        private string _contrasena;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;
        private string _tipoUsuario;
        private string _estatus;
        //private List<Rol> _cargos;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }


        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }


        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }


        public DateTime FechaEgreso
        {
            get { return _fechaEgreso; }
            set { _fechaEgreso = value; }
        }


        public string TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }


        public string Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        //public List<Rol> Cargos
        //{
        //    get { return _cargos; }
        //    set { _cargos = value; }
        //} 

        public Usuario()
        {
            _id = 0;
            _correo = string.Empty;
            _contrasena = string.Empty;
            _fechaEgreso = System.DateTime.Now;
            _tipoUsuario = string.Empty;
            _estatus = string.Empty;
            _fechaIngreso = System.DateTime.Now;
            //_cargos = null;

        }

        public Usuario(string estatus, string correo, DateTime fechaIngreso, DateTime fechaEgreso)
        {
            _estatus = estatus;
            _correo = correo;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;

        }

        public Usuario(int id, string correo, string contrasena, DateTime fechaIngreso, DateTime fechaEgreso, string tipoUsuario, string estatus/*, List<Rol> cargos*/)
        {
            _id = id;
            _correo = correo;
            _contrasena = contrasena;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;
            _tipoUsuario = tipoUsuario;
            _estatus = estatus;
            //_cargos = cargos;
        }

        public Usuario(string correo, string contrasena)
        {
            _correo = correo;
            _contrasena = contrasena;

        }
    }
}