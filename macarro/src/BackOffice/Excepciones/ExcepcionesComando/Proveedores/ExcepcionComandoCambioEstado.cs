using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.Proveedores
{
    public class ExcepcionComandoCambioEstado : ExcepcionComando
    {
        public ExcepcionComandoCambioEstado(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoCambioEstado(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}