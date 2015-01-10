using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando
{
    public class ExcepcionComando:ExcepcionGeneral
    {
        public ExcepcionComando(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComando(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}