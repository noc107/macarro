using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya
{
    public class ExcepcionComandoConsultarServicioCompleto : ExcepcionComando
    {
        public ExcepcionComandoConsultarServicioCompleto(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoConsultarServicioCompleto(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}