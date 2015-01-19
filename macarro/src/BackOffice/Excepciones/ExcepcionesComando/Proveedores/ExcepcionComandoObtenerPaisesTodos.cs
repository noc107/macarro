using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.Proveedores
{
    public class ExcepcionComandoObtenerPaisesTodos : ExcepcionComando
    {
        public ExcepcionComandoObtenerPaisesTodos(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoObtenerPaisesTodos(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}