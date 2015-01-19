using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.Proveedores
{
    public class ExcepcionDaoProveedor : ExcepcionDao
    {
        public ExcepcionDaoProveedor(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionDaoProveedor(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}



