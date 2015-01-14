using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.ConfiguracionServiciosPlaya
{
    public class ExcepcionDaoServiciosPlaya : ExcepcionDao
    {
        public ExcepcionDaoServiciosPlaya(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionDaoServiciosPlaya(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}