using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave
{
    public class ExcepcionComandoPersona : ExcepcionComando
    {
        public ExcepcionComandoPersona(string codigo, string clase, string metodo, string mensaje,
        Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoPersona(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}