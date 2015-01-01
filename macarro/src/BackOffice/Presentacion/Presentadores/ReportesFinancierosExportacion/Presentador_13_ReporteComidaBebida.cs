using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackOffice.Presentacion.Contratos.ReportesFinancierosExportacion;

namespace BackOffice.Presentacion.Presentadores.ReportesFinancierosExportacion
{
    public class Presentador_13_ReporteComidaBebida : PresentadorGeneral
    {
        private IContrato_13_ReporteComidaBebida _vista;

        public Presentador_13_ReporteComidaBebida (IContrato_13_ReporteComidaBebida web_13_ReporteComidaBebida)
            : base(web_13_ReporteComidaBebida)
        {
            _vista = web_13_ReporteComidaBebida;            
        }
    }

}