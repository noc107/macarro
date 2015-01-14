using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.RolesSeguridad
{
    public class ExcepcionDaoMenu : ExcepcionDao
    {
        public ExcepcionDaoMenu(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {           
        }

        public ExcepcionDaoMenu(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }
    }
}