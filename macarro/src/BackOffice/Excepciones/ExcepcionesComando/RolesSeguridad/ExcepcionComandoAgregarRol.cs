using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.RolesSeguridad
{
    public class ExcepcionComandoAgregarRol : ExcepcionComando
    {
        public ExcepcionComandoAgregarRol(string codigo, string clase, string metodo, string mensaje,
        Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoAgregarRol(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}