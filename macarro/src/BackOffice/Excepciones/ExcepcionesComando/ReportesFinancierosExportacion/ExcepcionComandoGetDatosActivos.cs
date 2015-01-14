using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionComandoGetDatosActivos : ExcepcionComando
    {
        public ExcepcionComandoGetDatosActivos (string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoGetDatosActivos(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}