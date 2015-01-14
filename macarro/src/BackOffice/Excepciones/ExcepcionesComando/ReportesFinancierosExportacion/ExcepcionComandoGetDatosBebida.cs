using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionComandoGetDatosBebida : ExcepcionComando
    {
        public ExcepcionComandoGetDatosBebida (string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoGetDatosBebida(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}