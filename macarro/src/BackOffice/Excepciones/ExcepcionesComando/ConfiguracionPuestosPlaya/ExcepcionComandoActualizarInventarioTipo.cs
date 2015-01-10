using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya
{
    public class ExcepcionComandoActualizarInventarioTipo : ExcepcionComando
    {
        public ExcepcionComandoActualizarInventarioTipo(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoActualizarInventarioTipo(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}