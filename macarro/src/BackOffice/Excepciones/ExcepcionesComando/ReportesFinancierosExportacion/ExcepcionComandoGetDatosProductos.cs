using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionComandoGetDatosProductos : ExcepcionComando
    {
        public ExcepcionComandoGetDatosProductos (string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoGetDatosProductos(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}