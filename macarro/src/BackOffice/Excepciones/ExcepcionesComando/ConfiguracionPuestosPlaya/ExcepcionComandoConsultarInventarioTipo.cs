﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya
{
    public class ExcepcionComandoConsultarInventarioTipo : ExcepcionComando
    {
        public ExcepcionComandoConsultarInventarioTipo(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoConsultarInventarioTipo(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}