using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.ConfiguracionPuestosPlaya
{
    public class ExcepcionDaoPuestoPlaya : ExcepcionDao
    {
        public ExcepcionDaoPuestoPlaya(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionDaoPuestoPlaya(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}