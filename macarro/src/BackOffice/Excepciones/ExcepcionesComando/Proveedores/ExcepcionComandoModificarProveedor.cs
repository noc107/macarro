using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.Proveedores
{
    public class ExcepcionComandoModificarProveedor : ExcepcionComando
    {
        public ExcepcionComandoModificarProveedor(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoModificarProveedor(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}