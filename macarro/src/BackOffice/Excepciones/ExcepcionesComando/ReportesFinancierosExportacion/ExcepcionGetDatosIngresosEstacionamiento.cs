﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ReportesFinancierosExportacion
{
    public class ExcepcionGetDatosIngresosEstacionamiento : ExcepcionComando
    {
        public ExcepcionGetDatosIngresosEstacionamiento (string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionGetDatosIngresosEstacionamiento(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}