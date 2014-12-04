using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Usuario
    {
        #region Atributos

        private string _correo;
        private string _contrasena;
        private string _tipo;
        private string _estado;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;
        private string _preguntaSeguridad;
        private string _respuestaSeguridad;
        private int _fkPersona;

        #endregion

        #region Constructores

        public Usuario()
        { 
            _correo = string.Empty;
            _contrasena = string.Empty;
            _tipo = string.Empty;
            _estado = string.Empty;
            _fechaIngreso = new DateTime();
            _fechaEgreso = new DateTime();
            _preguntaSeguridad = string.Empty;
            _respuestaSeguridad = string.Empty;
            _fkPersona = 0;
        }

        public Usuario(string correo, string contrasena, string tipo, string estado, DateTime fechaIngreso, 
            DateTime fechaEgreso, string preguntaSeguridad, string respuestaSeguridad, int fkPersona)
        {
            _correo = correo;
            _contrasena = contrasena;
            _tipo = tipo;
            _estado = estado;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;
            _preguntaSeguridad = preguntaSeguridad;
            _respuestaSeguridad = respuestaSeguridad;
            _fkPersona = fkPersona;
        }

        #endregion

        #region Getters y Setters

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

        public string TipoUsuario
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public string EstadoUsuario
        {
            get { return _estado; }
            set { _estado = value; }
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

        public string PreguntaSecreta
        {
            get { return _preguntaSeguridad; }
            set { _preguntaSeguridad = value; }
        }

        public string RespuestaSecreta
        {
            get { return _respuestaSeguridad; }
            set { _respuestaSeguridad = value; }
        }

        public int FkPersona
        {
            get { return _fkPersona; }
            set { _fkPersona = value; }
        }

        #endregion
    }
}