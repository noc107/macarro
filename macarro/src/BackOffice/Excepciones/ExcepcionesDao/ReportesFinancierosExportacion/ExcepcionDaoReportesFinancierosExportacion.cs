using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.Excepciones.ExcepcionesDao.ReportesFinancierosExportacion
{
    public class ExcepcionDaoReportesFinancierosExportacion : ExcepcionDao
    {
        public ExcepcionDaoReportesFinancierosExportacion(string codigo, string clase, string metodo, string mensaje,
                            Exception excepcion)
            : base(codigo, clase, metodo, mensaje, excepcion)
        {
        }

        public ExcepcionDaoReportesFinancierosExportacion(string mensaje, Exception excepcion)
            : base(mensaje, excepcion)
        {
        }

    }
}