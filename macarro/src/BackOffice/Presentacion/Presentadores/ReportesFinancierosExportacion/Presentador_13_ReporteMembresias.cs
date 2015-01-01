using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteMembresias : PresentadorGeneral
    {
        private IContrato_13_ReporteMembresias _vista;

        public Presentador_13_ReporteMembresias(IContrato_13_ReporteMembresias web_13_ReporteMembresias)
            : base(web_13_ReporteMembresias)
        {
            _vista = web_13_ReporteMembresias;

        }
    }
}