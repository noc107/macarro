using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones
{
    public class ExcepcionGeneral:Exception
    {
        private string _codigo;
        private string _clase;
        private string _metodo;
        private string _mensaje;
        private Exception _excepcion;

        public ExcepcionGeneral(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

        public ExcepcionGeneral(string codigo, string clase, string metodo, string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
            _codigo = codigo;
            _clase = clase;
            _metodo = metodo;
            _mensaje = mensaje;
            _excepcion = excepcion;
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string Clase
        {
            get { return _clase; }
            set { _clase = value; }
        }

        public string Metodo
        {
            get { return _metodo; }
            set { _metodo = value; }
        }

        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        public Exception Excepcion
        {
            get { return _excepcion; }
            set { _excepcion = value; }
        }
    }
}