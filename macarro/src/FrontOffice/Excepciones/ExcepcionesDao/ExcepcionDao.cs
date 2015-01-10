using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Excepciones.ExcepcionesDao
{
    public class ExcepcionDao:ExcepcionGeneral
    {
        public ExcepcionDao(string codigo, string clase, string metodo, string mensaje,
                    Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionDao(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}