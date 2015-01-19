using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores
{
    public class ExcepcionPresentacionGestionarProveedor : ExcepcionPresentacion
    {
        public ExcepcionPresentacionGestionarProveedor(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionPresentacionGestionarProveedor(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}