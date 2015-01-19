using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores
{
    public class ExcepcionPresentacionModificarProveedor : ExcepcionPresentacion
    {
         public ExcepcionPresentacionModificarProveedor(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

         public ExcepcionPresentacionModificarProveedor(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}