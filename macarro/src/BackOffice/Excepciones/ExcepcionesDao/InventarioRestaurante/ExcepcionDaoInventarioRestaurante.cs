using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.InventarioRestaurante
{
    public class ExcepcionDaoInventarioRestaurante : ExcepcionDao
    {
        public ExcepcionDaoInventarioRestaurante(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionDaoInventarioRestaurante(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}