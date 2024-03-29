﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionPuestosPlaya
{
    public class ExcepcionComandoActualizarPuesto : ExcepcionComando
    {
        public ExcepcionComandoActualizarPuesto(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionComandoActualizarPuesto(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}