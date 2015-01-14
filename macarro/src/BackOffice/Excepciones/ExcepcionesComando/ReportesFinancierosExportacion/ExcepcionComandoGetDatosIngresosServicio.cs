using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionComandoGetDatosIngresosServicio : ExcepcionComando
    {
        public ExcepcionComandoGetDatosIngresosServicio(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoGetDatosIngresosServicio(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}