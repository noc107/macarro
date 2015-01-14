using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Excepciones.ExcepcionesPresentacion
{
    public class ExcepcionPresentacion:ExcepcionGeneral
    {
        public ExcepcionPresentacion(string codigo, string clase, string metodo, string mensaje,
                    Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionPresentacion(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}