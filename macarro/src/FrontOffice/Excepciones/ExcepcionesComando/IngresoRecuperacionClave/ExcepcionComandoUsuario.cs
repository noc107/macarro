using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontOffice.Excepciones.ExcepcionesComando.IngresoRecuperacionClave
{
    public class ExcepcionComandoUsuario : ExcepcionComando
    {
        public ExcepcionComandoUsuario(string codigo, string clase, string metodo, string mensaje,
        Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoUsuario(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}