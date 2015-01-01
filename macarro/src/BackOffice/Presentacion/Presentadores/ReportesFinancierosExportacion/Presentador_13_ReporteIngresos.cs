using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteIngresos : PresentadorGeneral
    {
        private IContrato_13_ReporteIngresos _vista;

        public Presentador_13_ReporteIngresos(IContrato_13_ReporteIngresos vista_ReporteIngresos): base(vista_ReporteIngresos)
        {
            _vista = vista_ReporteIngresos;
        }
    }
}