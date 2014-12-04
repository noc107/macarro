using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_office.Dominio
{
    public class Persona
    {
        #region Atributos

        private int _docIdentidad;
        private string _tipoDocIdentidad;
        private string _primerNombre;
        private string _segundoNombre;
        private string _primerApellido;
        private string _segundoApellido;
        private DateTime _fechaNacimiento;
        private int _fkLugar;

        #endregion

        #region Constructores

        public Persona()
        { 
            _docIdentidad = 0;
            _tipoDocIdentidad = string.Empty;
            _primerNombre = string.Empty;
            _segundoNombre = string.Empty;
            _primerApellido = string.Empty;
            _segundoApellido = string.Empty;
            _fechaNacimiento = new DateTime();
            _fkLugar = 0;
        }

        public Persona(int docIdentidad, string tipoDocIdentidad, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, DateTime fechaNacimiento, int fkLugar)
        {
            _docIdentidad = docIdentidad;
            _tipoDocIdentidad = tipoDocIdentidad;
            _primerNombre = primerNombre;
            _segundoNombre = segundoNombre;
            _primerApellido = primerApellido;
            _segundoApellido = segundoApellido;
            _fechaNacimiento = fechaNacimiento;
            _fkLugar = fkLugar;
        }

        #endregion

        #region Getters y Setters

        public int DocIdentidad
        {
            get { return _docIdentidad; }
            set { _docIdentidad = value; }
        }

        public string TipoDocIdentidad
        {
            get { return _tipoDocIdentidad; }
            set { _tipoDocIdentidad = value; }
        }

        public string PrimerNombre
        {
            get { return _primerNombre; }
            set { _primerNombre = value; }
        }

        public string SegundoNombre
        {
            get { return _segundoNombre; }
            set { _segundoNombre = value; }
        }

        public string PrimerApellido
        {
            get { return _primerApellido; }
            set { _primerApellido = value; }
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

        public int FkLugar
        {
            get { return _fkLugar; }
            set { _fkLugar = value; }
        }

        #endregion
    }
}