using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya
{
    public class ExcepcionComandoEliminarServicio : ExcepcionComando
    {
        public ExcepcionComandoEliminarServicio(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoEliminarServicio(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}