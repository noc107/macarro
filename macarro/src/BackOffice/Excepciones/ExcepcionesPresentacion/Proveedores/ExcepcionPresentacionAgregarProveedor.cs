using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesPresentacion.Proveedores
{
    public class ExcepcionPresentacionAgregarProveedor : ExcepcionPresentacion
    {
        public ExcepcionPresentacionAgregarProveedor(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionPresentacionAgregarProveedor(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}