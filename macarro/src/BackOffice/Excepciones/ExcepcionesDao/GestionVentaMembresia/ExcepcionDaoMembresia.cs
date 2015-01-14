using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.GestionVentaMembresia
{
    public class ExcepcionDaoMembresia : ExcepcionDao
    {
        public ExcepcionDaoMembresia(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionDaoMembresia(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}