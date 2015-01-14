using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesComando.ConfiguracionServiciosPlaya
{
    public class ExcepcionComandoConsultarServicios : ExcepcionComando
    {
        public ExcepcionComandoConsultarServicios(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionComandoConsultarServicios(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}