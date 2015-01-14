using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionComandoGetDatosProveedores : ExcepcionComando
    {
        public ExcepcionComandoGetDatosProveedores (string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoGetDatosProveedores(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}